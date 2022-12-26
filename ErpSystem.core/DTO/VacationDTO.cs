using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.DTO
{
    public class VacationDTO
    {
        public decimal Id { get; set; }
        public decimal? Employeeid { get; set; }
        public string EmployeeName { get; set; }
        public decimal? Reviewedby { get; set; }
        public decimal? Approvedby { get; set; }
        public DateTime? Starttime { get; set; }
        public DateTime? Endtime { get; set; }
        public decimal? Type { get; set; }
        public string Filepath { get; set; }
        public decimal? Status { get; set; }
        public string Comments { get; set; }
    }
}
