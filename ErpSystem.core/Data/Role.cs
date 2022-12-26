using System;
using System.Collections.Generic;

namespace ErpSystem.core.Data
{
    public  class Role
    {
       

        public decimal Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
