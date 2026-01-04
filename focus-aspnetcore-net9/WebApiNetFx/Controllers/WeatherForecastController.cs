using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Xml.Linq;
using WebApiNetFx.Poco;

namespace WebApiNetFx.Controllers
{
    public class WeatherForecastController : ApiController
    {
        private static readonly string[] Summaries = 
            new string[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        private static List<string> weatherPhenomenons = new List<string>() { "angin brubu", "angin semilir", "masuk angin", "angin tornado" };

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = new Random().Next(-20, 55),
                Summary = Summaries[new Random().Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        public IHttpActionResult GetWeatherByDay(int id)
        {
            WeatherForecast[] weathers = Get().ToArray();
            if (id < 0 || id >= weathers.Length)
            {
                //return NotFound();
                return Content(HttpStatusCode.NotFound, "id/day not found");
            }
            else
            {
                return Ok(weathers[id]);
            }
        }

    }
}
