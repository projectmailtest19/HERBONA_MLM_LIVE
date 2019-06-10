using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class ShippingChargeslistModel
    {
        public string ID { get; set; }
        public string DISTRICT_ID { get; set; }
        public string CHARGE_PERCENTAGE { get; set; }
        public string CHARGE_AMOUNT { get; set; }
        public string DISTRICT_NAME { get; set; }
        public string country_id { get; set; }

        public string state_id { get; set; }
        public string IsActive { get; set; }
    }
    public class ShippingChargesModel
    {
        public string ID { get; set; }
        public string DISTRICT_ID { get; set; }
        public string CHARGE_PERCENTAGE { get; set; }
        public string CHARGE_AMOUNT { get; set; }
        public string DISTRICT_NAME { get; set; }
        public string country_id { get; set; }

        public string state_id { get; set; }
        public string IsActive { get; set; }
    }
}