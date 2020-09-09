using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AlwaysPassCancellationToken
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync(
            CancellationToken cancellationToken)
        {
            var rng = new Random();
            try
            {
                //Simulates an IO call. Don't actually do this, prefer FromResult
                return await Task.Run(async () =>
                {
                    await Task.Delay(5000, cancellationToken);
                    Console.WriteLine("Waited for 5 seconds");
                    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                    {
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = rng.Next(-20, 55),
                        Summary = Summaries[rng.Next(Summaries.Length)]
                    });
                }, cancellationToken);
            }
            catch (TaskCanceledException)
            {
            }

            return Enumerable.Empty<WeatherForecast>();
        }
    }
}
