namespace BusService.Contracts
{
	public class ConnectionContract
    {
        public Guid Id { get; set; }
        public Guid Profile1 { get; set; }
        public Guid Profile2 { get; set; }

        public ConnectionContract(Guid id, Guid profile1, Guid profile2)
        {
            Id = id;
            Profile1 = profile1;
            Profile2 = profile2;
        }
    }
}

