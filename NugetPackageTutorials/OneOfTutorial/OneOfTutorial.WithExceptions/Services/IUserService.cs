using System;
using System.Threading.Tasks;
using OneOfTutorial.WithExceptions.Models;

namespace OneOfTutorial.WithExceptions.Services
{
    public interface IUserService
    {
        User CreateUser(User user);

        User GetUserById(Guid userId);
    }
}
