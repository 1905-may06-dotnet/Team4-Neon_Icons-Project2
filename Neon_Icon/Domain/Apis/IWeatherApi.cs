using System;
using System.Collections.Generic;
using System.Text;
using Domain.DomainEntities;

namespace Domain.Apis
{
    public interface IWeatherApi
    {
        Weather GetWeatherByLocation(Location location);
    }
}
