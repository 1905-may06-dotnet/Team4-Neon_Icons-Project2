using System;
using System.Collections.Generic;
using System.Text;
using Domain.Apis;
using Domain.DomainEntities;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace ExternalApis
{
    public class WeatherApi : IWeatherApi
    {
        Uri BaseUri = new Uri("http://api.openweathermap.org/data/2.5/weather/");
        string key = "6074eaf3e50f0388ead6efd096db41ad";

        public Weather GetWeatherByLocation(Location location)
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = BaseUri;
                var response = client.GetAsync($"?zip={location.zip}&APPID={key}");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {

                    var data = result.Content.ReadAsStringAsync();
                    data.Wait();
                    string weatherdata = data.Result;
                    JObject weatherObject = JObject.Parse(weatherdata);
                    JToken results = weatherObject["weather"].Children().ToList().FirstOrDefault();

                    WeatherJSON weatherJson = results.ToObject<WeatherJSON>();
                    Weather weather = new Weather() { type = weatherJson.main, description = weatherJson.description };


                    return weather;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
