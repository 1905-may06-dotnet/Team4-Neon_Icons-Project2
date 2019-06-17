using System;
using System.Collections.Generic;
using System.Text;
using Domain.Repositories;

namespace Test
{
    class WeatherTest
    {
        private readonly IWeatherRepository wdb;
        WeatherTest(IWeatherRepository wdb)
        {
            this.wdb = wdb;
        }
    }
}
