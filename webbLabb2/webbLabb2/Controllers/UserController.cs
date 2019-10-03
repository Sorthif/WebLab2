using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webbLabb2.Models;

namespace webbLabb2.Controllers
{
    public class UserController : Controller
    {
        private readonly webbLabb2Context _context;

        public UserController(webbLabb2Context context)
        {
            _context = context;
        }


        // GET: User
        public ActionResult VerifyUser(string userName, string UserPasswordHash)
        {
            User user = _context.Find<User>(userName);
            
            if (user != null && user.PasswordUsernameHash == UserPasswordHash)
            {
                HttpContext.Session.SetString("Admin", userName);
                return Redirect("/Admin/Index/");
            } else
            {
                return Redirect("/LoginScreen/");
            }

        }

    }
}