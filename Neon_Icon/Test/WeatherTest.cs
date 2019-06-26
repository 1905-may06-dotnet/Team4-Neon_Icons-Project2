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
        public void Create_validWeather_True()
        {
            Domain.DomainEntities.Weather testWeather = new Domain.DomainEntities.Weather();
            testWeather.type = "testType";
            testWeather.description = "testDescription";
            testWeather.default_genre = "testGenre";
            wdb.CreateWeather(testWeather);
            Assert.IsTrue(wdb.GetWeather(testWeather).description == "testDescription");
        }
        [TestMethod]
        public void GetWeather_Nothing_True()
        {
            var weathers = wdb.GetWeather();
            foreach (var w in weathers)
            {
                if (w.description == "testDescription")
                {
                    Assert.IsTrue(true);
                }
            }
        }
        [TestMethod]
        public void getWeather_weatherId_True()
        {
            Domain.DomainEntities.Weather testWeather = new Domain.DomainEntities.Weather();
            testWeather.type = "testType";
            testWeather.description = "testDescription";
            testWeather.default_genre = "testGenre";
            Domain.DomainEntities.Weather realTest = wdb.GetWeather(testWeather);
            Assert.IsTrue(wdb.GetWeather(realTest.weather_id).description == "testDescription");
        }
        [TestMethod]
        public void GetWeather_weatherobject_True()
        {
            Domain.DomainEntities.Weather testWeather = new Domain.DomainEntities.Weather();
            testWeather.type = "testType";
            testWeather.description = "testDescription";
            testWeather.default_genre = "testGenre";
            Assert.IsTrue(wdb.GetWeather(testWeather).description == "testDescription");
        }
        [TestMethod]
        public void Delete_validWeather_True()
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
