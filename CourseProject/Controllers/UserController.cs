using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseProject.Models;
using CourseProject.Helpers;
using Repositories;
using DataAccess;

namespace CourseProject.Controllers
{
    public class UserController : Controller
    {
      [HttpGet]
        public ActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            UserRepository repo = new UserRepository();
            User user = repo.GetUserByNameAndPassword(model.Username, model.Password);
            if (user != null)
            {
                LoginUserSession.Current.SetCurrentUser(user.ID, user.Username, user.Username == "admin");
                return RedirectToAction("Index", "Home");
            }
            return Login();
        }
        [HttpGet]
        public ActionResult Register()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(LoginViewModel model)
        {
            UserRepository repo = new UserRepository();
            User user = repo.GetUserByName(model.Username);
            if (user == null)
            {
                user = new User();
                user.Username = model.Username;
                repo.RegisterUser(user,model.Password);
                LoginUserSession.Current.SetCurrentUser(user.ID, user.Username, user.Username == "admin");
                TempData["Message"] = "successfully registered";


                //TODO: Doesn't add to database
                return RedirectToAction("Index", "Home");

            }
            TempData["ErrorMessage"] = "Failed to register";
            return Register();
        }

        public ActionResult Logout()
        {
            LoginUserSession.Current.Logout();
            return RedirectToAction("Index", "Home");
        }

    }
}