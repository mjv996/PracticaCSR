using PracticaCSR.Entities;

namespace PracticaCSR.Models.DTOs.Requests
{
    public class CreateAndUpdateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Password { get; set; } 
        public string Email { get; set; } 
        public UserState State { get; set; }
    }
}
