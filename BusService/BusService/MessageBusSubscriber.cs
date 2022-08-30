using NATS.Client;
using Polly;

namespace BusService
{
    public class MessageBusSubscriber
    {
        public string Subject;
        public Type ConsumerType;
        public Policy Policy;

        public MessageBusSubscriber(Policy policy, string subject, Type consumerType)
        {
            Subject = subject;
            ConsumerType = consumerType;
            Policy = policy;
        }
    }
}
