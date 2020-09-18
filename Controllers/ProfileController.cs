using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SocialNetwork.Models;

namespace SocialNetwork.Controllers
{
    public class ProfileController : Controller
    {
        private ApplicationContext db;

        UserManager<User> _userManager;
        public ProfileController(UserManager<User> userManager, ApplicationContext context)
        {
            db = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(db.Comments.ToList());
        }
        public IActionResult Wall(string id)
        {
            ViewData["Comments"] = db.Comments.ToList();
            ViewData["Users"] = _userManager.Users.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            var sender = 0;
            foreach (var item in db.Users.ToList())
            {
                if (item.UserName == User.Identity.Name)
                    sender = item.ProfileLink;
            }
            comment.ProfileLinkSend = sender;
            comment.Data = DateTime.Now;
            db.Comments.Add(comment);
            await db.SaveChangesAsync();
            return RedirectToAction("Wall");
        }
    }
}
