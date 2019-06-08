using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Genre
    {
        public Genre()
        {
            Preferences = new HashSet<Preferences>();
            Weather = new HashSet<Weather>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Preferences> Preferences { get; set; }
        public virtual ICollection<Weather> Weather { get; set; }
    }
}
