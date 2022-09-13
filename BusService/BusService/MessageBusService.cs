using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NATS.Client;

namespace BusService
{
    public class MessageBusService : IMessageBusService
    {
        private readonly ILogger<MessageBusService> _logger;
        private readonly IConnection _connection;

        public MessageBusService(IOptions<MessageBusSettings> settings, ILogger<MessageBusService> logger)
        {
            _logger = logger;
            _connection = new ConnectionFactory().CreateConnection("nats://nats:4222");
            _logger.Log(LogLevel.Information, $"Attempt to create connection on: {settings.Value.Url}");
            _logger.Log(LogLevel.Information, $"Connection: {settings.Value.Url}");
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
