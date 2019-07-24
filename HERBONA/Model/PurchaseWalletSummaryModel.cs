using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class PurchaseWalletSummaryModel
    {
        public string Transaction_Date { get; set; }
        public string PayShedule { get; set; }
        public string Credited_Amount { get; set; }
        public string Debited_Amount { get; set; }
        public string Balance { get; set; }
        public string Type { get; set; }
        public string Narration { get; set; }
    }
}