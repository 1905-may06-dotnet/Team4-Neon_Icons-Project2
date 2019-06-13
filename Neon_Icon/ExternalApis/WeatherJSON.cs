using System;
using System.Collections.Generic;
using System.Text;
using Domain = Domain.DomainEntities;

namespace ExternalApis
{
    class WeatherJSON
    {
        public string main { get; set; }
        public string description { get; set; }
    }
}
