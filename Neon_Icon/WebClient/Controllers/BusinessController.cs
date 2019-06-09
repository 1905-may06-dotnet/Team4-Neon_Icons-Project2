using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class BusinessController : Controller
    {
        public IActionResult ValidateUser ()
        {
            //TODO check username/password
            return null;
        }

        public IActionResult GetWeatherForUser (string username)
        {
            //TODO get weather for username
            return null;
        }

        public IActionResult GetNextSong (string username)
        {
            //TODO get next song based on username preferences
            return null;
        }
    }
}