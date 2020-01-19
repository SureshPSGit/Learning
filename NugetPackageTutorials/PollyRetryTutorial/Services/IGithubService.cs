using System.Collections.Generic;
using System.Threading.Tasks;
using PollyRetryTutorial.Contracts;

namespace PollyRetryTutorial.Services
{
    public interface IGithubService
    {
        Task<GithubUser> GetUserByUsernameAsync(string username);

        Task<List<GithubUser>> GetUsersFromOrgAsync(string orgName);
    }
}