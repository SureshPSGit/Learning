using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneOfTutorial.WithResult.Models;
using OneOfTutorial.WithResult.Requests;
using OneOfTutorial.WithResult.Services;

namespace OneOfTutorial.WithResult.Controllers
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

            var userResult = _userService.CreateUser(userToCreate);

            return userResult.Match<IActionResult>(user => CreatedAtAction("GetUser", new {userId = user.Id}, user), exception =>
            {
                if (exception is BadRequestException badRequestException)
                {
                    return BadRequest(badRequestException.Error);
                }

                return StatusCode(StatusCodes.Status500InternalServerError);
            });
        }

        [HttpGet("users/{userId}")]
        public IActionResult GetUser([FromRoute] Guid userId)
        {
            var user = _userService.GetUserById(userId);
            return user != null ? (IActionResult) Ok(user) : NotFound();
        }
    }
}
