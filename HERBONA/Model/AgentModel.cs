using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class AgentListModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string ImageURL { get; set; }
        public string country_id { get; set; }
        public string state_id { get; set; }
        public string district_id { get; set; }
        public string Address { get; set; }
        public string pincode { get; set; }
        public string IsAgentActive { get; set; }
    }
}