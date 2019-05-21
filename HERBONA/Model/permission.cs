using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class permission_check
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string company_id { get; set; }
        public string serch { get; set; }
        public string UserID { get; set; }
    }
    public class EmployeeModel
    {
        //C1	C2	C3	C4	C5	C6	C7	Location	BLOODGROUP	WorkPlace	ExtensionNo	LoginName	LoginPassword	Grade	Team	IsRecieveNotification	HolidayGroup	ShiftGroupId	LastModifiedBy	ShiftRotationMasterId	ReportTo	ShiftType	OfficialPhone	OfficialMobile	PersonaleMailID	UIDNo	PANNo	VoterIdNo	EffectiveFrom	ShiftPatternAssignedOn	MultiShiftGroupId	AndroidDeviceIMEINo	IsMarkAndroidWebAttendance	SalaryId	EmployeeId	GrossSalary	JoingDate	ProvisionMonth	ProvisionCompletedDate	UserName	UserPassword	CreatedBy	CreatedDate	ModifiedBy	ModifiedDate	LeaveId	EmployeeId	 	CreatedBy	CreatedDate	ModifiedBy	ModifiedDate

        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public string StringCode { get; set; }
        public string NumericCode { get; set; }
        public string Gender { get; set; }
        public string CompanyId { get; set; }
        public string DepartmentId { get; set; }
        public string Designation { get; set; }
        public string CategoryId { get; set; }
        public string DOJ { get; set; }
        public string DOR { get; set; }
        public string DOC { get; set; }
        public string EmployeeCodeInDevice { get; set; }
        public string EmployeeRFIDNumber { get; set; }
        public string EmployementType { get; set; }
        public string EmployeeDevicePassword { get; set; }
        public string EmployeeDeviceGroup { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string ResidentialAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Nomenee1 { get; set; }
        public string Nomenee2 { get; set; }
        public string Remarks { get; set; }
        public string RecordStatus { get; set; }

        public string PANNo { get; set; }
        public string VoterIdNo { get; set; }
        public string GrossSalary { get; set; }
        public string DepartmentFName { get; set; }
        public string OtherInfoId { get; set; }
        public string message { get; set; }



    }
    public class MenuModel
    {

        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string URL { get; set; }
        public string ParentId { get; set; }
        public string IsActive { get; set; }
        public string IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string Icon { get; set; }
    }
    public class PermissionModel
    {
        // Permission_ID, MenuID, UserID, B_Add, B_Edit, B_Delete, B_View, Prient, Status, company_id, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate
        public string Role_ID { get; set; }
        public string Role_Name { get; set; }
        public string Permission_ID { get; set; }
        public string MenuID { get; set; }
        public string MenuName { get; set; }
        public string B_Add { get; set; }
        public string B_Edit { get; set; }
        public string B_Delete { get; set; }
        public string B_View { get; set; }
        public string B_Payment { get; set; }
        public string Url { get; set; }
        public string Prient { get; set; }
        public string Status { get; set; }
        public string company_id { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }

    }
}
