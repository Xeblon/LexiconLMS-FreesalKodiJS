namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using LexiconLMS.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<LexiconLMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "LexiconLMS.Models.ApplicationDbContext";
        }

        protected override void Seed(LexiconLMS.Models.ApplicationDbContext context)
        {
            // CREATE THE ROLE OF ADMIN
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (!roleManager.RoleExists("admin"))
            {
                var role = new IdentityRole();
                role.Name = "admin";
                roleManager.Create(role);
            }
            context.SaveChanges();

            // CREATE THE INITIAL USER
            if (!context.Users.Any(u => u.UserName == "GodAllmighty"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "GodAllmighty", FName = "God", LName = "Allmighty", Email = "god@heaven.com" };

                userManager.Create(user, "Password-123");
                userManager.AddToRole(user.Id, "admin");
            }
            context.SaveChanges();

            // CREATE DEFAULT EMPTY SCHEDULE
            context.Schedules.AddOrUpdate(
                new Schedule { Id = 0, Name = "Empty Schedule" }
            );
            context.SaveChanges();
        }
    }
}