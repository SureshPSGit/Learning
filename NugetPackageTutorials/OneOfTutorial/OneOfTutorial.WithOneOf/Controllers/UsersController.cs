using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using OneOfTutorial.WithOneOf.Models;
using OneOfTutorial.WithOneOf.Requests;
using OneOfTutorial.WithOneOf.Services;

namespace OneOfTutorial.WithOneOf.Controllers
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

            var userOneOf = _userService.CreateUser(userToCreate);

            return userOneOf.Match<IActionResult>(Ok,
                email => BadRequest(Errors.NotValidEmail),
                exists => BadRequest(Errors.EmailAlreadyExistsError));
        }

        [HttpGet("users/{userId}")]
        public IActionResult GetUser([FromRoute] Guid userId)
        {
            var user = _userService.GetUserById(userId);
            return user != null ? (IActionResult) Ok(user) : NotFound();
        }
    }
}
