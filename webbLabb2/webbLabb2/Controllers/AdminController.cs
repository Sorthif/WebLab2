﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace webbLabb2.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            //Checks if a user has the Admin key.
            var User = HttpContext.Session.GetString("Admin");

            if (User != null)
            {
                return View();
            }
            else
            {
                return Redirect("/loginscreen/Index/");
            }
        }
    }
}