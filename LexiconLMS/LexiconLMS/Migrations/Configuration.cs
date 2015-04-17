namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using LexiconLMS.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<LexiconLMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "LexiconLMS.Models.ApplicationDbContext";
        }

        protected override void Seed(LexiconLMS.Models.ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (!roleManager.RoleExists("admin"))
            {
                var role = new IdentityRole();
                role.Name = "admin";
                roleManager.Create(role);
            }
            context.SaveChanges();

            //HÄR
            Schedule S1 = new Schedule { Id = 8, Name = "Test Schedule" };
            Group dotNet = new Group { Id = 10, GroupName = ".Net 2", ScheduleId = 8, Users = new List<ApplicationUser>() };
            //ApplicationUser u1 =new ApplicationUser { UserName = "Xeblon", FName = "Faisal", LName = "Waliullah", Email = "FaWa@mail.com" ,Groups = new List<Group>()};
            //ApplicationUser u2 = new ApplicationUser { UserName = "Fredö", FName = "Fredrik", LName = "Öijermark", Email = "Fredö@mail.com", Groups = new List<Group>() };
            //ApplicationUser u3 = new ApplicationUser { UserName = "Brain", FName = "Cow", LName = "Dice", Email = "Brain@mail.com", Groups = new List<Group>() };
            ApplicationUser u1 = context.Users.FirstOrDefault(s => s.UserName == "Xeblon");
            ApplicationUser u2 = context.Users.FirstOrDefault(s => s.UserName == "Fredö");
            ApplicationUser u3 = context.Users.FirstOrDefault(s => s.UserName == "Brain");

          
            //u1.Groups.Add(dotNet);
            //u2.Groups.Add(dotNet);
            //u3.Groups.Add(dotNet);
            dotNet.Users.Add(u1);
            dotNet.Users.Add(u2);
            dotNet.Users.Add(u3);


            context.Schedules.Add(S1);
            context.Groups.Add(dotNet);
            //context.Users.Add(u1);
            //context.Users.Add(u2);
            //context.Users.Add(u3);

            //context.SaveChanges();

            context.Schedules.AddOrUpdate(new Schedule { Id = 1, Name = "Empty Test" });
           
            if (!context.Users.Any(u => u.UserName == "GodAllmighty"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "GodAllmighty", FName = "God", LName = "Allmighty", Email = "god@heaven.com" };

                userManager.Create(user, "Password-123");
                userManager.AddToRole(user.Id, "admin");
            }
            context.SaveChanges();
        }
    }
}
