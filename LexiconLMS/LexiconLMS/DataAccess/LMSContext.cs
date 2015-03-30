using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LexiconLMS.Models;

namespace LexiconLMS.DataAccess
{
    public class LMSContext: DbContext
        {

            public LMSContext() : base("DefaultConnection") { } //skapar kopplingen till databasen, som vi döper till DefaultConnection

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Student>()
                        .HasRequired(s => s.Classes)
                        .WithMany(c => c.Students)
                        .HasForeignKey(s => s.ClassId);

            }
        }
    }
