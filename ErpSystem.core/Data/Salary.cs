using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErpSystem.core.Data
{
    public  class Salary
    {
        [Key]
        public decimal Id { get; set; }
        public decimal? EmployeeId { get; set; }
        public decimal? Value { get; set; }
        public DateTime? Time { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }
}
