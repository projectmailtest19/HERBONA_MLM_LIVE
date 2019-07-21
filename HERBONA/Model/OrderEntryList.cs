using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class OrderEntryListModel
    {
        public string ID { get; set; }
        public string MEMEBER_ID { get; set; }
        public string Account_Number { get; set; }
        public string ORDER_DATE { get; set; }
        public string ORDER_NUMBER { get; set; }
        public string INVOICE_DATE { get; set; }
        public string INVOICE_NUMBER { get; set; }
        public string PAYMENT_STATUS { get; set; }
        public string ModeOfPayment { get; set; }
        public string TOTAL_SVP { get; set; }
        public string TOTAL_AMOUNT { get; set; }
        public string ORDER_TYPE { get; set; }
        public string IsActive { get; set; }
        public string MEMEBER_NAME { get; set; }
    }
 }