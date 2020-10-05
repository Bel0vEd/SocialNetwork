using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
            ViewData["Users"] = _userManager.Users.ToList();
            if (id == null)
            {
                foreach (var item in ViewData["Users"] as List<User>)
                {
                    if (User.Identity.Name == item.UserName)
                    {
                        id = item.ProfileLink.ToString();
                    }
                }
                RouteData.Values.Add("id", id);
            }
            ViewData["Comments"] = db.Comments.Where(a => a.ProfileLink.ToString().Contains(id)).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            var sender = "";
            foreach (var item in db.Users.ToList())
            {
                if (item.UserName == User.Identity.Name)
                {
                    sender = item.FirstName + " " + item.SecondName;
                    comment.SenderProfileLink = item.ProfileLink;
                }
            }
            comment.Sender = sender;
            comment.Data = DateTime.Now;
            db.Comments.Add(comment);
            await db.SaveChangesAsync();
            return Redirect("Wall/" + comment.ProfileLink);
        }
        public IActionResult DeleteComment(int id)
        {
            Comment comment = db.Comments.Where(comment => comment.Id == id).FirstOrDefault();
            int goo = comment.ProfileLink;
            db.Comments.Remove(comment);
            db.SaveChanges();
            while (comment != null)
            {
                comment = db.Comments.Where(comment => comment.ParentId == id).FirstOrDefault();
                if (comment != null)
                    db.Comments.Remove(comment);
                db.SaveChanges();
            }
            return Redirect("~/Profile/Wall/" + goo);
        }
    }
}
