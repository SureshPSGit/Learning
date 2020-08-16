using System;
using OneOfTutorial.WithOneOf.Models;

namespace OneOfTutorial.WithOneOf.Services
{
    public interface IUserService
    {
        object CreateUser(User user);

        User GetUserById(Guid userId);
    }
}
