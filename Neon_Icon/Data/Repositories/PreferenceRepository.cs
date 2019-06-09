using System;
using System.Collections.Generic;
using System.Text;
using Domain.DomainEntities;
using Domain.Repositories;

namespace Data.Repositories
{
    class PreferenceRepository : IPreferenceRepository
    {
        public void DeletePreference(Preference preference)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Preference> GetPreferences(int userid)
        {
            throw new NotImplementedException();
        }

        public void SetPreference(Preference preference)
        {
            throw new NotImplementedException();
        }
    }
}
