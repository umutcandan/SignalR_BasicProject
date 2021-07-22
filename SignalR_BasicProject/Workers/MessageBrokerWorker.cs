using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SignalR_BasicProject.Workers
{
    public sealed class MessageBrokerWorker : BackgroundService
    {
        private IHubContext<MessageBrokerHub> _messageBrokerHub;

        public MessageBrokerWorker(IHubContext<MessageBrokerHub> messageBrokerHub)
        {
            _messageBrokerHub = messageBrokerHub;
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000);
                var eventMessage = new EventMessage($"Id_{Guid.NewGuid():N}",$"Title_{Guid.NewGuid():N}",DateTime.UtcNow);
                await _messageBrokerHub.Clients.All.SendAsync("getMessage", eventMessage, stoppingToken);
            }
        }
    }
}
