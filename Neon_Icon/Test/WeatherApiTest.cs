using Domain.DomainEntities;
using Domain.Repositories;
using ExternalApis;
using WebApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Data.Repositories;

namespace Test
{
    //Naming convention for Test Cases:
    //[MethodTested_Argument_ExpectedBehavior]

    [TestClass]
    public class WeatherApiTest
    {
        private readonly IPreferenceRepository pdb;
        //private readonly IWeatherRepository wdb;
        //WeatherApiTest(IPreferenceRepository pdb, IWeatherRepository wdb)
        //{
        //    this.pdb = pdb;
        //    this.wdb = wdb;
        //}

        [TestMethod]
        public void GetWeatherByLocation_ValidZip_NotNull()
        {
            //checks if a weather object returned from the GetWeatherByLocation is null
            Weather testWeather = new Weather();
            string zipCheck = "94121"; //San Francisco, CA
            WeatherApi testWeatherApi = new WeatherApi();
            testWeather = testWeatherApi.GetWeatherByLocation(zipCheck);
            Assert.IsNotNull(testWeather);

        }
        
        [TestMethod]
        public void GetWeatherByLocation_InvalidZip_Null()
        {
            Weather testWeather = new Weather();
            string zipCheck = "94";
            WeatherApi testWeatherApi = new WeatherApi();
            testWeather = testWeatherApi.GetWeatherByLocation(zipCheck);
            Assert.IsNull(testWeather);

        }

        [TestMethod]
        public void CheckWeatherTypes_LINQ_True()
        {
            //This test checks if the returned weather type is in our weather entity.
            bool testPassed = false;
            string zipCheck = "78754"; //Austin TX
            Weather testWeather = new Weather();
            WeatherApi testWeatherApi = new WeatherApi();
            testWeather = testWeatherApi.GetWeatherByLocation(zipCheck);
            WeatherRepository wdb = new WeatherRepository();
            var types = wdb.GetWeather();
            foreach (var type in types)
            {
                if (testWeather.type == type.type)
                {
                    testPassed = true;
                }
            }

            Assert.IsTrue(testPassed);

        }
    }
}
