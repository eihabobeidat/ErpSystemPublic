using System;
using System.Collections.Generic;

namespace ErpSystem.core.Data
{
    public  class Review
    {
        public int id { get; set; }
        public decimal Employeeid { get; set; }
        public decimal? Reviewedby { get; set; }
        public decimal? Value { get; set; }
        public decimal? Objective { get; set; }
        public decimal? Competency { get; set; }
        public DateTime? Time { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Employee ReviewedbyNavigation { get; set; }
    }
}
