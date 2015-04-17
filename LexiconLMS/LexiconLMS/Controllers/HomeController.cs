using System;
using System.Collections.Generic;
using System.Linq;
using LexiconLMS.Models;
using LexiconLMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace LexiconLMS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        List<GroupUsersViewModels> userGroupVM = new List<GroupUsersViewModels>();

        public ActionResult Index()
        {   
            var groups = db.Users.Include(s => s.Groups);
            var userId = User.Identity.GetUserId();
           
            var userInfo = db.Users
                .Where(uid => uid.Id == userId)
                .Select(t => t.Groups)
                .ToList();
            var x = "";
            foreach (var item in userInfo)
            {
                foreach (var group in item)
                {
                    x = group.ScheduleId.ToString();
                }
                
            }

            ViewBag.uId = x;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult CreateUserPrel()
        {
            return View();
        }


    }
}