using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models
{
    public class Schedule
    {
       // [Key, ForeignKey("Group")]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        //public int GroupId { get; set; }
        //[ForeignKey("GroupId")]
        //public virtual Group Groups { get; set; }
        //public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}

