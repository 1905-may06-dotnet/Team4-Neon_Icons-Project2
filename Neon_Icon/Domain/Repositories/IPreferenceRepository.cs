using System;
using System.Collections.Generic;
using System.Text;
using Domain.DomainEntities;

namespace Domain.Repositories
{
    public interface IPreferenceRepository
    {
        void SetPreference(Preference preference);
        IEnumerable<Preference> GetPreferences(int userid);
        void DeletePreference(Preference preference);
    }
}


