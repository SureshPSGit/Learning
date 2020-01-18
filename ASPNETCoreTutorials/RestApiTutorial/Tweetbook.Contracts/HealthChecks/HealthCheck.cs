namespace Tweetbook.Contracts.HealthChecks
{
    public class HealthCheck
    {
        public string Status { get; set; }

        public string Component { get; set; }

        public string Description { get; set; }
    }
}