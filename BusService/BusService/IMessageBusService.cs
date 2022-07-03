using NATS.Client;

namespace BusService
{
    public interface IMessageBusService
    {
        void PublishEvent(string subject, byte[] data);
        IAsyncSubscription SubscribeEvent(string subject, EventHandler<MsgHandlerEventArgs> handler);
        void UnsubscribeEvent(IAsyncSubscription subscription);
    }
}
