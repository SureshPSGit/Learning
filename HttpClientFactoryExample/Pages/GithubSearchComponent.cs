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

        [Inject]
        public IHttpClientFactory HttpClientFactory { get; set; }

        public async Task LoadAccount()
        {
            var httpClient = HttpClientFactory.CreateClient("GitHub");
            AccountInfo = await httpClient.GetStringAsync($"users/{AccountName}");
        }
    }
}