﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExampleAPI.Controllers
{
    /// <summary>
    /// Handle create example controller
    /// </summary>
    //[ApiController]
    [Route("api/v1/example")]
    [Produces("application/json")]
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
        /// <summary>
        /// Example Get with OdataOptions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [EnableQuery]
        [ProducesResponseType(typeof(List<WeatherForecast>), 200)]
        public IActionResult Get(/*ODataQueryOptions<WeatherForecast> options*/)
        {
            var rng = new Random();
            var res= Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            return StatusCode(StatusCodes.Status200OK, res);
        }
    }
}
