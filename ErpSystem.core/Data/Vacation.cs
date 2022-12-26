using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErpSystem.core.Data
{
    public  class Vacation
    {
        [Key]
        public decimal Id { get; set; }
        public decimal Employeeid { get; set; }
        public decimal? Reviewedby { get; set; }
        public decimal? Approvedby { get; set; }
        public DateTime? Starttime { get; set; }
        public DateTime? Endtime { get; set; }
        public decimal? Type { get; set; }
        public string Filepath { get; set; }
        public decimal? Status { get; set; }
        public string Comments { get; set; }
        [ForeignKey("Approvedby")]
        public virtual Employee ApprovedbyNavigation { get; set; }
        [ForeignKey("Employeeid")]
        public virtual Employee Employee { get; set; }
        [ForeignKey("Reviewedby")]
        public virtual Employee ReviewedbyNavigation { get; set; }
        [ForeignKey("Type")]
        public virtual VacationTypes TypeNavigation { get; set; }
    }
}
