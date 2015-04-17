using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LexiconLMS.Models;
using LexiconLMS.ViewModels;

namespace LexiconLMS.Controllers
{
    public class GroupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Groups
        public ActionResult Index()
        {
            var groups = db.Groups.Include(g => g.schedule);
            return View(groups.ToList());
        }

        // GET: Groups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }

            List<GroupUsersViewModels> GUVM = new List<GroupUsersViewModels>();


            //var us = db.Users.Single(u => u.Id == id);
            //foreach (ApplicationUser user in db.Users.Single(db.Groups.Single(g => g.Id == group.Id)))
            List<ApplicationUser> UG = group.Users.ToList();

            //foreach (var u in group.Users)
            //{
            //    try
            //    {
            //        if (u.Groups != null && u.Groups.Count > 0)
            //        {
            //            foreach (var g in u.Groups)
            //            {
            //                if (g.Id == group.Id)
            //                {
            //                    UG.Add(u);
            //                }
            //            }
            //        }
            //    }
                //catch (System.Data.Entity.Core.EntityCommandExecutionException)
                //{

                //    //UG = db.Users.Where(us => us.Groups.FirstOrDefault().Id == group.Id);
                //}
               
            //}
            //foreach (ApplicationUser user in GInfo.Where(u => u.Groups.FirstOrDefault().Id == group.Id))
            foreach (ApplicationUser user in UG)
            {
                GUVM.Add(
                    new ViewModels.GroupUsersViewModels
                    {
                        auId = user.Id,
                        Fname = user.FName,
                        Lname = user.LName,
                        Email = user.Email,
                        GroupName = group.GroupName,
                        Id = group.Id,
                        UserName = user.UserName
                    }
                );
            }
            ViewBag.GId = group.Id;
            ViewBag.GName = group.GroupName;
            return View(GUVM);
        }

        // GET: Groups/Details/5
         [HttpPost]
        public ActionResult Details(int? id, string[] Select)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }

            if (Select != null && Select.Length > 0)
            {
                
                foreach (string cId in Select)
                {
                    if (Select.FirstOrDefault().Equals("on"))
                    {
                        ViewBag.SelectError = "Something went wrong, try again";
                        break;
                    }
   
                    var us = group.Users.Single(u => u.Id.Equals(cId));
                    group.Users.Remove(us);
                    db.Groups.Find(id).Users.Remove(us);
                    //Gör dessa ändringar i db.groups :)
                }
            }
            db.SaveChanges();
            group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            List<GroupUsersViewModels> GUVM = new List<GroupUsersViewModels>();
            List<ApplicationUser> UG = group.Users.ToList();

             //foreach (ApplicationUser user in GInfo.Where(u => u.Groups.FirstOrDefault().Id == group.Id))
            foreach (ApplicationUser user in UG)
            {
                GUVM.Add(
                    new ViewModels.GroupUsersViewModels
                    {
                        Fname = user.FName,
                        Lname = user.LName,
                        Email = user.Email,
                        GroupName = group.GroupName,
                        Id = group.Id,
                        UserName = user.UserName

                    }
                );
            }
            ViewBag.GId = group.Id;
            ViewBag.GName = group.GroupName;
            return View(GUVM);
        }


        // GET: Groups/Create
        public ActionResult Create()
        {
            ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "Name");
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GroupName,ScheduleId")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Groups.Add(group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "Name", group.ScheduleId);
            return View(group);
        }

        // GET: Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "Name", group.ScheduleId);
            return View(group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GroupName,ScheduleId")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "Name", group.ScheduleId);
            return View(group);
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = db.Groups.Find(id);
            db.Groups.Remove(group);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult AddUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            //List<ApplicationUser> UG = db.Users.ToList();
            //foreach (ApplicationUser au in db.Users)
            //{
            //    foreach (Group g in au.Groups)
            //    {

            //        if (g.Id == group.Id)
            //            UG.RemoveAll(u => u.Id == au.Id);
            //    }
            //}
            
            var Groupinfo = db.Users.Where(u => u.Groups.All(g => g.Id != group.Id));
            ViewBag.GId = group.Id;
            return View(Groupinfo);
        }

        [HttpPost]
        public ActionResult AddUser(int? id, string[] Select)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }

            
            if (Select != null && Select.Length > 0)
            {
                foreach (string cId in Select)
                {
                    var us = db.Users.Single(u => u.Id.Equals(cId));
                    group.Users.Add(us);
                    db.Groups.Find(id).Users.Add(us);
                }
            }
            db.SaveChanges();
            group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            
            var Groupinfo = db.Users.Where(u => u.Groups.All(g => g.Id != group.Id));
            ViewBag.GId = group.Id;
            return View(Groupinfo);
        }

        public ActionResult CreateSchedule()
        {
            return View();
        }

        public ActionResult ListUsers()
        {
             return View(db.Users.ToList()); // Must be in this group
        }
    }
}
