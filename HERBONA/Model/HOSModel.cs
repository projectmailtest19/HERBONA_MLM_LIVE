using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class HOS_DriverModel
    {
        public string ID { get; set; }
        public string Driver_ID { get; set; }
        public string Driver_Name { get; set; }
        public string Vehicle_ID { get; set; }
        public string Vehicle_Name { get; set; }
        public string Status { get; set; }
        public string Last_Contact { get; set; }
        public string Last_Position { get; set; }
        public string Until_Break { get; set; }
        public string Drive_Left { get; set; }
        public string Shift_Left { get; set; }
        public string Cycle_Left { get; set; }
        public string Gain_Time_At { get; set; }
        public string Time_Gained { get; set; }
        public string Next_Violation { get; set; }
        public string Time_of_Next_Violation { get; set; }
        public string Uncertified_Logs { get; set; }
        public string Violation { get; set; }
    }
    public class HOS_ViolationsModel
    {
        public string ID { get; set; }
        public string Driver_ID { get; set; }
        public string Driver_Name { get; set; }
        public string Date_Time { get; set; }
        public string Violation_Type_ID { get; set; }
    }
    public class HOS_UnidentifiedDrivingModel
    {
        public string ID { get; set; }
        public string Vehicle_ID { get; set; }
        public string Vehicle_Name { get; set; }
        public string VIN { get; set; }
        public string Date_Time { get; set; }
        public string Event_ID { get; set; }
        public string Event_Name { get; set; }
        public string Location { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Nearest_Terminal_Miles { get; set; }
        public string Nearest_Terminal_Code { get; set; }
        public string Start_Odometer { get; set; }
        public string End_Odometer { get; set; }
        public string Accumulated_Miles { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }
    }

    public class HOS_MalfunctionModel
    {
        public string ID { get; set; }
        public string Malfunction_Type_ID { get; set; }
        public string Vehicle_ID { get; set; }
        public string Vehicle_Name { get; set; }
        public string Driver_ID { get; set; }
        public string Driver_Name { get; set; }
        public string VIN { get; set; }
        public string Date_Time { get; set; }
        public string Event_ID { get; set; }
        public string Event_Name { get; set; }
        public string Remark { get; set; }
        public string Status { get; set; }
    }


    public class DriverCycleRulesModel
    {
        public string ID { get; set; }
        public string Cycle_Name { get; set; }
        public string Cycle { get; set; }
        public string Shift_Limit { get; set; }
        public string Drive_Limit { get; set; }
        public string Until_Break { get; set; }
        public string Break_Left { get; set; }
        public string Cycle_Description { get; set; }
        public string IsActive { get; set; }
    }
}