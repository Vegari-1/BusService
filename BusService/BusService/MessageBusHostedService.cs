using NATS.Client;
using Microsoft.Extensions.Hosting;

namespace BusService
{
    public abstract class MessageBusHostedService : IHostedService
    {
        private readonly IMessageBusService _serviceBus;
        private readonly List<IAsyncSubscription> _eventSubscription = new();

        protected List<MessageBusSubscriber> Subscribers = new();

        public MessageBusHostedService(IMessageBusService serviceBus)
        {
            _serviceBus = serviceBus;
            ConfigureSubscribers();
        }

        protected abstract void ConfigureSubscribers();

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Subscribers.ForEach((subscriber) => _eventSubscription.Add(_serviceBus.SubscribeEvent(subscriber.Subject, subscriber.Handler)));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _eventSubscription.ForEach((subscription) => subscription.Unsubscribe());
            return Task.CompletedTask;
        }
    }
}
