using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Models;
using Forum.Services;
using Forum.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Authorize]
        public IActionResult Index()
        {
            string username = User.Identity.Name;

            User user = userService.GetByUsername(username);

            return View(new UserViewModel(user));
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create()
        {



            return RedirectToAction("Index", "User");
        }


    }
}
