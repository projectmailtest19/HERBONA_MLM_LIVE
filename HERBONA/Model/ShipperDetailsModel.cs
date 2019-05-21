using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class ShipperDetailsModel
    {

        public string ID { get; set; }
        public string Company_Name { get; set; }
        public string EIN { get; set; }
        public string Contact_Name { get; set; }
        public string Email { get; set; }
        public string DBA_Name { get; set; }
        public string Account_Number { get; set; }
        public string Phone { get; set; }
        public string Factoring_Rate { get; set; }
        public string Factoring_Rate_Unit { get; set; }
        public string IsActive { get; set; }
    }

    public class ShipperAddressDetailsModel
    {

        public string ID { get; set; }
        public string Country { get; set; }
        public string Country_Name { get; set; }
        public string State { get; set; }
        public string State_Name { get; set; }
        public string Address1 { get; set; }
        public string Save_Location_As { get; set; }
        public string Contact_Name { get; set; }
        public string City { get; set; }
        public string Zip_Code { get; set; }
        public string Address2 { get; set; }
        public string Instructions { get; set; }
        public string Phone { get; set; }
        public string Current_Odometer { get; set; }
        public string Date { get; set; }

    }
}