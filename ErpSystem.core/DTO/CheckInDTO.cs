using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.DTO
{
    public class CheckInDTO
    {
        public int id { get; set; }

        public DateTime CheckIn { get; set; } = DateTime.Now;
    }
}
