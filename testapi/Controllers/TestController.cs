using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharpTemplar;

namespace testapi.Controllers
{
    [ApiController]
    [Route("/")]
    public class WeatherForecastController : ControllerBase
    {

        public WeatherForecastController() { }

        [HttpGet]
        public IActionResult Get()
        {
            var doc = new TemplarDocument("Test site");

            doc.Body.AddDiv();

            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = 200,
                Content = doc.GeneratePage()
            };
        }
    }
}
