using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DomainEntities;
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
        //User Repo tentative

        //ValuesController(IPreferenceRepository pdb, IWeatherRepository wdb)
        //{
        //    this.pdb = pdb;
        //    this.wdb = wdb;
        //}


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
        public ActionResult<string> GetGenre(User user)
        {
            IEnumerable<Preference> allPreference;

            ExternalApis.WeatherApi weatherApi = new ExternalApis.WeatherApi();
            Domain.DomainEntities.Weather weather = weatherApi.GetWeatherByLocation(user.location.zip);
            Domain.DomainEntities.Preference preference = new Domain.DomainEntities.Preference();

            allPreference = pdb.GetPreferences(user.id);

            preference = allPreference.Where(x => x.user_id == user.id && weather.weather_id == x.weather_id).FirstOrDefault();
            if (preference != null)
            {
                return $"Weather: {weather.type} + Preferred Genre: {preference.genre}";
            }
            else
            {
                //possibly set preference here
                return $"Weather: {weather.type} + Default Genre: {weather.default_genre}";
            }
        }
        //Get weather and default genre (no user) based on location
        public ActionResult<string> GetDefaultGenre(Location location)
        {

            ExternalApis.WeatherApi weatherApi = new ExternalApis.WeatherApi();
            Domain.DomainEntities.Weather weather = weatherApi.GetWeatherByLocation(location.zip);
            return $"Weather: {weather.type} + Genre: {weather.default_genre}";

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
