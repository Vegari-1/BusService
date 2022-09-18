namespace BusService.Contracts
{
	public class PostContract
    {
        public Guid PublisherId { get; set; }

        public PostContract(Guid publisherId)
        {
            PublisherId = publisherId;
        }
    }
}

