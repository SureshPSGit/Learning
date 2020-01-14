using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace HttpClientFactoryExample.Pages
{
    public class GithubSearchComponent : ComponentBase
    {
        protected string AccountName { get; set; }
  
        protected string AccountInfo { get; set; }

        public async Task LoadAccount()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.github.com/"),
                DefaultRequestHeaders =
                {
                    {"Accept", "application/vnd.github.v3+json"},
                    {"User-Agent", "HttpClientFactoryExample"}
                }
            };

            AccountInfo = await httpClient.GetStringAsync($"users/{AccountName}");
        }
    }
}