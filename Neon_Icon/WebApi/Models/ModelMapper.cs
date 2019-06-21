using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public static class ModelMapper
    {
        public static Weather Map (Domain.DomainEntities.Weather weather)
        {
            if (weather == null) return null;

            Weather w = new Weather() { Type = weather.type, Description = weather.description, DefaultGenre = weather.default_genre };

            return w;
        }
        public static Domain.DomainEntities.Weather Map(Weather weather)
        {
            if (weather == null) return null;

            Domain.DomainEntities.Weather w = new Domain.DomainEntities.Weather() { type = weather.Type, description = weather.Description, default_genre = weather.DefaultGenre };

            return w;
        }
    }
}
