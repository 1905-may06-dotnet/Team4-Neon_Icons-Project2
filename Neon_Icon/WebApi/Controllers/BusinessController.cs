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
    ///<summary>\
    ///Methods for User parameters: Login/Register/UpdateLocation
    ///</summary>
    public class BusinessController : Controller
    {
        private readonly IUserRepository db;

        [HttpPost]
        [ValidateAntiForgeryToken]
        ///<summary>
        ///Check user for authenticity
        ///</summary>
        ///<param name="client"></param>
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
                    return Unauthorized("password");
                }
            }
            else
            {
                return Unauthorized("username");
            }
        }
        [HttpPost]
        /// <summary>
        ///Check if user already exists; on success, creates new user
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
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
                return Unauthorized();
            }
        }
        [HttpPut]
        /// <summary>
        /// Updates the default location of the user
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public IActionResult UpdateLocation(Models.User client)
        {
            User user = db.Find(client.username);
            user.location.zip = client.location;
            if (user != null)
            {
                db.UpdateLocation(user);
                return Ok();
            }
            else
            {
                return Unauthorized("username");
            }
        }
    }
}
