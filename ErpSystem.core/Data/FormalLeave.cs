using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ErpSystem.core.Data
{
    public  class FormalLeave
    {
        [Key]
        public decimal Id { get; set; }
        public string Name { get; set; }
        public DateTime? Time { get; set; }
    }
}
