using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models
{
    public class Group
    {
        //[Key, ForeignKey("Schedule")]
        [Key]
        public int Id { get; set; }
        public string GroupName { get; set; }
      public int ScheduleId { get; set; }
        [ForeignKey("ScheduleId")]
        public virtual Schedule schedule { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

    }
}