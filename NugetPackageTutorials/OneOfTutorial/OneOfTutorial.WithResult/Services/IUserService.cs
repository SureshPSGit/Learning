using System;
using LanguageExt.Common;
using OneOfTutorial.WithResult.Models;

namespace OneOfTutorial.WithResult.Services
{
    public interface IUserService
    {
        Result<User> CreateUser(User user);

        User GetUserById(Guid userId);
    }
}
