using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.Data
{
    public class Permission
    {
        public decimal employeeId { get; set; }
        public DateTime? time { get; set; }
        public int? salaryFlag { get; set; }
        public int? employFlag { get; set; }
    }
}
