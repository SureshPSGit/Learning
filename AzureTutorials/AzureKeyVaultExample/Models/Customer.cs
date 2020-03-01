using Newtonsoft.Json;

namespace AzureKeyVaultExample.Models
{
    public class Customer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        public string FullName { get; set; }
    }
}