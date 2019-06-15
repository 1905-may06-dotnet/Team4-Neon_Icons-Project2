using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Weather
    {
        public int Type { get; set; }
        public string Description { get; set; }
        public string DefaultGenre { get; set; }
    }
}
