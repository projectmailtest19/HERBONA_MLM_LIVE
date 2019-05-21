using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class Load_Shipper_Model
    {
        public string ID { get; set; }
        public string Shipper_ID { get; set; }
        public string Shipper_Name { get; set; }
        public string Pickup_Location_ID { get; set; }
        public string Pickup_Location_Name { get; set; }
        public string Pickup_Date { get; set; }
        public string Pickup_Fixed_Time { get; set; }
        public string Pickup_From_Time { get; set; }
        public string Pickup_To_Time { get; set; }
        public string Pickup_Instruction { get; set; }
        public string Contact_Person_at_PickUp { get; set; }
        public string Phone { get; set; }
        public string BOL { get; set; }
        public string Reference { get; set; }
        public string Notes { get; set; }
        public string IsActive { get; set; }
    }
    public class Load_Consignee_Model
    {
        public string ID { get; set; }
        public string Consignee_ID { get; set; }
        public string Consignee_Name { get; set; }
        public string Drop_Of_Location_ID { get; set; }
        public string Drop_Of_Location_Name { get; set; }
        public string Delivery_Date { get; set; }
        public string Delivery_Fixed_Time { get; set; }
        public string Delivery_From_Time { get; set; }
        public string Delivery_To_Time { get; set; }
        public string Delivery_Instruction { get; set; }
        public string Contact_Person_at_Delivery { get; set; }
        public string Phone { get; set; }
        public string Reference { get; set; }
        public string Notes { get; set; }
        public string IsActive { get; set; }
    }
    public class Load_Freight_Model
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public string Pick_Up { get; set; }
        public string Drop_Of { get; set; }
        public string Weight_Value { get; set; }
        public string Weight_Unit_ID { get; set; }
        public string Weight_Qty { get; set; }
        public string Qty_Value { get; set; }
        public string Qty_Unit_ID { get; set; }
        public string Qty_Unit { get; set; }
        public string L_Value { get; set; }
        public string W_Value { get; set; }
        public string H_Value { get; set; }
        public string LWH_ID { get; set; }
        public string LWH_Unit { get; set; }
        public string FC_ID { get; set; }
        public string Declared_Value { get; set; }
        public string IsActive { get; set; }
    }

    //****
    public class Comments_Sender_Model
    {
        public string id { get; set; }
        public string company_name { get; set; }
        public string Type { get; set; }
        public string Emil_ID { get; set; }
        public string Phone_Number { get; set; }
    }

    public class Load_Comment_Model
    {
        public string ID { get; set; }
        public string Comment { get; set; }
        public string Email_ID { get; set; }
        public string Email_ID_Text { get; set; }
        public string Is_Email_Text { get; set; }
        public string Email_ID_Type { get; set; }
        public string Phone_No { get; set; }
        public string Phone_No_Text { get; set; }
        public string Is_Phone_Text { get; set; }
        public string Phone_ID_Type { get; set; }

        public string Email_Person_ID { get; set; }
        public string Phone_Person_ID { get; set; }
        public string side { get; set; }
        public string type { get; set; }



        public string CONTACT_NAME { get; set; }
        public string Entry_Date { get; set; }


    }
    public class Load_Document_Model
    {
        public string ID { get; set; }
        public string Tittle { get; set; }
        public string Url { get; set; }

        public string CreatedDate { get; set; }
        public string Name { get; set; }

    }
    public class LoadList_Model
    {
        public string ID { get; set; }
        public string Load_Number { get; set; }
        public string IsLTLorFTL { get; set; }
        public string IsCustCarrORBro { get; set; }
        public string Name { get; set; }
        public string Account_No { get; set; }
        public string Load_Date { get; set; }
        public string Load_Time { get; set; }
        public string Reference { get; set; }
        public string IS_COMPLETE { get; set; }
        public string IS_CANCEL { get; set; }

    }
    public class DispatchList_Model
    {
        public string ID { get; set; }
        public string Dispatch_Number { get; set; }
        public string IsCustCarrORBro { get; set; }
        public string Name { get; set; }
        public string Account_No { get; set; }
        public string Dispatch_Date { get; set; }
        public string Dispatch_Time { get; set; }
        public string Reference { get; set; }
        public string IS_COMPLETE { get; set; }
        public string IS_CANCEL { get; set; }

    }
    public class AccessorialFeelist
    {
        public string ID { get; set; }
        public string AccessorialFee_ID { get; set; }
        public string AccessorialFee_Name { get; set; }
        public string AccessorialFee_Rate { get; set; }
        public string AccessorialFee_Amount { get; set; }
    }
    public class FuelSurchargelist
    {
        public string ID { get; set; }
        public string FuelSurcharge_ID { get; set; }
        public string FuelSurcharge_Name { get; set; }
        public string FuelSurcharge_Rate { get; set; }
        public string FuelSurcharge_Amount { get; set; }
        public string Tax_ID { get; set; }
        public string Tax_Name { get; set; }
        public string Tax_Amount { get; set; }
        public string Line_Total { get; set; }
    }
    public class HaulingFeelist
    {
        public string ID { get; set; }
        public string HaulingFee_ID { get; set; }
        public string HaulingFee_Name { get; set; }
        public string HaulingFee_Rate { get; set; }
        public string HaulingFee_Amount { get; set; }
        public string Tax_ID { get; set; }
        public string Tax_Name { get; set; }
        public string Tax_Amount { get; set; }
        public string Line_Total { get; set; }
    }
    public class LoadNumberMODEL
    {
        public string LOAD_NUMBER { get; set; }

    }
    public class Load_Details_Model
    {
        public string ID { get; set; }
        public string Load_Number { get; set; }
        public string IsLTLorFTL { get; set; }
        public string IsCustCarrORBro { get; set; }
        public string Type { get; set; }
        public string CustCarrORBro_ID { get; set; }
        public string CustCarrORBroContact_ID { get; set; }
        public string Account_No { get; set; }
        public string Load_Date { get; set; }
        public string Load_Time { get; set; }
        public string Reference { get; set; }
        public string IsLDropTrailer { get; set; }
        public string Trailer_Group_ID { get; set; }
        public string Trailer_Type_ID { get; set; }
        public string IsLHazMat { get; set; }
        public string IsOversize_Load { get; set; }
        public string IsReefer { get; set; }
        public string IsTanker { get; set; }
        public string Temp { get; set; }
        public string Total_Miles { get; set; }
        public string Hauling_Fee_ID { get; set; }
        public string Hauling_Fee_Rate { get; set; }
        public string FuelSurcharge_ID { get; set; }
        public string FuelSurcharge_Rate { get; set; }
        public string Discount_ID { get; set; }
        public string Discount_Amount { get; set; }
        public string IsActive { get; set; }
    }
    public class Dispatch_Details_Model
    {
        public string ID { get; set; }
        public string Dispatch_Number { get; set; }
        public string IsCustCarrORBro { get; set; }
        public string Type { get; set; }
        public string CustCarrORBro_ID { get; set; }
        public string CustCarrORBroContact_ID { get; set; }
        public string Account_No { get; set; }
        public string Dispatch_Date { get; set; }
        public string Dispatch_Time { get; set; }
        public string Reference { get; set; }
        public string IsLDropTrailer { get; set; }
        public string Trailer_Group_ID { get; set; }
        public string Trailer_Type_ID { get; set; }
        public string IsLHazMat { get; set; }
        public string IsOversize_Load { get; set; }
        public string IsReefer { get; set; }
        public string IsTanker { get; set; }
        public string Temp { get; set; }
        public string Total_Miles { get; set; }
        public string Hauling_Fee_ID { get; set; }
        public string Hauling_Fee_Rate { get; set; }
        public string FuelSurcharge_ID { get; set; }
        public string FuelSurcharge_Rate { get; set; }
        public string Discount_ID { get; set; }
        public string Discount_Amount { get; set; }
        public string IsLDropTrailer_Trailer { get; set; }
        public string Trailer_ID { get; set; }
        public string IsActive { get; set; }
    }
    public class CPAT_Details_Model
    {
        public string ID { get; set; }
        public string Load_ID { get; set; }
        public string CTPAT { get; set; }
        public string IsActive { get; set; }

    }
    public class CSA_Details_Model
    {
        public string ID { get; set; }
        public string Load_ID { get; set; }
        public string CSA { get; set; }
        public string IsActive { get; set; }

    }



    public class Load_Driver_Model
    {
        public string ID { get; set; }
        public string DriverID { get; set; }
        public string chkDriverEmail { get; set; }
        public string IschkDriverEmail { get; set; }
        public string chkDriverSms { get; set; }
        public string IschkDriverSms { get; set; }

    }
    public class Load_Truck_Model
    {
        public string ID { get; set; }
        public string TruckID { get; set; }

    }










    public class Dispatch_Driver_List_Model
    {
        public string ID { get; set; }
        public string Dispatch_ID { get; set; }
        public string Driver_ID { get; set; }

        public string IsNotify_Email { get; set; }
        public string IsNotify_SMS { get; set; }

        public string Driver_Name { get; set; }
        public string Work_Email { get; set; }
        public string Work_Phone { get; set; }


    }
    public class Dispatch_Truck_List_Model
    {
        public string ID { get; set; }
        public string Dispatch_ID { get; set; }
        public string Truck_ID { get; set; }
        public string Unit_Number { get; set; }


    }

}