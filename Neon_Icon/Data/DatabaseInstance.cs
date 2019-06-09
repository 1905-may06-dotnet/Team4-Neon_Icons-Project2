using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    class DatabaseInstance
    {
        private static Entities.Context context;
        private DatabaseInstance () {}
        public static Entities.Context GetContext ()
        {
            if (context == null) { context = new Entities.Context(); }
            return context;
        }
    }
}
