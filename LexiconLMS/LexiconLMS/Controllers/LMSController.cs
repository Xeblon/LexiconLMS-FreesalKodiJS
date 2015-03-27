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
    }
}