using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models.ViewModels
{
    public class scheduleViewModel
    {
        public string ScheduleName { get; set; }
        public int ScheduleId { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventSummary { get; set;}
        public DateTime EventDate { get; set; }
        public int EventTime { get; set; }
    }
}