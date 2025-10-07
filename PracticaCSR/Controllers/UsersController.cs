using Microsoft.AspNetCore.Mvc;
using PracticaCSR.Models.DTOs.Requests;
using PracticaCSR.Services;

namespace PracticaCSR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsers();
            if (!users.Any())
            {
                return NoContent();
            }
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            try
            {
                var user = _userService.GetByUserId(userId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAndUpdateUserDto userDto)
        {
            if (userDto == null)
                return BadRequest("Invalid user data.");

            var createdUser = _userService.Create(userDto);
            return Ok(createdUser);
        }

        [HttpPut("{userId}")]
        public IActionResult Update(int userId, [FromBody] CreateAndUpdateUserDto userDto)
        {
            if (userDto == null)
                return BadRequest("Invalid user data.");

            try
            {
                var updatedUser = _userService.Update(userId, userDto);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{userId}")]
        public IActionResult Delete(int userId)
        {
            var deleted = _userService.Delete(userId);

            if (!deleted)
                return NotFound($"User with ID {userId} not found.");

            return NoContent();
        }
    }
}
