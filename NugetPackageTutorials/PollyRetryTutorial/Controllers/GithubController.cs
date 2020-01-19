using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PollyRetryTutorial.Services;

namespace PollyRetryTutorial.Controllers
{
    [ApiController]
    public class GithubController : ControllerBase
    {
        private readonly IGithubService _githubService;
        
        public GithubController(IGithubService githubService)
        {
            _githubService = githubService;
        }
        
        [HttpGet("users/{userName}")]
        public async Task<IActionResult> GetUserByUsername(string userName)
        {
            var user = await _githubService.GetUserByUsernameAsync(userName);
            return user != null ? (IActionResult) Ok(user) : NotFound();
        }
    }
}