using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class DriverDetailsListModel
    {
        public string DDB_ID { get; set; }
        public string DDB_IsEmpORCont { get; set; }
        public string DDB_Company_Name { get; set; }
        public string DDB_Driver_Name { get; set; }
        public string DDB_Driver_ID { get; set; }
        public string DDB_Owner_Operator { get; set; }
        public string DDB_Work_Email { get; set; }
        public string DDB_Personal_Email { get; set; }
        public string DDB_Other_Email { get; set; }
        public string DDB_Display_Status { get; set; }
        public string DDB_Work_Phone { get; set; }
        public string DDB_Home_Phone { get; set; }
        public string DDB_Personal_Phone { get; set; }
        public string DDB_Fax_Phone { get; set; }
        public string DDB_Other_Phone { get; set; }
        public string DDB_LogoPath { get; set; }
        public string IsActive { get; set; }
        public string DDPL_Default_Payment_Type { get; set; }
        public string DDPL_Loaded_Miles { get; set; }
        public string DDPL_Empty_Miles { get; set; }
        public string DDPL_Load_Pay_Percent { get; set; }
        public string DDPL_Percent_Of { get; set; }
        public string DDPL_Rate { get; set; }
        public string DDPL_CDL_No { get; set; }
        public string DDPL_License_Expires { get; set; }
        public string DDPL_Contract_Start_Date { get; set; }
        public string DDPL_Issued_Country { get; set; }
        public string DDPL_Issued_State { get; set; }
        public string DDPL_Medical_Card_Renewal { get; set; }
        public string DDPL_Contract_End_Date { get; set; }
        public string DDPL_Birth_Date { get; set; }
        public string C_Password { get; set; }
        public string C_RoleId { get; set; }
        public string DDB_Contact_Notification { get; set; }
        public string DDOI_Facebook { get; set; }
        public string DDOI_LinkedIn { get; set; }
        public string DDOI_Blog { get; set; }
        public string DDOI_Notes_Description { get; set; }
        public string DDOI_Twitter { get; set; }
        public string DDOI_Google { get; set; }
        public string DDOI_Tumblr { get; set; }
        public string DDB2_Terminal_ID { get; set; }
        public string DDB2_StartTime_ID { get; set; }
        public string DDB2_IsPersonalUse { get; set; }
        public string DDB2_IsYardMoves { get; set; }
        public string DDB2_IsManageEquipment { get; set; }
        public string DDED_IsExempt { get; set; }
        public string DDED_Exempt_Text { get; set; }
        public string DDED_CycleUSA_ID { get; set; }
        public string DDED_CycleCanada_ID { get; set; }
        public string DDED_Cargo_ID { get; set; }
        public string DDED_OperationMode_ID { get; set; }

    }

    public class DriverEmergencyContactModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Relationship { get; set; }
        public string Email { get; set; }

    }
    public class DriverAddressModel
    {
        public string ID { get; set; }
        public string Address_Type { get; set; }
        public string Country { get; set; }
        public string Country_Name { get; set; }
        public string State { get; set; }
        public string State_Name { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Zip_Code { get; set; }
        public string Address2 { get; set; }
        public string OtherAddress { get; set; }       

    }
}