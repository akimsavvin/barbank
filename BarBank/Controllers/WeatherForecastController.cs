using Microsoft.AspNetCore.Mvc;

namespace BarBank.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    // [HttpGet(Name = "GetWeatherForecast")]
    [HttpGet("/weather-forecast")]
    public IActionResult Get()
    {
        var forecast = new WeatherForecast
        {
            Date = DateTime.Now,
            TemperatureC = 21,
            Summary = "Hello World!"
        };
        _logger.Log(LogLevel.Trace, "Hello World");
        _logger.Log(LogLevel.Debug, "Hello World!");
        _logger.Log(LogLevel.Information, "Hello World!");
        _logger.Log(LogLevel.Warning, "Hello World!");
        _logger.Log(LogLevel.Error, "Hello World!");
        _logger.Log(LogLevel.Critical, "Hello World!");
        _logger.Log(LogLevel.None, "Hello World!");
        return Ok("Hello World");
    }
}