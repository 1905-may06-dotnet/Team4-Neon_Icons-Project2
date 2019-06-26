using System;
using System.Collections.Generic;
using System.Text;
using Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class WeatherTest
    {
        private readonly IWeatherRepository wdb;
        public WeatherTest()
        {
            wdb = new Data.Repositories.WeatherRepository();
        }

        [TestMethod]
        public void Create_validWeather_NotNull()
        {
            Domain.DomainEntities.Weather testWeather = new Domain.DomainEntities.Weather();
            testWeather.type = "testType";
            testWeather.description = "testDescription";
            testWeather.default_genre = "testGenre";
            wdb.CreateWeather(testWeather);
            Assert.IsTrue(wdb.GetWeather(testWeather).description == "testDescription");
        }

        [TestMethod]
        public void Delete_validWeather_Null()
        {
            Domain.DomainEntities.Weather testWeather = new Domain.DomainEntities.Weather();
            testWeather.type = "testType";
            testWeather.description = "testDescription";
            testWeather.default_genre = "testGenre";
            wdb.DeleteWeather(wdb.GetWeather(testWeather));
            Assert.IsTrue(wdb.GetWeather(testWeather) == null);
        }

    }
}
