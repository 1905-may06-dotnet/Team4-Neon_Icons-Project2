using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DomainEntities;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : Controller
    {
        private readonly IUserRepository db;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginUser(Models.User client)
        {
            var validUser = db.Find(client.username);

            if (validUser != null)
            {
                if (validUser.password == client.password)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("password");
                }
            }
            else
            {
                return BadRequest("username");
            }
        }

        [HttpPost]
        public ActionResult RegisterUser(Models.User client)
        {
            User newUser = new User();

            newUser.username = client.username;
            newUser.password = client.password;

            //Use this location to retrieve the forecast
            Location newLocation = new Location();
            newLocation.zip = client.location;
            newUser.location = newLocation;

            var existingUser = db.Find(client.username);

            if (existingUser == null)
            {
                db.Create(newUser);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        
        }

    //public IActionResult GetWeatherForUser(User user, Weather weather)
    //{
    //    //var currentweather = new 

    //    //TODO get weather for username
    //    return null;
    //}

    //public IActionResult GetNextSong(string username)
    //{
    //    //TODO get next song based on username preferences


    //    return null;
    //}
}
