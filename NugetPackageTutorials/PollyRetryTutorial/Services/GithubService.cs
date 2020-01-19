using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PollyRetryTutorial.Contracts;

namespace PollyRetryTutorial.Services
{
    public class GithubService : IGithubService
    {
        private const int MaxRetries = 3;
        private readonly IHttpClientFactory _httpClientFactory;
        private static readonly Random Random = new Random();
        
        public GithubService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        public async Task<GithubUser> GetUserByUsernameAsync(string username)
        {
            var client = _httpClientFactory.CreateClient("GitHub");
            var retriesLeft = MaxRetries;

            GithubUser githubUser = null;
            while (retriesLeft > 0)
            {
                try
                {
                    if(Random.Next(1,3) == 1)
                        throw new HttpRequestException("This is a fake request exception");
                    
                    var result = await client.GetAsync($"/users/{username}");
                    if (result.StatusCode == HttpStatusCode.NotFound)
                    {
                        break;
                    }
                    
                    var resultString = await result.Content.ReadAsStringAsync();
                    githubUser = JsonConvert.DeserializeObject<GithubUser>(resultString);
                    break;
                }
                catch(HttpRequestException exception)
                {
                    retriesLeft--;
                }   
            }

            return githubUser;
        }
    }
}