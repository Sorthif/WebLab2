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
            var User = HttpContext.Session.GetString("Admin");
            if (User != null)
            {
                return Redirect("/Admin/Index/");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Index(string User, string Password)
        {


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