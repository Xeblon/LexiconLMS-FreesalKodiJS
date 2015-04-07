using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Models
{
    public class Movie
    {

        [Key]
        public int mID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int AgeLimit { get; set; }
        public string uID { get; set; }

        [ForeignKey("uID")]
        public virtual ApplicationUser owner { get; set; }
     
    }

   
}