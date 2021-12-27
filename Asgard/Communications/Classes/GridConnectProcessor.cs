﻿using Microsoft.Extensions.Logging;
using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asgard.Communications
{
    public class GridConnectProcessor:IGridConnectProcessor,IDisposable
    {
        private readonly ILogger<GridConnectProcessor> logger;

        public ITransport Transport { get; }

        public event EventHandler<TransportErrorEventArgs> TransportError;
        public event EventHandler<MessageReceivedEventArgs> GridConnectMessage;

        private CancellationTokenSource cts;
        private bool disposedValue;

        public GridConnectProcessor(ITransport transport, ILogger<GridConnectProcessor> logger = null)
        {
            this.Transport = transport;
            this.logger = logger;
        }

        public void Open()
        {
            this.logger?.LogTrace(nameof(Open));
            this.Transport.Open();
            this.cts = new CancellationTokenSource();
            var pipe = new Pipe();
            //TODO: would this be better as distinct threads rather than using up threads from the threadpool?
            ReadPipe(pipe.Reader).AsgardFireAndForget();
            Listen(pipe.Writer).AsgardFireAndForget();
        }

        private Task Listen(PipeWriter writer)
        {
            return Task.Run(async () => {
                const int minBufferSize = 64;
                while (!this.cts.Token.IsCancellationRequested)
                {
                    var memory = writer.GetMemory(minBufferSize);
                    try
                    {
                        var read = await this.Transport.ReadAsync(memory, this.cts.Token);
                        this.logger?.LogTrace("Read {0} bytes", read);
                        if (read == 0)
                        {
                            //todo?
                        }

                        writer.Advance(read);
                        await writer.FlushAsync(this.cts.Token);
                    }
                    catch (TaskCanceledException)
                    {
                        //ok
                    }
                    catch (Exception e)
                    {
                        logger?.LogError(e, "Error reading from transport");
                        TransportError?.Invoke(this, 
                            new TransportErrorEventArgs(
                                new TransportException("Error receiving bytes", e)));
                    }
                }
            });
        }

        private Task ReadPipe(PipeReader reader)
        {
            return Task.Run(async () =>
            {
                while (!this.cts.Token.IsCancellationRequested)
                {
                    var result = await reader.ReadAsync(this.cts.Token);
                    var buffer = result.Buffer;
                    SequencePosition? endPosition;
                    do
                    {
                        endPosition = buffer.PositionOf((byte)';');
                        if (endPosition != null)
                        {
                            endPosition = buffer.GetPosition(1, endPosition.Value);
                            ProcessMessage(buffer.Slice(0, endPosition.Value));
                            buffer = buffer.Slice(endPosition.Value);
                        }

                    } while (endPosition != null);

                    reader.AdvanceTo(buffer.Start, buffer.End);
                }
            });
        }

        private void ProcessMessage(ReadOnlySequence<byte> readOnlySequence)
        {
            var startPosition = readOnlySequence.PositionOf((byte)':');
            if (startPosition != null)
            {
                var msg = GetMessageString(readOnlySequence.Slice(startPosition.Value, readOnlySequence.End));
                this.logger?.LogTrace("Message received {0}", msg);
                GridConnectMessage?.Invoke(this, new MessageReceivedEventArgs(msg));
            }
            else
            {
                var msg = new Lazy<string>(() => 
                    $"Partial message received: {GetMessageString(readOnlySequence)}", false);
                this.logger?.LogWarning(msg.Value);
                TransportError?.Invoke(this, 
                    new TransportErrorEventArgs(
                        new TransportException(msg.Value)));
            }
        }

        string GetMessageString(ReadOnlySequence<byte> buffer)
        {
            if (buffer.IsSingleSegment)
            {
                return Encoding.ASCII.GetString(buffer.First.Span);
            }

            return string.Create((int)buffer.Length, buffer, (span, sequence) =>
            {
                foreach (var segment in sequence)
                {
                    Encoding.ASCII.GetChars(segment.Span, span);
                    span = span[segment.Length..];
                }
            });
        }

        public async Task SendMessage(string gridConnectMessage)
        {
            try
            {
                this.logger?.LogTrace("Sending message: {0}", gridConnectMessage);
                await this.Transport.SendAsync(Encoding.ASCII.GetBytes(gridConnectMessage), this.cts.Token);

            }
            catch (TaskCanceledException)
            {
                //ok
            }
            catch (Exception e)
            {
                this.logger?.LogError("Error sending message", e);
                TransportError?.Invoke(this,
                    new TransportErrorEventArgs(
                        new TransportException("Error sending message", e)));
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            this.logger?.LogTrace("Disposing: {0}", disposing);
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.cts.Dispose();
                    this.cts = null;
                }
                this.disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
