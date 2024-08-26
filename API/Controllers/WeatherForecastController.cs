using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
            // using var connection = new MySqlConnection("Server=localhost;User ID=root;Password=angel;Database=reactivities");
            // connection.Open();

            // using var command = new MySqlCommand("SELECT column1_name FROM activities;", connection);
            // using var reader = command.ExecuteReader();
            // while (reader.Read())
            //     Console.WriteLine(reader.GetString(0));

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }


//  [HttpGet(Name = "GetW")]
//     public IEnumerable<WeatherForecast> GetWeatherForecasts()
//     {
//         return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//         {
//             Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             TemperatureC = Random.Shared.Next(-20, 55),
//             Summary = Summaries[Random.Shared.Next(Summaries.Length)]
//         })
//         .ToArray();
//     }

}
