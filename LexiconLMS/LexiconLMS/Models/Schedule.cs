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
     //   [Key,ForeignKey ("Group")]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Group groups { get; set; }
        //public virtual ICollection<Group> Groups { get; set; }
    }
}