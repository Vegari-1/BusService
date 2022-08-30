using NATS.Client;
using Polly;

namespace BusService
{
    public interface IConsumer
    {
        EventHandler<MsgHandlerEventArgs> BuildConsumerMethod(Policy policy);
    }
}
