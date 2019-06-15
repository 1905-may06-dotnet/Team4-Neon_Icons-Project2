using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

    
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IPreferenceRepository pdb;
        private readonly IWeatherRepository wdb;
        //userrepo tentative

        ValuesController(IPreferenceRepository pdb, IWeatherRepository wdb)
        {
            this.pdb = pdb;
            this.wdb = wdb;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{zip}")]
        public ActionResult<Domain.DomainEntities.Weather> GetWeather(string zip)
        {
            Domain.DomainEntities.Location location = new Domain.DomainEntities.Location() { zip = zip };
            ExternalApis.WeatherApi weatherApi = new ExternalApis.WeatherApi();
            Domain.DomainEntities.Weather weather = weatherApi.GetWeatherByLocation(zip);
            return weather;
        }

        //TODO: What is this
        //// GET api/values/5
        //[HttpGet("{zip}")]
        //public ActionResult<Domain.DomainEntities.Weather> GetDefaultGenre(string zip)
        //{
        //    Domain.DomainEntities.Location location = new Domain.DomainEntities.Location() { zip = zip };
        //    ExternalApis.WeatherApi weatherApi = new ExternalApis.WeatherApi();
        //    Domain.DomainEntities.Weather weather = weatherApi.GetWeatherByLocation(zip);
        //    weather = wdb.GetWeather(weather);
        //    return weather;
        //}


        // GET a user's preferences, else display weather to genre pairs.

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
