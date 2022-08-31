using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using NATS.Client;

namespace BusService
{
    public abstract class MessageBusHostedService : IHostedService
    {
        private readonly IMessageBusService _serviceBus;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly List<IAsyncSubscription> _eventSubscription = new();

        protected List<MessageBusSubscriber> Subscribers = new();

        public MessageBusHostedService(IMessageBusService serviceBus, IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _serviceBus = serviceBus;
            ConfigureSubscribers();
        }

        protected abstract void ConfigureSubscribers();

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Subscribers.ForEach(Subscribe);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _eventSubscription.ForEach(Unsubscribe);
            return Task.CompletedTask;
        }

        private void Subscribe(MessageBusSubscriber subscriber)
        {
            _eventSubscription.Add(_serviceBus.SubscribeEvent(subscriber.Subject, HandleMessage(subscriber)));
        }

        private EventHandler<MsgHandlerEventArgs> HandleMessage(MessageBusSubscriber subscriber)
        {
            return async (sender, args) =>
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var instance = (IConsumer)scope.ServiceProvider.GetService(subscriber.ConsumerType);
                await instance.Consume(args.Message.Subject, args.Message.Data, subscriber.Policy);
            };
        }

        private void Unsubscribe(IAsyncSubscription subscription)
        {
            try
            {
                if (subscription.IsValid)
                    subscription.Unsubscribe();
            }
            catch (Exception e) { }
        }
    }
}
