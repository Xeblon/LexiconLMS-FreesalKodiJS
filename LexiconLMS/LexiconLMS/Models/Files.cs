﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models
{
    public class Files
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int FileType { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser Users { get; set; }
    }
}