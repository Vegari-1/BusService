using Microsoft.Extensions.Options;
using NATS.Client;

namespace BusService
{
    public class MessageBusService : IMessageBusService
    {
        private readonly IConnection _connection;

        public MessageBusService(IOptions<MessageBusSettings> settings)
        {
            _connection = new ConnectionFactory().CreateConnection(settings.Value.Url);
        }

        public void PublishEvent(string subject, byte[] data)
        {
            _connection.Publish(subject, data);
        }

        public IAsyncSubscription SubscribeEvent(string subject, EventHandler<MsgHandlerEventArgs> handler)
        {
            return _connection.SubscribeAsync(subject, handler);
        }


        public void UnsubscribeEvent(IAsyncSubscription subscription)
        {
            subscription.Unsubscribe();
        }
    }
}
