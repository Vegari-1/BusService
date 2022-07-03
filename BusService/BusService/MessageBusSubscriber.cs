using NATS.Client;

namespace BusService
{
    public class MessageBusSubscriber
    {
        public string Subject;   
        public EventHandler<MsgHandlerEventArgs> Handler;

        public MessageBusSubscriber(string subject, EventHandler<MsgHandlerEventArgs> handler)
        {
            Subject = subject;
            Handler = handler;
        }

    }
}
