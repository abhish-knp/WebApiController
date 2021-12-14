﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApiController.Controllers
{
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
            // this._logger.LogInformation(nameof(WeatherForecastController) + $" is created.");
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            // this._logger.LogInformation(nameof(WeatherForecastController) + $".Get() is called.");

            var rng = new Random();
            int id = 0;
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                ID = ++id,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<WeatherForecast> GetByID(int id)
        {
            //this._logger.LogInformation(nameof(WeatherForecastController) + $".GetByID(int id) is called.");

            var rng = new Random();
            var record = new WeatherForecast
            {
                ID = id,
                Date = DateTime.Now.AddDays(id),
                TemperatureC = (2 * id),
                Summary = Summaries[id]
            };

            var result = Ok(record);
            this._logger.LogInformation(nameof(WeatherForecastController) + $".GetByID(...) executed with result: {result}.");

            return result;
        }

        [HttpGet]
        [Route("public")]
        public IActionResult Public( string name)
        {
            return Ok(new
            {
                Message = $"Hello,{name} from a public endpoint! You don't need to be authenticated to see this."
            });
        }

        //[HttpGet("private")]
        //[Authorize]
        //public IActionResult Private()
        //{
        //    return Ok(new
        //    {
        //        Message = "Hello from a private endpoint! You need to be authenticated to see this."
        //    });
        //}

        //[HttpGet("private-scoped")]
        //[Authorize("read:messages")]
        //public IActionResult Scoped()
        //{
        //    return Ok(new
        //    {
        //        Message = "Hello from a private endpoint! You need to be authenticated and have a scope of read:messages to see this."
        //    });
        //}

        //// This is a helper action. It allows you to easily view all the claims of the token.
        //[HttpGet("claims")]
        //public IActionResult Claims()
        //{
        //    return Ok(User.Claims.Select(c =>
        //        new
        //        {
        //            c.Type,
        //            c.Value
        //        }));
        //}



        // POST api/values
        [HttpPost]
        public void Post([FromBody] WeatherForecast weatherForecast)
        {
            this._logger.LogInformation(nameof(WeatherForecastController) + $".Post(...) is called with body: {weatherForecast}");
            throw new Exception("AspNetCore2.WebApi sample: Unhandled exception within the ValueController.Post(...)");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
