using PracticaCSR.Models.DTOs.Requests;
using PracticaCSR.Models.DTOs.Responses;

namespace PracticaCSR.Services
{
    public interface IUserService
    {
        List<UserDto> GetAllUsers();
        UserDto GetByUserId(int userId);
        UserDto Create(CreateAndUpdateUserDto userDto);
        UserDto Update(int userId, CreateAndUpdateUserDto userDto);
        bool Delete(int userId);
    }
}
