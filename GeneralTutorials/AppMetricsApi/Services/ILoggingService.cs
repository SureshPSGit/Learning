namespace AppMetricsApi.Services
{
    public interface ILoggingService
    {
        void LogInformation(string message, params object[] parameters);
    }
}