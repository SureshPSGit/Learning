using System;
using Microsoft.AspNetCore.Mvc;
using OneOfTutorial.WithExceptions.Models;
using OneOfTutorial.WithExceptions.Requests;
using OneOfTutorial.WithExceptions.Services;

namespace OneOfTutorial.WithExceptions.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("users")]
        public IActionResult CreateUser([FromBody] CreateUserRequest request)
        {
            var userToCreate = new User
            {
                FullName = request.FullName,
                Email = request.Email
            };

            var user = _userService.CreateUser(userToCreate);
            return CreatedAtAction("GetUser", new {userId = user.Id}, user);
        }

        [HttpGet("users/{userId}")]
        public IActionResult GetUser([FromRoute] Guid userId)
        {
            var user = _userService.GetUserById(userId);
            return user != null ? (IActionResult) Ok(user) : NotFound();
        }
    }
}
