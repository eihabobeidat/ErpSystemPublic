using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.Data
{
    public class SliderImage
    {
        public int id { get; set; }
        public int sliderId { get; set; }
        public string image { get; set; }
        public virtual Slider slider { get; set; }

    }
}
