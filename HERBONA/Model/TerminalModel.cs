using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class TerminalModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Terminal_Code { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country_ID { get; set; }
        public string State_ID { get; set; }
        public string Postal_Code { get; set; }
        public string PhoneNo { get; set; }
        public string TimeZone_ID { get; set; }
        public string Starttime_ID { get; set; }
        public string IsMainOffice { get; set; }
        public string IsActive { get; set; }
    }
}