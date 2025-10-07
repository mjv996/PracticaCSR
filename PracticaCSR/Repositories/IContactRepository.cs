using PracticaCSR.Entities;

namespace PracticaCSR.Repositories
{
    public interface IContactRepository
    {
        List<Contact> GetAllContacts();
        Contact? GetByIdContact(int contactId);
        Contact Create(Contact contact);
        Contact? Update(Contact contact);
        bool Delete(int contactId);
    }
}
