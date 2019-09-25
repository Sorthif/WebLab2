using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace webbLabb2.Controllers
{
    public class LoginScreenController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            //Checks if a user is logged in with the Admin key.
            var User = HttpContext.Session.GetString("Admin");
            if (User == null)
            {
                //If there are no admin users.
                return View();
            }
            return Redirect("/Admin/Index/");
        }

        [HttpPost]
        public IActionResult Index(string User, string Password)
        {
            //Database user and password should be checked here.

            //If the login is correct, go to admin page, else refresh page.
            if (User == Password)
            {
                HttpContext.Session.SetString("Admin", User);

                return Redirect("/Admin/Index/");
            }
            else
            {
                return View();
            }
        }
    }
}