using System;
using System.Collections.Generic;
using System.Text;
using Domain.DomainEntities;

namespace Domain.Repositories
{
    public interface IWeatherRepository
    {
        void CreateWeather(Weather weather);
        IEnumerable<Weather> GetWeather();
        Weather GetWeather(int id);
        Weather GetWeather(Weather type);
        void DeleteWeather(Weather weather);
    }
}
