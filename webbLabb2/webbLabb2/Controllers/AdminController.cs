using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webbLabb2.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Admin(bool loggedIn)
        {
            if (loggedIn == true)
            {
                return Redirect("/home/Admin/");
            }
            else
            {
                return Redirect("/home/loginscreen/");
            }
        }
    }
}