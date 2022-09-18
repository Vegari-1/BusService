namespace BusService.Contracts
{
	public class MessageContract
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }

        public MessageContract(Guid senderId, Guid receiverId)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
        }
    }
}

