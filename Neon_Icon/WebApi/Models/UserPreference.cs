using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class UserPreference
    {
        public string username { get; set; }
        public string password { get; set; }
        public string location { get; set; }

        public string type { get; set; }
        public string description { get; set; }
        public string default_genre { get; set; }

        public Weather asWeather()
        {
            Weather weather = new Weather() { Type = type, Description = description, DefaultGenre = default_genre };
            return weather;
        }
    }
}
