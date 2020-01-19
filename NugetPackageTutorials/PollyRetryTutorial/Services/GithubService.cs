using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using PollyRetryTutorial.Contracts;

namespace PollyRetryTutorial.Services
{
    public class GithubService : IGithubService
    {
        private const int MaxRetries = 3;
        private readonly IHttpClientFactory _httpClientFactory;
        private static readonly Random Random = new Random();
        private readonly AsyncRetryPolicy _retryPolicy;
        
        public GithubService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _retryPolicy = Policy.Handle<HttpRequestException>()
                .WaitAndRetryAsync(MaxRetries, times => 
                TimeSpan.FromMilliseconds(times * 100));
        }
        
        public async Task<GithubUser> GetUserByUsernameAsync(string username)
        {
            var client = _httpClientFactory.CreateClient("GitHub");

            return await _retryPolicy.ExecuteAsync(async () =>
            {
                if(Random.Next(1,3) == 1)
                    throw new HttpRequestException("This is a fake request exception");
                    
                var result = await client.GetAsync($"/users/{username}");
                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                    
                var resultString = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<GithubUser>(resultString);
            });
        }
        
        public async Task<List<GithubUser>> GetUsersFromOrgAsync(string orgName)
        {
            var client = _httpClientFactory.CreateClient("GitHub");

            return await _retryPolicy.ExecuteAsync(async () =>
            {
                var result = await client.GetAsync($"/orgs/{orgName}");
                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                    
                var resultString = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<GithubUser>>(resultString);
            });
        }
    }
}