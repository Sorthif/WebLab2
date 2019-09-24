using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webbLabb2.Models;

namespace webbLabb2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

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
                return Redirect();
            }
        }

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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
