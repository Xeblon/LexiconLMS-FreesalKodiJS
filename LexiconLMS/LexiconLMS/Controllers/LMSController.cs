using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LexiconLMS.Controllers
{
    public class LMSController : Controller
    {
        // [Authorize(Roles = "")]
        // GET: LMS
        public ActionResult Index()
        {
            return View();
        }

        // COURSE HOME PAGE
        public ActionResult Course()
        {
            return View();
        }

        // STUDENT PROFILE PAGE
        public ActionResult Student()
        {
            return View();
        }

        // LISTING OF ALL COURSES PER ADMIN PAGE
        public ActionResult Courses()
        {
            return View();
        }

        // ADD USER OR COURSE
        public ActionResult AdminPage()
        {
            return View();
        }

        // THE HAND IN PAGE ON ADMIN SIDE
        public ActionResult Handedin()
        {
            return View();
        }

        // THE ASSIGNMENT PAGE STUDENT SIDE
        public ActionResult Assignments()
        {
            return View();
        }

        // THE SCHEDUAL PAGE
        public ActionResult Schedual()
        {
            return View();
        }

        // THE SHARED FILES PAGE
        public ActionResult SharedFiles()
        {
            return View();
        }
    }
}