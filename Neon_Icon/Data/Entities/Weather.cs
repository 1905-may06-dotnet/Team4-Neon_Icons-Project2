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
        public int DefaultGenre { get; set; }

        public virtual Genre DefaultGenreNavigation { get; set; }
        public virtual ICollection<Preferences> Preferences { get; set; }
    }
}
