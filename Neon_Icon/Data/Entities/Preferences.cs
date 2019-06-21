using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public partial class Preferences
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        [ForeignKey("Weather")]
        public int WeatherId { get; set; }
        public string Genre { get; set; }

        public virtual Users User { get; set; }
        public virtual Weather Weather { get; set; }
    }
}
