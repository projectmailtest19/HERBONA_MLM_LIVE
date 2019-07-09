using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class RankRewardlistModel
    {
        public string ID { get; set; }
        public string NAME { get; set; }
        public string START { get; set; }
        public string LEFT_SIDE { get; set; }
        public string RIGHT_SIDE { get; set; }
        public string REWARDS_DETAIL { get; set; }
        public string IsActive { get; set; }
    }
    public class RankRewardModel
    {
        public string ID { get; set; }
        public string NAME { get; set; }
        public string START { get; set; }
        public string LEFT_SIDE { get; set; }
        public string RIGHT_SIDE { get; set; }
        public string REWARDS_DETAIL { get; set; }
        public string IsActive { get; set; }
    }
    public class Wallet_balanceModel
    {
        public string Wallet_Balance { get; set; }
    }
    public class Payment_DetailsModel
    {
        public string SALES_AMOUNT { get; set; }
        public string SHIPPING { get; set; }
        public string NET_AMOUNT { get; set; }
    }
}