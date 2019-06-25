using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public partial class Users
    {
        public Users()
        {
            Preferences = new HashSet<Preferences>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Preferences> Preferences { get; set; }
    }
}
