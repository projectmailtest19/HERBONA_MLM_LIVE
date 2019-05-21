using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class AddressModel
    {
        public string ID { get; set; }
        public string Company_Name { get; set; }
        public string Customer_Type { get; set; }
        public string Street { get; set; }
        public string Apt_Suite_Other { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Zip_Code { get; set; }
        public string CellNo { get; set; }
        public string PhoneNo { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string WebsiteUrl { get; set; }
        public string Contact { get; set; }
        public string Notes { get; set; }
        public string Motor_Carrier_Number { get; set; }
        public string Tax_ID { get; set; }
        public string IsActive { get; set; }
    }
}