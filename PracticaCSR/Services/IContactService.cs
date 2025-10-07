using PracticaCSR.Models.DTOs.Requests;
using PracticaCSR.Models.DTOs.Responses;

namespace PracticaCSR.Services
{
    public interface IContactService
    {
        List<ContactDto> GetAllContacts();
        ContactDto GetByContactId(int contactId);
        ContactDto Create(CreateAndUpdateContactDto contactDto);
        ContactDto Update(int contactId, CreateAndUpdateContactDto contactDto);
        bool Delete(int contactId);
    }
}
