﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models
{
    public class Class
    {
        [Key,ForeignKey("Schedule")]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }

        //public int ScheduleId { get; set; }
        //[ForeignKey("ScheduleId")]
        //public virtual Schedule Schedules { get; set; }
    }
}