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
        public virtual void CreateWeather(Domain.DomainEntities.Weather weather)
        {
            DatabaseInstance.GetContext().Add(Mapper.Map(weather));
            DatabaseInstance.GetContext().SaveChanges();
        }
        public virtual IEnumerable<Domain.DomainEntities.Weather> GetWeather()
        {
            return DatabaseInstance.GetContext().Weather.Select(x => Mapper.Map(x));
        }
        public virtual Domain.DomainEntities.Weather GetWeather(int id)
        {
            return Mapper.Map(DatabaseInstance.GetContext().Weather.Where(x => x.Id == id).FirstOrDefault());
        }
        public virtual Domain.DomainEntities.Weather GetWeather(Domain.DomainEntities.Weather type)
        {
            return Mapper.Map(DatabaseInstance.GetContext().Weather.Where(x => x.Type == type.type).FirstOrDefault());
        }
        public virtual void DeleteWeather(Domain.DomainEntities.Weather weather)
        {
            DatabaseInstance.GetContext().Remove(Mapper.Map(weather));
            DatabaseInstance.GetContext().SaveChanges();
        }
    }
}