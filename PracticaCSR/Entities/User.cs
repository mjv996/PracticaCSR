namespace PracticaCSR.Entities
{
    public class User
    {
        public User(int id, string firstName, string lastName, string password, string email, UserState state = UserState.Active)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Email = email;
            State = state;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Password { get; set; } 
        public string Email { get; set; }
        public UserState State { get; set; }
    }
}
