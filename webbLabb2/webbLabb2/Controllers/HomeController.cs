using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webbLabb2.Models;

namespace webbLabb2.Controllers
{
    public class HomeController : Controller
    {
        private readonly webbLabb2Context _context;

        public HomeController(webbLabb2Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Article.ToListAsync());
        }

        [HttpGet]
        public IActionResult Admin()
        {
            return View();
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
