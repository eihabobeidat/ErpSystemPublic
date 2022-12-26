using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.Data
{
    public class Slider
    {
        public int id { get; set; }
        public virtual ICollection<Slider> sliders { get; set; }

    }
}
