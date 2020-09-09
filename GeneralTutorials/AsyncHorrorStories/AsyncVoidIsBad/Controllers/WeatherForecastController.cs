using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AsyncVoidIsBad.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly SomeRepository _repository;

        public WeatherForecastController(SomeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            Task.Run(SomeBackgroundThingAsync);

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }

        private async Task SomeBackgroundThingAsync()
        {
            var result = await _repository.GetValueAsync();
            await Task.Delay(2000);
            Console.WriteLine($"The number is {result}");
        }
    }
}
