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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(bool loggedIn)
        {
            if (loggedIn == true)
            {
                return Redirect("/Admin/Index/");
            }
            else
            {
                return Redirect("/loginscreen/Index/");
            }
        }
    }
}