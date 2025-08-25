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

    private static List<string> weatherPhenomenons = new() { "angin brubu", "angin semilir", "masuk angin", "angin tornado" };

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
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public IActionResult AddPhenomenon(string phenomenonName)
    {
        bool phenomenonFound = weatherPhenomenons.Any(pName => String.Compare(pName, phenomenonName, true) == 0);
        if (phenomenonFound)
        {
            var problemDetail = new ProblemDetails();
            problemDetail.Status = StatusCodes.Status409Conflict;
            problemDetail.Title = "Conflict: failed to add phenomenonName into phenomenonName data.";
            problemDetail.Detail = $"Phenomenon name \"{phenomenonName}\" cannot be inserted because it already exists.";
            problemDetail.Type = "";
            problemDetail.Extensions["traceId"] = HttpContext.TraceIdentifier;
            return new ConflictObjectResult(problemDetail);
        }
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
