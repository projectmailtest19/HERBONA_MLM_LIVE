using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class WalletlistModel
    {
        public string ID { get; set; }
        public string MEMBER_ID { get; set; }
        public string WALLET_NUMBER { get; set; }
        public string IsActive { get; set; }
        public string MEMBER_NAME { get; set; } 
    }
    public class WalletModel
    {
        public string ID { get; set; }
        public string MEMBER_ID { get; set; }
        public string WALLET_NUMBER { get; set; }
        public string IsActive { get; set; }
        public string MEMBER_NAME { get; set; }
    }
}