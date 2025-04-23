using Microsoft.AspNetCore.Mvc;
using AuctionAPI1._0.Repositories;
using AuctionAPI1._0.Models;

namespace AuctionAPI1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(User user)
        {
            await _userRepository.CreateUser(user);
            return Ok();
        }
    }
}
