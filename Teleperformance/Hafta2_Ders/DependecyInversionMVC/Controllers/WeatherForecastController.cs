using Microsoft.AspNetCore.Mvc;

namespace DependecyInversionMVC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastManager _weatherForecastManager;

        public WeatherForecastController(ServiceResolver weatherForecastManager)
        {
            _weatherForecastManager = weatherForecastManager(WFM.First);
        }

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherForecastManager.Get();
        }
    }
}