using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DomainEntities
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int location_id { get; set; }
    }
}
