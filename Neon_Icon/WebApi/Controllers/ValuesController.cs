﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using Domain.DomainEntities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
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
        /// <summary>
        /// Get the weather based on users zipcode
        /// </summary>
        /// <param name="zip"></param>
        /// <returns></returns>
        public ActionResult<Domain.DomainEntities.Weather> GetWeather(string zip)
        {
            Dictionary<string, string> weatherDictionary = new Dictionary<string, string>
            {
                { "Thunderstorm", "African Percussion" },
                { "Drizzle", "Classical" },
                { "Rain", "R&B" },
                { "Snow", "Christmas" },
                { "Mist", "Jazz" },
                { "Smoke", "Cyberpunk" },
                { "Haze", "EDM" },
                { "Dust", "Western" },
                { "Fog", "Punk" },
                { "Sand", "Arab Pop" },
                { "Ash", "Rap" },
                { "Squall", "Rock" },
                { "Tornado", "Metal" },
                { "Clear", "Pop" },
                { "Clouds", "Indie" }
            };

            ExternalApis.WeatherApi weatherApi = new ExternalApis.WeatherApi();
            Domain.DomainEntities.Weather weather = weatherApi.GetWeatherByLocation(zip);
            ///* uses hard coded dictionary to get default genre
            Domain.DomainEntities.Weather rweather = weather;
            rweather.default_genre = weatherDictionary[rweather.type];
            //*/
            /* uses the database to get genre
            Domain.DomainEntities.Weather rweather = wdb.GetWeather(weather);
            rweather.description = weather.description;
            //*/
            return Ok(rweather);
        }
        [HttpGet]
        /// <summary>
        /// Get music genre based on the weather, derived from user's location
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public ActionResult<Models.Weather> GetGenre(Models.User client)
        {
            //authenticate

            IEnumerable<Preference> allPreference;
            Domain.DomainEntities.User user = udb.Find(client.username);

            ExternalApis.WeatherApi weatherApi = new ExternalApis.WeatherApi();
            Domain.DomainEntities.Weather weather = weatherApi.GetWeatherByLocation(user.location);
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
        /// <summary>
        /// Update user preference, dependent on user input
        /// </summary>
        /// <param name="client"></param>
        /// <param name="preference"></param>
        /// <returns></returns>
        public ActionResult UpdatePreference (Models.UserPreference userPreference)
        {
            var user = udb.Find(userPreference.username);
            var weather = wdb.GetWeather(ModelMapper.Map(userPreference.asWeather()));
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
        /// <summary>
        /// Remove user preference based on user input
        /// </summary>
        /// <param name="client"></param>
        /// <param name="preference"></param>
        /// <returns></returns>
        public ActionResult RemovePreference (Models.UserPreference userPreference)
        {
            var user = udb.Find(userPreference.username);
            var weather = wdb.GetWeather(ModelMapper.Map(userPreference.asWeather()));
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