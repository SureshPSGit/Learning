using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneOfTutorial.WithExceptions.Models;

namespace OneOfTutorial.WithExceptions.Services
{
    public class UserService : IUserService
    {
        private readonly ConcurrentDictionary<Guid, User> _users = new ConcurrentDictionary<Guid, User>(new Dictionary<Guid, User>
        {
            {Guid.Parse("D75043B5-B6A4-4002-9587-EF6ED22215A9"), new User
            {
                Id = Guid.Parse("D75043B5-B6A4-4002-9587-EF6ED22215A9"),
                Email = "nick.chapsas@gmail.com",
                FullName = "Nick Chapsas"
            }}
        });

        public User CreateUser(User user)
        {
            if (!RegexUtilities.IsValidEmail(user.Email))
            {
                throw new BadRequestException(Errors.NotValidEmail);
            }

            var existingEmails = _users.Values.Select(x => x.Email.Normalize());

            if (existingEmails.Contains(user.Email.Normalize()))
            {
                throw new BadRequestException(Errors.EmailAlreadyExistsError);
            }

            _users.TryAdd(user.Id, user);
            return user;
        }

        public User GetUserById(Guid userId)
        {
            return _users.TryGetValue(userId, out var user) ? user : null;
        }
    }
}
