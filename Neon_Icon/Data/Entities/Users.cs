using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Users
    {
        public Users()
        {
            Preferences = new HashSet<Preferences>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? LocationId { get; set; }

        public virtual Locations Location { get; set; }
        public virtual ICollection<Preferences> Preferences { get; set; }
    }
}
