using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Weather
    {
        public int weather_id { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public int default_genre { get; set; }
    }
}
