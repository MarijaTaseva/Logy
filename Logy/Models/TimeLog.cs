using System;
using System.Collections.Generic;

namespace Logy.Models
{
    public partial class TimeLog
    {
        public int TimeLogId { get; set; }
        public string UserId { get; set; }
        public DateTime DateToday { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public DateTime? Pause { get; set; }
        public bool? Holiday { get; set; }
        public bool? Night { get; set; }

        public AspNetUsers User { get; set; }
    }
}
