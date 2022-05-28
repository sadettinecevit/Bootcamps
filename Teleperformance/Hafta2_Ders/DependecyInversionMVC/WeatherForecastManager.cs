namespace DependecyInversionMVC
{
    public delegate IWeatherForecastManager ServiceResolver(WFM wfm);

    public enum WFM
    { 
        First, 
        Second 
    };

    public interface IWeatherForecastManager
    {
        public WeatherForecast[] Get();
    }

    public class WeatherForecastManager : IWeatherForecastManager
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

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

        WeatherForecast[] IWeatherForecastManager.Get()
        {
            throw new NotImplementedException();
        }
    }

    public class WeatherForecastManager2 : IWeatherForecastManager
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

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

        WeatherForecast[] IWeatherForecastManager.Get()
        {
            throw new NotImplementedException();
        }
    }
}
