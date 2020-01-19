using System.Threading.Tasks;
using PollyRetryTutorial.Contracts;

namespace PollyRetryTutorial.Services
{
    public interface IGithubService
    {
        Task<GithubUser> GetUserByUsernameAsync(string username);
    }
}