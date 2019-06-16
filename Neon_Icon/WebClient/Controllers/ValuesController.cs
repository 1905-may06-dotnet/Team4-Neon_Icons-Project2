using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DomainEntities;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            Domain.DomainEntities.Location location = new Domain.DomainEntities.Location() { id = id };
            ExternalApis.WeatherApi weatherApi = new ExternalApis.WeatherApi();
            Domain.DomainEntities.Weather weather = weatherApi.GetWeatherByLocation(location);
            return $"type = {weather.type}, description = {weather.description}";
        }
        //Get weather and genre for user
        public ActionResult<string> GetGenre(User user)
        {
            IEnumerable<Preference> allPreference;
            PreferenceRepository prefRepo = new PreferenceRepository();
            GenreRepository genreRepo = new GenreRepository();

            ExternalApis.WeatherApi weatherApi = new ExternalApis.WeatherApi();
            Domain.DomainEntities.Weather weather = weatherApi.GetWeatherByLocation(user.location);
            Domain.DomainEntities.Preference preference = new Domain.DomainEntities.Preference();

            allPreference = prefRepo.GetPreferences(user.id);

            preference = allPreference.Where(x => x.user_id == user.id && weather.weather_id == x.weather_id).FirstOrDefault();
            if (preference != null)
            {
                Genre prefferedGenre = genreRepo.GetGenres().Where(x => x.id == preference.genre_id).FirstOrDefault();
                return $"Weather: {weather.type} + Preferred Genre: {prefferedGenre.type}";
            }
            else
            {
                //possibly set preference here
                Genre prefferedGenre = genreRepo.GetGenres().Where(x => x.id == weather.default_genre).FirstOrDefault();
                return $"Weather: {weather.type} + Default Genre: {prefferedGenre.type}";
            }
        }
        //Get weather and default genre (no user) based on location
        public ActionResult<string> GetDefaultGenre(Location location)
        {

            ExternalApis.WeatherApi weatherApi = new ExternalApis.WeatherApi();
            Domain.DomainEntities.Weather weather = weatherApi.GetWeatherByLocation(location);
            GenreRepository genreRepo = new GenreRepository();
            Genre prefferedGenre = genreRepo.GetGenres().Where(x => x.id == weather.default_genre).FirstOrDefault();
            return $"Weather: {weather.type} + Genre: {prefferedGenre.type}";

        }



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
