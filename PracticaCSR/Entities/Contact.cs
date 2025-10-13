using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
