using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class LoadInvoiceModel
    {
        public string ID { get; set; }
        public string Load_Number { get; set; }
        public string Invoice_Number { get; set; }
        public string Cust_Carr_Bro_Name { get; set; }
        public string Cust_Carr_Bro_Address { get; set; }
        public string Account_No { get; set; }
        public string Load_Date { get; set; }
        public string Reference { get; set; }
        public string Invoice_date { get; set; }
        public string Due_date { get; set; }
        public string Discount_Total_Amount { get; set; }
        public string Sub_Total { get; set; }
        public string Total_Amount { get; set; }
        public string Total_Tax_Amt { get; set; }
        public string Total_Line_Total { get; set; }

    }

    public class FactoringCompanyDetails_InvoiceModel
    {
        public string ID { get; set; }
        public string Company_Name { get; set; }
        public string Factoring_Rate { get; set; }
        public string Factoring_Rate_Unit { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string Zip_Code { get; set; }
        public string Country_Name { get; set; }
        public string State_Name { get; set; }
    }
    public class Load_Invoice_Details_Model
    {
        public string ID { get; set; }
        public string Load_ID { get; set; }
        public string Invoice_Number { get; set; }
        public string Invoice_Date { get; set; }
        public string Due_Date { get; set; }
        public string Terms_ID { get; set; }
        public string Factoring_Company_ID { get; set; }
        public string Notes_for_Customer { get; set; }
        public string Memo { get; set; }
        public string CustomMessage { get; set; }
        public string CustomErrorState { get; set; }
        public string Isfactoring_Company { get; set; }
        public string Terms_Name { get; set; }
    }


    public class TermDetails
    {
        public string ID { get; set; }
        public string NoofDays { get; set; }
        public string Terms_Name { get; set; }
    }


    public class Load_BOL_Details_Model
    {
        public string ID { get; set; }
        public string Load_ID { get; set; }
        public string Load_Number { get; set; }
        public string Cust_Carr_Bro_Name { get; set; }
        public string Cust_Carr_Bro_Address { get; set; }
        public string Reference { get; set; }
        public string IsLTLorFTL { get; set; }
        public string CTPAT { get; set; }
        public string IsLHazMat { get; set; }
        public string IsOversize_Load { get; set; }
        public string IsReefer { get; set; }
        public string IsTanker { get; set; }
        public string BOL_No { get; set; }
        public string Instructions_of_BOL { get; set; }
        public string Driver_Signature { get; set; }
        public string Shipper_Signature { get; set; }
        public string Consignee_Signature { get; set; }
        public string CustomMessage { get; set; }
        public string CustomErrorState { get; set; }
    }



}