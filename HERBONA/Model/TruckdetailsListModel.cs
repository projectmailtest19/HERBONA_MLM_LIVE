using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class TruckdetailsListModel
    {
        public string ID { get; set; }
        public string Unit_Number { get; set; }
        public string Owner { get; set; }
        public string VIN { get; set; }
        public string Title_No { get; set; }
        public string License_Plate_No { get; set; }
        public string Insurance_Name { get; set; }
        public string IsActive { get; set; }
    }
    public class TrailerdetailsListModel
    {
        public string ID { get; set; }
        public string Unit_Number { get; set; }
        public string Status { get; set; }
        public string Owner { get; set; }
        public string VIN { get; set; }
        public string Serial_No { get; set; }
        public string Title_No { get; set; }
        public string License_Plate_No { get; set; }
        public string IsActive { get; set; }
    }
    public class GetTruckDetailsListModel
    {
        public string TDB_ID { get; set; }
        public string TDB_Unit_Number { get; set; }
        public string TDB_Make { get; set; }
        public string TDB_Model_Year { get; set; }
        public string TDB_Model { get; set; }
        public string TDB_Include_Billing { get; set; }
        public string TDB_Include_IFTA { get; set; }
        public string TDB_Not_In_Service { get; set; }
        public string TDB_Reason { get; set; }
        public string TDB_Other_Reason { get; set; }
        public string IsActive { get; set; }
        public string TDIH_Fuel_Type { get; set; }
        public string TDIH_No_Of_Axle { get; set; }
        public string TDIH_GVW { get; set; }
        public string TDIH_Used_For_Logging { get; set; }
        public string TDIH_Used_For_Agriculture { get; set; }
        public string TDIH_Include_Billing { get; set; }
        public string TDV_Owner { get; set; }
        public string TDV_Title_No { get; set; }
        public string TDV_Height { get; set; }
        public string TDV_Serial_No { get; set; }
        public string TDV_VIN { get; set; }
        public string TDV_Year_Purchased { get; set; }
        public string TDV_Unladen_Weight { get; set; }
        public string TDLI_License_Plate_No { get; set; }
        public string TDLI_Inspection_Date { get; set; }
        public string TDLI_License_Exp_Date { get; set; }
        public string TDLI_Insurance_Name { get; set; }
        public string TDLI_Insurance_Exp_Date { get; set; }
        public string TDLI_Policy_Number { get; set; }
        public string TDLI_Registered_Country { get; set; }
        public string TDLI_Registered_State { get; set; }
        public string TDA_Cost { get; set; }
        public string TDA_Color { get; set; }
        public string TDA_Notes { get; set; }
        public string TDA_FMV { get; set; }
        public string TDA_Tire_Info { get; set; }
        public string TDA_LogoPath { get; set; }
        public string TDLI_License_Plate_Country_ID { get; set; }
        public string TDLI_License_Plate_State_ID { get; set; }
        public string TDLI_DVIR_Form_ID { get; set; }
        public string TDLI_Visibility_Sets { get; set; }
        public string TDLI_Home_Terminal_ID { get; set; }
        public string TDEC_Device_ID { get; set; }
        public string TDEC_Connection_Type_ID { get; set; }
        public string TDEC_Device_Name { get; set; }
        public string TDEC_MAC_Address { get; set; }
        public string TDEC_PIN_No { get; set; }
        public string TDEC_IsOdometer { get; set; }
        public string TDEC_IsEngineHours { get; set; }


    }
    public class GetTrailerDetailsListModel
    {
        public string TDB_ID { get; set; }
        public string TDB_Unit_Number { get; set; }
        public string TDB_Make { get; set; }
        public string TDB_Model_Year { get; set; }
        public string TDB_Model { get; set; }
        public string TDB_Status { get; set; }
        public string IsActive { get; set; }
        public string TDV_Owner { get; set; }
        public string TDV_Title_No { get; set; }
        public string TDV_Height { get; set; }
        public string TDV_Serial_No { get; set; }
        public string TDV_VIN { get; set; }
        public string TDV_Year_Purchased { get; set; }
        public string TDV_Unladen_Weight { get; set; }
        public string TDV_Trailer_Group { get; set; }
        public string TDV_Trailer_Type { get; set; }
        public string TDV_No_Of_Axle { get; set; }
        public string TDV_Used_For_Logging { get; set; }
        public string TDV_Used_For_Agriculture { get; set; }
        public string TDLI_License_Plate_No { get; set; }
        public string TDLI_Inspection_Date { get; set; }
        public string TDLI_License_Exp_Date { get; set; }
        public string TDLI_Insurance_Name { get; set; }
        public string TDLI_Insurance_Exp_Date { get; set; }
        public string TDLI_Policy_Number { get; set; }
        public string TDLI_Registered_Country { get; set; }
        public string TDLI_Registered_State { get; set; }
        public string TDA_Cost { get; set; }
        public string TDA_Color { get; set; }
        public string TDA_Notes { get; set; }
        public string TDA_FMV { get; set; }
        public string TDA_Tire_Info { get; set; }
        public string TDA_LogoPath { get; set; }
        public string TDLI_License_Plate_Country_ID { get; set; }
        public string TDLI_License_Plate_State_ID { get; set; }
        public string TDLI_DVIR_Form_ID { get; set; }
        public string TDLI_Visibility_Sets { get; set; }
        public string TDLI_Home_Terminal_ID { get; set; }

    }
}