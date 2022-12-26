using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErpSystem.core.Data
{
    public  class VacationCount
    {
        [Key]
        public decimal Id { get; set; }
        public decimal? Employeeid { get; set; }
        public decimal? Type { get; set; }
        public decimal? Count { get; set; }
        public decimal? Limit { get; set; }
        [ForeignKey("Employeeid")]
        public virtual Employee Employee { get; set; }
        [ForeignKey("Type")]
        public virtual VacationTypes TypeNavigation { get; set; }
    }
}
