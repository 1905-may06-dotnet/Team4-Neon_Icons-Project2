using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    //TODO: Do we still need the location entity and class since we are querying OpenWeather just by zip code (a string)?

    public partial class Locations
    {
        public Locations()
        {
            Users = new HashSet<Users>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
