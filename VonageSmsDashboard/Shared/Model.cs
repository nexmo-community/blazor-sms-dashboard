using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace VonageSmsDashboard.Shared
{
    public class MessageBase
    {
        [Key]
        public string MessageId { get; set; }
        public string To { get; set; }
        public string MessageTimestamp { get; set; }
        public string Msisdn { get; set; }
    }
    public class DeliveryReceiptModel : MessageBase
    {
        public string Status { get; set; }
        
    }
    public class InboundSmsModel : MessageBase
    {        
        public string Text { get; set; }
    }

    public class OutboundSms
    {
        [Key]      
        
        public string MessageId { get; set; }
        public string To { get; set; }
        public string From { get; set; }        
        public string Status { get; set; }
        public string MessagePrice { get; set; }
        public string Text { get; set; }
    }
}
