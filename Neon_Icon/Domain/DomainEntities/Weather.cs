using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DomainEntities
{
    public class Weather
    {
        public int weather_id { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string default_genre { get; set; }
    }
}