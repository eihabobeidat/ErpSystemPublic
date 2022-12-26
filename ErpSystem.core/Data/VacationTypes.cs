using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ErpSystem.core.Data
{
    public  class VacationTypes
    {
        [Key]
        public decimal Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<VacationCount> Vacationcounts { get; set; }
        public virtual ICollection<Vacation> Vacations { get; set; }
    }
}
