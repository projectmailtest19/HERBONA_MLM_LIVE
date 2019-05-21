using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class CompanyModel
    {
        public string ID { get; set; }
        public string CompanyName { get; set; }
        public string CEOName { get; set; }
        public string MobileNo { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string CompanyType { get; set; }
        public string Address { get; set; }
        public string WebsiteUrl { get; set; }
        public string LogoPath { get; set; }
        public string IsActive { get; set; }
        public string Contact_ID { get; set; }
    }
}