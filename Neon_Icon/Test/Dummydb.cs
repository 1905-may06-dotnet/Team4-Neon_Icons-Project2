using System.Collections.Generic;
using Domain.Repositories;
using Moq;
using Domain.DomainEntities;
using System.Linq;

namespace Test
{
    public class Dummydb
    {
        public Mock<IUserRepository> mockUser;
        public Mock<IPreferenceRepository> mockPreference;
        public Mock<IWeatherRepository> mockWeather;

        public Dummydb()
        {

            this.mockUser = new Mock<IUserRepository>();
            this.mockPreference = new Mock<IPreferenceRepository>();
            this.mockWeather = new Mock<IWeatherRepository>();

            IList<Location> locations = new List<Location>()
            {
                new Location
                {
                    id = 0,
                    zip = "zip0"
                }
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
                    location = locations.Where(x => x.id == 0).FirstOrDefault(),
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

        }



    }
}
