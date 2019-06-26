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
        public WeatherTest(IWeatherRepository wdb)
        {
            this.wdb = wdb;
        }

        [TestMethod]
        public void Create_validWeather_NotNull()
        {
            Domain.DomainEntities.Weather testWeather = new Domain.DomainEntities.Weather();
            testWeather.type = "testType";
            testWeather.description = "testDescription";
            testWeather.default_genre = "testGenre";
            wdb.CreateWeather(testWeather);
            Assert.IsNotNull(wdb.GetWeather(testWeather));
        }

        [TestMethod]
        public void Delete_validWeather_Null()
        {
            Domain.DomainEntities.Weather testWeather = new Domain.DomainEntities.Weather();
            testWeather.type = "testType";
            testWeather.description = "testDescription";
            testWeather.default_genre = "testGenre";
            wdb.DeleteWeather(wdb.GetWeather(testWeather));
            Assert.IsNull(wdb.GetWeather(testWeather));
        }

    }
}
