using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class ActiveTicketModel
    {
        public string TickerNumber { get; set; }
        public string TicketDate { get; set; }
        public string TicketLabel { get; set; }
        public string QueryType { get; set; }
        public string Status { get; set; }
        public string PayScheduleNo { get; set; }
        public string CreditedAmount { get; set; }
        public string EstimatedAmount { get; set; }
        public string Attatchments { get; set; }
        public string Subject { get; set; }
        public string ORDER_NUMBER { get; set; }
        public string AnsweredBy { get; set; }
        public string AssignedTO { get; set; }
        public string ActionPendingFrom { get; set; }
    }
    public class ActiveTicketCommentModel
    {
        public string comments { get; set; }
        public string Colour { get; set; }
    }
}