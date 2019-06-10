using System;
using System.Collections.Generic;
using System.Text;
using Domain.DomainEntities;
using Domain.Repositories;

namespace Data.Repositories
{
    class WeatherRepository : IWeatherRepository
    {
        public IEnumerable<Weather> GetWeather()
        {
            throw new NotImplementedException();
        }

        public Weather GetWeather(int id)
        {
            throw new NotImplementedException();
        }

        public Weather GetWeather(Weather type)
        {
            throw new NotImplementedException();
        }
    }
}
