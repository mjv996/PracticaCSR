using PracticaCSR.Data;
using PracticaCSR.Entities;

namespace PracticaCSR.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PracticaDbContext _context;

        public UserRepository(PracticaDbContext context)
        {
            _context = context;
        }

        private static List<User> _users = new()
        {
            new User(1, "Alice", "Smith", "1234", "alice@example.com"),
            new User(2, "Bob", "Johnson", "abcd", "bob@example.com"),
            new User(3, "Carol", "Williams", "pass123", "carol@example.com", UserState.Archived),
            new User(4, "David", "Brown", "secure1", "david@example.com"),
            new User(5, "Eve", "Davis", "qwerty", "eve@example.com", UserState.Deleted)
        };

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public User? GetByIdUser(int userId)
        {
            return _users.FirstOrDefault(u => u.Id == userId);
        }

        public User Create(User user)
        {
            int nextId = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;
            user.Id = nextId;
            _users.Add(user);
            return user;
        }

        public User? Update(User user)
        {
            var existing = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existing == null)
                return null;

            existing.FirstName = user.FirstName;
            existing.LastName = user.LastName;
            existing.Password = user.Password;
            existing.Email = user.Email;
            existing.State = user.State;

            return existing;
        }

        public bool Delete(int userId)
        {
            var user = _users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                return false;

            _users.Remove(user);
            return true;
        }

        public User? GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
        }
    }
}
