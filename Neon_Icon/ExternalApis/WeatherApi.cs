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
        //The base URI and key enable us to query the API enpoint
        Uri BaseUri = new Uri("http://api.openweathermap.org/data/2.5/weather/");
        string key = "6074eaf3e50f0388ead6efd096db41ad";

        public Weather GetWeatherByLocation(string zip)
        {
            //Initialize the HTTP context and query the API
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = BaseUri;
                var response = client.GetAsync($"?zip={zip}&APPID={key}");
                response.Wait();

                var result = response.Result;

                //If the result returns a 2XX status code
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync();
                    data.Wait();

                    string weatherdata = data.Result;

                    JObject weatherObject = JObject.Parse(weatherdata);

                    JToken results = weatherObject["weather"].Children().ToList().FirstOrDefault();
                    
                    //Create a WeatherJSON C# object for back-end processing
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
