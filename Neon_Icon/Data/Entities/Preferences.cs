using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Preferences
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WeatherId { get; set; }
        public string Genre { get; set; }

        public virtual Users User { get; set; }
        public virtual Weather Weather { get; set; }
    }
}
