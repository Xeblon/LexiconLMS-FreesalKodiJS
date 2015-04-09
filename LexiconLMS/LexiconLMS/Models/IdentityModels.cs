using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace LexiconLMS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Files> Files { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<ApplicationUser>()
        //                .HasMany(u => u.Groups)
        //                .WithMany(g => g.Users)
        //                .Map(ug =>
        //                    {
        //                        ug.MapLeftKey("UserId");
        //                        ug.MapRightKey("GroupId");
        //                        ug.ToTable("UserGroups");
        //                    });

        //     modelBuilder.Entity<Files>()
        //                  .HasRequired(f => f.Users)
        //                  .WithMany(s => s.Files)
        //                  .HasForeignKey(f => f.UserId);
                       
        //}

        public System.Data.Entity.DbSet<LexiconLMS.Models.Group> Groups { get; set; }
        public System.Data.Entity.DbSet<LexiconLMS.Models.Schedule> Schedules { get; set; }
        public System.Data.Entity.DbSet<LexiconLMS.Models.Files> Files { get; set; }
        public System.Data.Entity.DbSet<LexiconLMS.Models.Event> Events { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

     //   public System.Data.Entity.DbSet<LexiconLMS.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}