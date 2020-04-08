using CarsStore.Data;
using CarsStore.Interfaces;
using CarsStore.Models;
using CarsStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsStore.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAllUsers allUsers;

        public LoginController(IAllUsers allUsers)
        {
            this.allUsers = allUsers;
        }

        public ViewResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(UserInfo user)
        {
            if (ModelState.IsValid)
            {
                allUsers.AddUser(user);
                return LocalRedirectPermanent("~/Home/Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Authorization(UserInfo user)
        {
            if (ModelState.IsValid)
                if (allUsers.LogAccess(user))
                    return LocalRedirectPermanent("~/Home/Index");

            return View();
        }

        public ViewResult Authorization()
        {
            return View();
        }
    }
}
