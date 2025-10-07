namespace PracticaCSR.Models.DTOs.Requests
{
    public class CreateAndUpdateContactDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
