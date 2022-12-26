using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErpSystem.core.Data
{
    public  class Message
    {
        [Key]
        public decimal? Id { get; set; }
        public decimal? Sender { get; set; }
        public decimal? Receiver { get; set; }
        public string Text { get; set; }
        public DateTime? Time { get; set; }
        public decimal? Status { get; set; }
        public string Filepath { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee ReceiverNavigation { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee SenderNavigation { get; set; }
    }
}
