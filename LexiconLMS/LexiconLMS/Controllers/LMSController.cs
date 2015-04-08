﻿using LexiconLMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LexiconLMS.Controllers
{
    public class LMSController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // [Authorize(Roles = "")]
        // GET: LMS
        public ActionResult Index()
        {
            var groups = db.Groups.ToList();
            return View(groups);
        }

        // CREATE GOUP PAGE
        public ActionResult CreateGroup()
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


        //AUTOGENERATED FROM APPLICATIONUSERCONTROLLER.CS

        //public ActionResult Index()
        //{
        //    return View(db.Users.ToList());
        //}

        // GET: UsersTest/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsersTest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUsersTest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FName,LName,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(applicationUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicationUser);
        }

        // GET: ApplicationUsersTest/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsersTest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FName,LName,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsersTest/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsersTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
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

    }
}

   