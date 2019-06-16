using System;
using System.Collections.Generic;
using System.Text;
using Domain.DomainEntities;
using Domain.Repositories;
using System.Linq;
using Data.Entities;

namespace Data.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        public IEnumerable<Domain.DomainEntities.Weather> GetWeather()
        {
            return DatabaseInstance.GetContext().Weather.Select(x => Mapper.Map(x));
        }

        public Domain.DomainEntities.Weather GetWeather(int id)
        {
            return Mapper.Map(DatabaseInstance.GetContext().Weather.Where(x => x.Id == id).FirstOrDefault());
        }

        public Domain.DomainEntities.Weather GetWeather(Domain.DomainEntities.Weather type)
        {
            return Mapper.Map(DatabaseInstance.GetContext().Weather.Where(x => x.Type == type.type).FirstOrDefault());
        }
    }
}