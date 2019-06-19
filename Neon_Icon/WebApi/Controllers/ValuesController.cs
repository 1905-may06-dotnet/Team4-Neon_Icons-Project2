using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
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
        private readonly IUserRepository udb;

        public ValuesController(IPreferenceRepository pdb, IWeatherRepository wdb, IUserRepository udb)
        {
            this.pdb = pdb;
            this.wdb = wdb;
            this.udb = udb;
        }

        // GET api/values/5
        [HttpGet("{zip}")]
        public ActionResult<Domain.DomainEntities.Weather> GetWeather(string zip)
        {
            Domain.DomainEntities.Location location = new Domain.DomainEntities.Location() { zip = zip };
            ExternalApis.WeatherApi weatherApi = new ExternalApis.WeatherApi();
            Domain.DomainEntities.Weather weather = weatherApi.GetWeatherByLocation(zip);
            weather = wdb.GetWeather(weather);
            return Ok(weather);
        }
        //[HttpGet]
        public ActionResult<Models.Weather> GetGenre (Models.User client)
        {
            //authenticate

            IEnumerable<Preference> allPreference;
            Domain.DomainEntities.User user = udb.Find(client.username);

            ExternalApis.WeatherApi weatherApi = new ExternalApis.WeatherApi();
            Domain.DomainEntities.Weather weather = weatherApi.GetWeatherByLocation(user.location.zip);
            weather = wdb.GetWeather(weather);
            Domain.DomainEntities.Preference preference = new Domain.DomainEntities.Preference();

            allPreference = pdb.GetPreferences(udb.Find(user.username).id);

            preference = allPreference.Where(x => weather.weather_id == x.weather_id).FirstOrDefault();
            if (preference != null)
            {
                Domain.DomainEntities.Weather weatherPreference = new Domain.DomainEntities.Weather() { type = weather.type, description = weather.description, default_genre = preference.genre };
                return Ok(ModelMapper.Map(weatherPreference));
            }
            else
            {
                return Ok(ModelMapper.Map(weather));

            }
        }

        [HttpPut]
        public ActionResult UpdatePreference (Models.User client, Models.Weather preference)
        {
            var user = udb.Find(client.username);
            var weather = wdb.GetWeather(ModelMapper.Map(preference));
            Domain.DomainEntities.Preference newPreference = new Domain.DomainEntities.Preference()
            {
                user_id = user.id,
                weather_id = weather.weather_id,
                genre = weather.default_genre
            };
            if (newPreference.user_id == 0 || newPreference.weather_id == 0)
            {
                return NotFound(newPreference);
            }
            pdb.SetPreference(newPreference);
            return Ok(newPreference);
        }
        [HttpDelete]
        public ActionResult RemovePreference (Models.User client, Models.Weather preference)
        {
            var user = udb.Find(client.username);
            var weather = wdb.GetWeather(ModelMapper.Map(preference));
            Domain.DomainEntities.Preference newPreference = new Domain.DomainEntities.Preference()
            {
                user_id = user.id,
                weather_id = weather.weather_id
            };
            if (newPreference.user_id == 0 || newPreference.weather_id == 0)
            {
                return NotFound(newPreference);
            }
            pdb.DeletePreference(newPreference);
            return Ok(newPreference);
        }
    }
}
