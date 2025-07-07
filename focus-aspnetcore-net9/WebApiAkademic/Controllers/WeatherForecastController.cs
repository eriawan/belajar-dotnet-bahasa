using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WebApiAkademic.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static List<string> weatherPhenomenons = new() { "angin brubu", "angin semilir" };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpPost]
    [Route("/weatherphenomenon")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddPhenomenon(string phenomenonName)
    {
        weatherPhenomenons.Add(phenomenonName);
        return new CreatedResult();
    }

    [HttpGet]
    [Route("/weatherphenomenon")]
    public string[] GetWeatherPhenomenons()
    {
        return weatherPhenomenons.ToArray();
    }

}
