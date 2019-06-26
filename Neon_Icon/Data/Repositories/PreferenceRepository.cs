using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Domain.DomainEntities;
using Domain.Repositories;

namespace Data.Repositories
{
    public class PreferenceRepository : IPreferenceRepository
    {
        public virtual void DeletePreference(Preference preference)
        {
            DatabaseInstance.GetContext().Remove(Mapper.Map(preference));
            DatabaseInstance.GetContext().SaveChanges();
        }
        public virtual IEnumerable<Preference> GetPreferences(int userid)
        {
            return Mapper.Map(DatabaseInstance.GetContext().Preferences.Where(x => x.UserId == userid));
        }
        public virtual void SetPreference(Preference preference)
        {
            var check = DatabaseInstance.GetContext().Preferences.Where(x => x.UserId == preference.user_id && x.WeatherId == preference.weather_id).FirstOrDefault();
            if (check == null) {
                DatabaseInstance.GetContext().Add(Mapper.Map(preference));
                DatabaseInstance.GetContext().SaveChanges();
            }
            else
            {
                preference.preference_id = check.Id;
                DatabaseInstance.GetContext().Update(Mapper.Map(preference));
                DatabaseInstance.GetContext().SaveChanges();
            }
        }
    }
}
