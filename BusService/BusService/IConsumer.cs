using NATS.Client;
using Polly;

namespace BusService
{
    public interface IConsumer
    {
        Task Consume(string sender, byte[] data, Policy policy);
    }
}
