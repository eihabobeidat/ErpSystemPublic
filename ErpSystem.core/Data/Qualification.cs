using System;
using System.Collections.Generic;

namespace ErpSystem.core.Data
{
    public  class Qualification
    {
        public decimal Id { get; set; }
        public decimal? Employeeid { get; set; }
        public string Title { get; set; }
        public string Filepath { get; set; }
        public DateTime? Time { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
