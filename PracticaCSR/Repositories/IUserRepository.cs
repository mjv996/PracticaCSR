using PracticaCSR.Entities;

namespace PracticaCSR.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User? GetByIdUser(int userId);
        User? GetByEmail(string email);
        User Create(User user);
        User? Update(User user);
        bool Delete(int userId);
    }
}
