using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using webbLabb2.Models;
using webbLabb2.Controllers;

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
        public IActionResult Index(string userName, string UserPasswordHash)
        {
            if (false)
            {
                HttpContext.Session.SetString("Admin", userName);

                return Redirect("/Admin/Index/");
            }
            else
            {
                return View();
            }
        }

    }
}