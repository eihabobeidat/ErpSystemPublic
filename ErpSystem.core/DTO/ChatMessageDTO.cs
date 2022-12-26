using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.DTO
{
    public class ChatMessageDTO
    {
        public string firstName { get; set; }
        public string text { get; set; }
        public string imagePath { get; set; }
        public decimal sender { get; set; }
    }
}
