﻿using Asgard.Communications;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Threading;
using System;
using Asgard.Data;

namespace Asgard.ExampleUse
{
    public class ExampleUse:IHostedService
    {
        private readonly IHostApplicationLifetime hostApplicationLifetime;
        private readonly ICbusMessenger cbusMessenger;
        private readonly ILogger<ExampleUse> logger;

        public ExampleUse(IHostApplicationLifetime hostApplicationLifetime, ICbusMessenger cbusMessenger, ILogger<ExampleUse> logger)
        {
            this.hostApplicationLifetime = hostApplicationLifetime;
            this.cbusMessenger = cbusMessenger;
            this.logger = logger;

            hostApplicationLifetime.ApplicationStarted.Register(OnStarted);
        }

        private async void OnStarted()
        {
            cbusMessenger.MessageReceived += (sender, e) =>
            {
                logger.LogInformation($"Message received: {e.Message.GetOpCode()}");
            };
            try
            {
                cbusMessenger.Open();

                var mm = new MessageManager(cbusMessenger);
                logger.LogInformation("Sending node query");
                var replies = await mm.SendMessageWaitForReplies<PNN>(new QNN());
                foreach(var reply in replies)
                {
                    logger.LogInformation($"Node info: Node number: {reply.NodeNumber}, ModuleID: {reply.ModuleId}");
                }
            }
            catch (TransportException e)
            {
                logger.LogError("Error opening connection: {0}", e.Message);
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}