using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.DTO
{
    public class SalaryWithName
    {
        public decimal Id { get; set; }
        public decimal? EmployeeId { get; set; }
        public decimal? Value { get; set; }
        public DateTime? Time { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

    }
}
