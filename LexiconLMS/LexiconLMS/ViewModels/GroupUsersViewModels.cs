using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LexiconLMS.Models;

namespace LexiconLMS.ViewModels
{
    public class GroupUsersViewModels
    {
        public string auId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string GroupName { get; set; }
        public int Id { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}