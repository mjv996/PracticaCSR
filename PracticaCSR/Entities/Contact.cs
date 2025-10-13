namespace PracticaCSR.Entities
{
    public class Contact
    {
        public Contact(int id, int userId, string firstName, string lastName)
        {
            Id = id;
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
        }
        
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
