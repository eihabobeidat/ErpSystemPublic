using System;
using System.Collections.Generic;

namespace ErpSystem.core.Data
{
    public  class Testimonial
    {
        public decimal Id { get; set; }
        public decimal? Employeeid { get; set; }
        public string Message { get; set; }
        public DateTime? Time { get; set; }
        public decimal? Status { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
