using System;
using System.Collections.Generic;
using System.Text;
using Data.Repositories;
using Domain.DomainEntities;
using Domain.Repositories;
using Moq;

namespace Test
{
    class PreferenceTest
    {
        private readonly IPreferenceRepository pdb;
        PreferenceTest()
        {
            pdb = new Data.Repositories.PreferenceRepository();
        }

        public void CreatePreference_validPreference_NotNull()
        {

        }
        public void DeletePreference_validPreference_Null()
        {

        }
    }
}
