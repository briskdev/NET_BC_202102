using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsLogic;
using NewsLogic.Managers;
using NewsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Controllers
{
    public class UserController : Controller
    {
        private UserManager manager = new UserManager();

        [HttpGet]
        public IActionResult Register()
        {
            if(HttpContext.Session.IsSignedIn())
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    manager.Register(model.Username, model.Email, model.Password);

                    return RedirectToAction("Login");
                }
                catch(LogicException ex)
                {
                    ModelState.AddModelError("validation", ex.Message);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.IsSignedIn())
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserModel model)
        {
            if(ModelState.IsValid)
            {
                var user = manager.GetUser(model.Username, model.Password);
                if(user == null)
                {
                    ModelState.AddModelError("validation", "Incorrect username/password!");
                }
                else
                {
                    HttpContext.Session.SetUsername(user.Username);
                    HttpContext.Session.SetIsAdmin(user.IsAdmin);

                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
