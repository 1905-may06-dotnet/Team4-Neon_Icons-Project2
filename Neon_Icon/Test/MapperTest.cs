using System;
using System.Collections.Generic;
using System.Text;
using Domain.DomainEntities;
using Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;


namespace Test
{
    [TestClass]
    public class MapperTest
    {
        Domain.DomainEntities.Preference domp = new Domain.DomainEntities.Preference();
        Data.Entities.Preferences dap = new Data.Entities.Preferences();

        Domain.DomainEntities.User domu = new Domain.DomainEntities.User();
        Data.Entities.Users dau = new Data.Entities.Users();

        Domain.DomainEntities.Weather domw = new Domain.DomainEntities.Weather();
        Data.Entities.Weather daw = new Data.Entities.Weather();
        [TestMethod]
        public void PrefMapTest()
        {
            Assert.AreEqual(domp.genre,Mapper.Map(domp).Genre);
            Assert.AreEqual(domp.preference_id, Mapper.Map(domp).Id);
            Assert.AreEqual(domp.user_id, Mapper.Map(domp).UserId);
            Assert.AreEqual(domp.weather_id, Mapper.Map(domp).WeatherId);
        }
        [TestMethod]
        public void ReversePrefMapTest()
        {
            Assert.AreEqual(dap.Genre, Mapper.Map(domp).Genre);
            Assert.AreEqual(dap.Id, Mapper.Map(domp).Id);
            Assert.AreEqual(dap.UserId, Mapper.Map(domp).UserId);
            Assert.AreEqual(dap.WeatherId, Mapper.Map(domp).WeatherId);
        }
        [TestMethod]
        public void UserMapTest()
        {
            Assert.AreEqual(domu.username, Mapper.Map(dau).username);
            Assert.AreEqual(domu.password, Mapper.Map(dau).password);
            Assert.AreEqual(domu.location, Mapper.Map(dau).location);
            Assert.AreEqual(domu.id, Mapper.Map(dau).id);
        }
        [TestMethod]
        public void ReverseMapTest()
        {
            Assert.AreEqual(dau.Id, Mapper.Map(domu).Id);
            Assert.AreEqual(dau.Location, Mapper.Map(domu).Location);
            Assert.AreEqual(dau.Username, Mapper.Map(domu).Username);
            Assert.AreEqual(dau.Password, Mapper.Map(domu).Password);
        }
        [TestMethod]
        public void WeatherMapTest()
        {
            Assert.AreEqual(domw.default_genre, Mapper.Map(daw).default_genre);
            Assert.AreEqual(domw.description, Mapper.Map(daw).description);
            Assert.AreEqual(domw.type, Mapper.Map(daw).type);
            Assert.AreEqual(domw.weather_id, Mapper.Map(daw).weather_id);
        }
        [TestMethod]
        public void ReverseWeatherTest()
        {
            Assert.AreEqual(daw.DefaultGenre, Mapper.Map(domw).DefaultGenre);
            Assert.AreEqual(daw.Description, Mapper.Map(domw).Description);
            Assert.AreEqual(daw.Id, Mapper.Map(domw).Id);
            Assert.AreEqual(daw.Type, Mapper.Map(domw).Type);
        }


    }
}
