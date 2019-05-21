using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class CustomerDetailsModel
    {
        public string ID { get; set; }
        public string Company_Name { get; set; }
        public string Account_Number { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip_Code { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Accnt_Payable_Email { get; set; }
        public string IsActive { get; set; }
    }
    public class CustomerContactDetailsModel
    {
        public string ID { get; set; }
        public string Contact_Name { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}