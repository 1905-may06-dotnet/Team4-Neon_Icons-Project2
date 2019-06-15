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
        public ActionResult LoginUser(IFormCollection collection, Models.User client)
        {
            ViewData["Message"] = "";

            var validUser = db.Find(client.username);

            if (validUser != null)
            {
                if (validUser.password == client.password)
                {
                    return View();
                }
                else
                {
                    ViewData["Message"] = "The password you entered is incorrect.";
                    return View(/*TODO landing page goes here*/);
                }
            }
            else
            {
            ViewData["Message"] = "This username does not exist.";
            return View();
            }
        }

        [HttpPost]
        public ActionResult RegisterUser(IFormCollection collection, Models.User client)
        {
            User newUser = new User();

            newUser.id = client.id;
            newUser.username = client.username;
            newUser.password = client.password;

            //Use this location to retrieve the forecast
            Location newLocation = new Location();
            newLocation.zip = client.location;

            var existingUser = db.Find(client.username);

            if (existingUser == null)
            {
                db.Create(newUser);
                return View(/*TODO Landing Page Goes Here*/);
            }
            else
            {
                ViewData["Message"] = "This username is taken";
                return View();
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
