﻿using Asgard.Communications;
using Asgard.Data;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asgard.Tests.CommunicationTests
{
    [TestFixture]
    public class MessageManagerTests
    {
        [Test]
        public async Task ManagerReturnsCorrectMessages_WhenWaitingForMultipleReplies()
        {
            var messenger = new Mock<ICbusMessenger>();
            messenger.Setup(m => m.SendMessage(It.IsAny<ICbusMessage>())).Callback(() => {
                messenger.Raise(m => m.MessageReceived += null, new CbusMessageEventArgs(new ResponseToQueryNode().Message));
                messenger.Raise(m => m.MessageReceived += null, new CbusMessageEventArgs(new ResponseToQueryNode().Message));
            });

            var mm = new MessageManager(messenger.Object);
            var response = await mm.SendMessageWaitForReplies<ResponseToQueryNode>(new QueryNodeNumber());

            response.Count().Should().Be(2);
        }

        [Test]
        public async Task ManagerReturnsCorrectMessages_WhenWaitingForASingleReply()
        {
            var messenger = new Mock<ICbusMessenger>();
            messenger.Setup(m => m.SendMessage(It.IsAny<ICbusMessage>())).Callback(() => {
                messenger.Raise(m => m.MessageReceived += null, new CbusMessageEventArgs(new ResponseToQueryNode() { NodeNumber = 1 }.Message));
                messenger.Raise(m => m.MessageReceived += null, new CbusMessageEventArgs(new ResponseToQueryNode() { NodeNumber = 2 }.Message));
            });

            var mm = new MessageManager(messenger.Object);
            var response = await mm.SendMessageWaitForReply<ResponseToQueryNode>(new QueryNodeNumber());

            response.NodeNumber.Should().Be(1);
        }


        [Test]
        public async Task ManagerReturnsCorrectMessages_WhenWaitingForASingleReply_WithAFilter()
        {
            var messenger = new Mock<ICbusMessenger>();
            messenger.Setup(m => m.SendMessage(It.IsAny<CbusMessage>())).Callback(() => {
                messenger.Raise(m => m.MessageReceived += null, new CbusMessageEventArgs(new ResponseToQueryNode() { NodeNumber = 1 }.Message));
                messenger.Raise(m => m.MessageReceived += null, new CbusMessageEventArgs(new ResponseToQueryNode() { NodeNumber = 2 }.Message));
            });

            var mm = new MessageManager(messenger.Object);
            var response = await mm.SendMessageWaitForReply<ResponseToQueryNode>(new QueryNodeNumber(), m => m.NodeNumber == 2);

            response.NodeNumber.Should().Be(2);
        }

        [Test]
        public void ManagerShouldTimeout_WhenNotAllExpectedArrive()
        {
            var messenger = new Mock<ICbusMessenger>();
            messenger.Setup(m => m.SendMessage(It.IsAny<CbusMessage>())).Callback(() => {
                messenger.Raise(m => m.MessageReceived += null, new CbusMessageEventArgs(new ResponseToQueryNode() { NodeNumber = 1 }.Message));
            });

            var mm = new MessageManager(messenger.Object);
            Assert.ThrowsAsync<TimeoutException>(async () => {
                await mm.SendMessageWaitForReplies<ResponseToQueryNode>(new QueryNodeNumber(), 2);
            });
        }
    }
}
