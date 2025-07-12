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
    }
}
