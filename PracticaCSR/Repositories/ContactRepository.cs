using PracticaCSR.Entities;

namespace PracticaCSR.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private static List<Contact> _contacts = new()
        {
            new Contact(1, 101, "Alice", "Smith"),
            new Contact(2, 102, "Bob", "Johnson"),
            new Contact(3, 101, "Carol", "Williams"),
            new Contact(4, 103, "David", "Brown"),
            new Contact(5, 104, "Eve", "Davis")
        };

        public List<Contact> GetAllContacts() 
        {
            return _contacts;
        } 

        public Contact? GetByIdContact(int contactId)
        {
            return _contacts.FirstOrDefault(x => x.Id == contactId);
        }
        
        public List<Contact> GetByUserId(int userId)
        {
            return _contacts.Where(x => x.UserId == userId).ToList();
        }

        public Contact Create(Contact contact)
        {
            int nextId = _contacts.Any() ? _contacts.Max(x => x.Id) + 1 : 1;
            contact.Id = nextId;
            _contacts.Add(contact);
            return contact;
        }

        public Contact? Update(Contact contact)
        {
            var existing = _contacts.FirstOrDefault(x => x.Id == contact.Id);
            if (existing == null)
                return null;

            existing.FirstName = contact.FirstName;
            existing.LastName = contact.LastName;
            existing.UserId = contact.UserId;

            return existing;
        }

        public bool Delete(int contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.Id == contactId);
            if (contact == null)
            {
                return false;
            }

            _contacts.Remove(contact);
            return true;
        }
    }
}
