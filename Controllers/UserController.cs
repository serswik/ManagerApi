using Microsoft.AspNetCore.Mvc;
using ManagerApi.DTOs;
using ManagerApi.Models;

namespace ManagerApi.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private static readonly List<User> Users = new();
        private static int _nextId = 1;

        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            return Ok(Users);
        }

        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] UserCreateDto userDto)
        {
            var newUser = new User
            {
                Id = _nextId++,
                FullName = userDto.FullName,
                Email = userDto.Email,
                DateOfBirth = userDto.DateOfBirth
            };

            Users.Add(newUser);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            Users.Remove(user);
            return Ok($"User with ID {id} deleted successfully.");
        }

    }
}
