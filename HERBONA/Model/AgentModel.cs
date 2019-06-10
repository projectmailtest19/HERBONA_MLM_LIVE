﻿using System;
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

    public class AgentAddressProofListModel
    {
        public string id { get; set; }
        public string Contact_id { get; set; }
        public string Address_Proof_Type { get; set; }
        public string Address_Proof_URL { get; set; }
    }
    public class AgentBankProofListModel
    {
        public string id { get; set; }
        public string Contact_id { get; set; }
        public string Bank_Proof_Type { get; set; }
        public string Bank_Proof_URL { get; set; }
    }

    public class AgentSponsorModel
    {
        public string id { get; set; }
        public string Contact_id { get; set; }
        public string Sponsor_ID { get; set; }
        public string Placed_Name { get; set; }
        public string Placed_MemberID { get; set; }
        public string Placed_Team { get; set; }
        public string SplitSponsor_ID { get; set; }
    }
    public class Sponsor_Details_Model
    {
        public string MobileNo { get; set; }
        public string Account_Number { get; set; }
        public string Placed_MemberID { get; set; }
    }

    public class AgentBankDetailsModel
    {
        public string id { get; set; }
        public string Contact_id { get; set; }
        public string Account_Holder_Name { get; set; }
        public string Account_Number { get; set; }
        public string Bank_Name { get; set; }
        public string Account_Type { get; set; }
        public string IFSC_Code { get; set; }
        public string Branch_Name { get; set; }
        public string Pan_No { get; set; }
    }
    public class AgentPANListModel
    {
        public string id { get; set; }
        public string Contact_id { get; set; }
        public string PANCard_URL { get; set; }
    }
    public class AgentApplicationListModel
    {
        public string id { get; set; }
        public string Contact_id { get; set; }
        public string AppicationForm_URL { get; set; }
    }
}