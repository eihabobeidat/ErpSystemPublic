using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.DTO
{
    public class Email
    {
        public string to { get; set; }
        public string senderName { set; get; }
        public string recieverName { set; get; }
        public string cc { set; get; }
        public string subject { set; get; }
        public string body { set; get; }
        public string signature { set; get; } = "<br><p>DOT Team</p>";
    }
}
