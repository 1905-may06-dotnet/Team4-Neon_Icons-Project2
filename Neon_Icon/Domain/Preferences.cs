using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Preferences
    {
        public int preferences_id { get; set; }
        public int user_id { get; set; }
        public int weather_id { get; set; }
        public int genre_id { get; set; }
    }
}
