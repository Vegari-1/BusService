namespace BusService.Contracts
{
	public class ProfileContract
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Avatar { get; set; }

        public ProfileContract(Guid id, string name, string surname, string email, string username, string avatar)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Username = username;
            Avatar = avatar;
        }
    }
}

