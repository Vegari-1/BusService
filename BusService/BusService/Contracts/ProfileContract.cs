namespace BusService.Contracts
{
	public class ProfileContract
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public ProfileContract(Guid id, string name, string surname, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
        }
    }
}

