using System;
using System.Collections.Generic;
using System.Text;
using Data.Repositories;
using Domain.DomainEntities;
using Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test
{
    [TestClass]
    public class PreferenceTest
    {
        private readonly IPreferenceRepository pdb;
        private readonly IUserRepository udb;
        private readonly IWeatherRepository wdb;
        public PreferenceTest()
        {
            pdb = new PreferenceRepository();
            udb = new UserRepository();
            wdb = new WeatherRepository();
        }

        [TestMethod]
        public void SetPreference_validPreference_True()
        {
            Domain.DomainEntities.User testUser = new Domain.DomainEntities.User();
            testUser.username = "backendTest";
            testUser.password = "password";
            testUser.location = "98908";
            udb.Create(testUser);

            Domain.DomainEntities.Weather testWeather = new Domain.DomainEntities.Weather();
            testWeather.type = "testType";
            testWeather.description = "testDescription";
            testWeather.default_genre = "testGenre";
            wdb.CreateWeather(testWeather);

            Domain.DomainEntities.Preference testPreference = new Domain.DomainEntities.Preference();
            testPreference.genre = "testGenre";
            testPreference.weather_id = wdb.GetWeather(testWeather).weather_id;
            testPreference.user_id = udb.Find(testUser.username).id;
            pdb.SetPreference(testPreference);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void GetPreferences_Nothing_True()
        {
            Domain.DomainEntities.User testUser = udb.Find("backendTest");
            var preferences = pdb.GetPreferences(testUser.id);
            foreach (var p in preferences)
            {
                if (p.genre == "testGenre")
                {
                    Assert.IsTrue(true);
                }
            }

        }
        [TestMethod]
        public void DeletePreference_validPreference_Null()
        {

            Domain.DomainEntities.Preference testPreference = new Domain.DomainEntities.Preference();
            Domain.DomainEntities.User testUser = udb.Find("backendTest");
            var preferences = pdb.GetPreferences(testUser.id);
            foreach (var p in preferences)
            {
                if (p.genre == "testGenre")
                {
                    testPreference = p;
                }
            }

            pdb.DeletePreference(testPreference);
            udb.Delete(testUser);

            Domain.DomainEntities.Weather testWeather = new Domain.DomainEntities.Weather();
            testWeather.type = "testType";
            testWeather.description = "testDescription";
            testWeather.default_genre = "testGenre";
            wdb.DeleteWeather(wdb.GetWeather(testWeather));

            Assert.IsTrue(true);

        }
    }
}
