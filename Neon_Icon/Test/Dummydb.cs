using System.Collections.Generic;
using Data.Repositories;
using Moq;
using Domain.DomainEntities;
using System.Linq;

namespace Test
{
    public class Dummydb
    {
        public Mock<UserRepository> mockUser;
        public Mock<PreferenceRepository> mockPreference;
        public Mock<WeatherRepository> mockWeather;

        public Dummydb()
        {

            this.mockUser = new Mock<UserRepository>();
            this.mockPreference = new Mock<PreferenceRepository>();
            this.mockWeather = new Mock<WeatherRepository>();

            IList<string> locations = new List<string>()
            {
                "zip0"
            };

            
            IList<Weather> weathers = new List<Weather>()
            {
                new Weather
                {
                    weather_id = 0,
                    default_genre = "default_genre0",
                    description = "description0",
                    type = "type0"
                }
            };

            IList<User> users = new List<User>()
            {
                new User
                {
                    id = 0,
                    location = locations[0],
                    username = "testUsername0",
                    password = "testPassword0"
                }
            };

            IList<Preference> preferences = new List<Preference>()
            {
                new Preference
                {
                    preference_id = 0,
                    genre = "testgenre0",
                    user_id = 0,
                    weather_id = 0
                }
            };

            mockUser.Setup(mr => mr.Find(It.IsAny<int>())).Returns((int i) => users.Where(x => x.id == i).Single());
            mockPreference.Setup(mr => mr.GetPreferences(It.IsAny<int>())).Returns((int i) => preferences.Where(x => x.preference_id == i));
            mockWeather.Setup(mr => mr.GetWeather(It.IsAny<int>())).Returns((int i) => weathers.Where(x => x.weather_id == i).Single());

        }



    }
}
