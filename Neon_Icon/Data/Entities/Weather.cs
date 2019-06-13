using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Weather
    {
        public Weather()
        {
            Preferences = new HashSet<Preferences>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string DefaultGenre { get; set; }

        public virtual ICollection<Preferences> Preferences { get; set; }
    }


    /*
   Thunderstorm -- 	african percusion
   Drizzle -- classical
   Rain -- r&b
   Snow -- christmas //immutable
   Mist -- jazz
   Smoke -- cyberpunk
   Haze -- edm
   Dust -- cowboy western //immutable
   Fog -- punk
   Sand -- arab pop
   Ash -- rap
   Squall -- rock
   Tornado -- metal
   Clear -- pop
   Clouds -- indie
    */
}
