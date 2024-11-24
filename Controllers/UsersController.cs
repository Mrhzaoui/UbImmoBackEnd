using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UBEE.Models;
using UBEE.Services;

namespace UBEE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationDto model)
        {
            var result = await _userService.RegisterUser(model);
            if (result.Succeeded)
            {
                return Ok(new { message = "User registered successfully" });
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto model)
        {
            var result = await _userService.LoginUser(model);
            if (result.Succeeded)
            {
                return Ok(new { token = result.Token });
            }
            return Unauthorized();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserUpdateDto model)
        {
            var result = await _userService.UpdateUser(id, model);
            if (result.Succeeded)
            {
                return Ok(new { message = "User updated successfully" });
            }
            return BadRequest(result.Errors);
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);
            if (result.Succeeded)
            {
                return Ok(new { message = "User deleted successfully" });
            }
            return BadRequest(result.Errors);
        }
    }
}

