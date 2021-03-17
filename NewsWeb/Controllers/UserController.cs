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
                    // user found, user is not null
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }
    }
}
