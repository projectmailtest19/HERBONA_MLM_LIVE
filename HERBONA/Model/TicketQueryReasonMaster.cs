using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class TicketQueryReasonMasterModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string PayScheduleNo { get; set; }
        public string CreditedAmount { get; set; }
        public string EstimatedAmount { get; set; }
        public string Comments { get; set; }
        public string orderid { get; set; }
        public string Attatchments { get; set; }
        public string subject { get; set; } 
    }
}