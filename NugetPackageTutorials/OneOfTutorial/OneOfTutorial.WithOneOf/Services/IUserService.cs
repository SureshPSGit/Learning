using System;
using OneOf;
using OneOfTutorial.WithOneOf.Models;

namespace OneOfTutorial.WithOneOf.Services
{
    public interface IUserService
    {
        OneOf<User, InvalidEmail, EmailAlreadyExists> CreateUser(User user);

        User GetUserById(Guid userId);
    }
}
