using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.DTO
{
    public class ReviewDto
    {
        public decimal id { get; set; }
        public DateTime time { get; set; }
        public decimal value { get; set; }
        public decimal objective { get; set; }
        public decimal competency { get; set; }
        public string imagePath { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string reviewedBy { get; set; }


    }
}
