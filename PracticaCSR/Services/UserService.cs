using PracticaCSR.Entities;
using PracticaCSR.Models.DTOs.Requests;
using PracticaCSR.Models.DTOs.Responses;
using PracticaCSR.Repositories;

namespace PracticaCSR.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserDto> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers()
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    State = u.State
                })
                .ToList();

            return users;
        }

        public UserDto GetByUserId(int userId)
        {
            var user = _userRepository.GetByIdUser(userId)
                ?? throw new Exception("User not found");

            var userDto = new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                State = user.State
            };

            return userDto;
        }

        public UserDto Create(CreateAndUpdateUserDto userDto)
        {
            var user = new User(0, userDto.FirstName, userDto.LastName, userDto.Password, userDto.Email, userDto.State);

            var created = _userRepository.Create(user);

            var createdDto = new UserDto
            {
                Id = created.Id,
                FirstName = created.FirstName,
                LastName = created.LastName,
                Email = created.Email,
                State = created.State
            };

            return createdDto;
        }

        public UserDto Update(int userId, CreateAndUpdateUserDto userDto)
        {
            var user = new User(userId, userDto.FirstName, userDto.LastName, userDto.Password, userDto.Email, userDto.State);

            var updated = _userRepository.Update(user)
                ?? throw new Exception("User not found for update");

            var updatedDto = new UserDto
            {
                Id = updated.Id,
                FirstName = updated.FirstName,
                LastName = updated.LastName,
                Email = updated.Email,
                State = updated.State
            };

            return updatedDto;
        }

        public bool Delete(int userId)
        {
            return _userRepository.Delete(userId);
        }
    }
}
