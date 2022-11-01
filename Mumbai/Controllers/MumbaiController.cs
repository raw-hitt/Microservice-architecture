using Microsoft.AspNetCore.Mvc;

namespace Mumbai.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MumbaiController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<MumbaiController> _logger;

        public MumbaiController(ILogger<MumbaiController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Mumbai")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}