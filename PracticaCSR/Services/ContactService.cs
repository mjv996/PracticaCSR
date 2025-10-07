using PracticaCSR.Entities;
using PracticaCSR.Models.DTOs.Requests;
using PracticaCSR.Models.DTOs.Responses;
using PracticaCSR.Repositories;

namespace PracticaCSR.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public List<ContactDto> GetAllContacts()
        {
            var contacts = _contactRepository.GetAllContacts()
                .Select(x => new ContactDto
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                })
                .ToList();

            return contacts;
        }

        public ContactDto GetByContactId(int contactId)
        {
            var contact = _contactRepository.GetByIdContact(contactId);
            if (contact == null)
            {
                throw new Exception("Contact not found");
            }

            return new ContactDto
            {
                Id = contact.Id,
                UserId = contact.UserId,
                FirstName = contact.FirstName,
                LastName = contact.LastName
            };
        }

        public ContactDto Create(CreateAndUpdateContactDto contactDto)
        {
            var contact = new Contact(0, contactDto.UserId, contactDto.FirstName, contactDto.LastName);

            var created = _contactRepository.Create(contact);

            var createdDto = new ContactDto
            {
                Id = created.Id,
                UserId = created.UserId,
                FirstName = created.FirstName,
                LastName = created.LastName
            };

            return createdDto;
        }

        public ContactDto Update(int contactId, CreateAndUpdateContactDto contactDto)
        {
            var contact = new Contact(contactId, contactDto.UserId, contactDto.FirstName, contactDto.LastName);

            var updated = _contactRepository.Update(contact);
            if (updated == null)
            {
                throw new Exception("Contact not found for update");
            }

            ContactDto updatedDto = new ContactDto
            {
                Id = updated.Id,
                UserId = updated.UserId,
                FirstName = updated.FirstName,
                LastName = updated.LastName
            };

            return updatedDto;
        }

        public bool Delete(int contactId)
        {
            return _contactRepository.Delete(contactId);
        }
    }
}
