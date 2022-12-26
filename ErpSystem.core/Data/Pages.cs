using System;
using System.Collections.Generic;

namespace ErpSystem.core.Data
{
    public  class Pages
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public decimal? Updatedby { get; set; }
        public DateTime? Updatetime { get; set; }

        public virtual Employee UpdatedbyNavigation { get; set; }
    }
}
