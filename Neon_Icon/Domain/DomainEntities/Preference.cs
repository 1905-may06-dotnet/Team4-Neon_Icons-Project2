using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DomainEntities
{
    public class Preference
    {
        public int preference_id { get; set; }
        public int user_id { get; set; }
        public int weather_id { get; set; }
        public string genre { get; set; }
    }
}
