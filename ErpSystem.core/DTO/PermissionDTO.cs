using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.DTO
{
    public class PermissionDTO
    {
        public decimal employeeId { get; set; }
        public DateTime? time { get; set; }
        public decimal salaryFlag { get; set; }
        public decimal employFlag { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string imagepath { get; set; }
        public string email { get; set; }
    }
}
