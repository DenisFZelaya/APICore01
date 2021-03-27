using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICore01.Controllers
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
        }


        [HttpGet]
        public ActionResult Get()
        {
            // Coneccion a la base de datos
            using (Models.CRUDAPIHDContext db = new Models.CRUDAPIHDContext())
            {
                // Hacer una consulta con LINQ
                var lst = (from d in db.Personas
                          select d).ToList();

                return Ok(lst);
            }
        }
    }
}
