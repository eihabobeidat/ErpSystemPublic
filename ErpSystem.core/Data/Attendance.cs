using System;
using System.Collections.Generic;

namespace ErpSystem.core.Data
{
    public  class Attendance
    {
        public decimal Id { get; set; }
        public decimal? Employeeid { get; set; }
        public DateTime? Checkin { get; set; }
        public DateTime? Checkout { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
