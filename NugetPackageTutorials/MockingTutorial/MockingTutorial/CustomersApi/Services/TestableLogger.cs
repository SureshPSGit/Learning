using Microsoft.Extensions.Logging;

namespace CustomersApi.Services
{
    public class TestableLogger : ILoggingService
    {
        private readonly ILogger _logger;

        public TestableLogger(ILogger<TestableLogger> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message, params object[] parameters)
        {
            _logger.LogInformation(message, parameters);
        }
    }
}