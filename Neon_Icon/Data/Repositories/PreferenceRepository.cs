using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Domain.DomainEntities;
using Domain.Repositories;

namespace Data.Repositories
{
    class PreferenceRepository : IPreferenceRepository
    {
        public void DeletePreference(Preference preference)
        {
            DatabaseInstance.GetContext().Remove(Mapper.Map(preference));
        }

        public IEnumerable<Preference> GetPreferences(int userid)
        {
            return Mapper.Map(DatabaseInstance.GetContext().Preferences.Where(x => x.UserId == userid).ToAsyncEnumerable().ToEnumerable());
        }

        public void SetPreference(Preference preference)
        {
            if (preference != null)
                DatabaseInstance.GetContext().Add(Mapper.Map(preference));
            else
                DatabaseInstance.GetContext().Update(Mapper.Map(preference));
        }
    }
}
