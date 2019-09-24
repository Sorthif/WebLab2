using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webbLabb2.Controllers
{
    public class LoginScreenController : Controller
    {

        [HttpGet]
        public IActionResult LoginScreen()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginScreen(string User, string Password)
        {
            if (User == Password)
            {
                return Redirect("/Home/Admin");
            }
            else
            {
                return View();
            }
        }

    }
}