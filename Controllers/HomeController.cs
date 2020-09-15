using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialNetwork.Models;

namespace SocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        UserManager<User> _userManager;
        public HomeController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index() => View(_userManager.Users.ToList());

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
