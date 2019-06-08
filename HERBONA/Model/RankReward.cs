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
}