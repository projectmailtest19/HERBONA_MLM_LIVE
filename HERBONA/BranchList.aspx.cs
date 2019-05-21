using SmartTrucking.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartTrucking
{
    public partial class BranchList : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<CountryModel> _CountryModel = new List<CountryModel>();
        static List<ErrorModel> _errorDetail = new List<ErrorModel>();
        static List<BranchModel> CompanyModel_list = new List<BranchModel>();
        static List<UserSaveModel> _UserSaveModel = new List<UserSaveModel>();
        static List<ErrorModel> _ErrorModel = new List<ErrorModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Company_ID"] != null)
                {
                    HttpContext.Current.Session["Company_ID"] = Request.QueryString["Company_ID"];
                }
            }
        }
        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static Hashtable CompanyDetails(Hashtable ht, string Type, string Req)
        {
            try
            {
                string[] words = null;
                string Data = Req;

                ReturnData.Clear();

                if (Type == "Fill")
                {
                    _CountryModel.Clear();
                    ht_param.Clear();
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[GetBranchList]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        CompanyModel_list = ds.Tables[0].AsEnumerable()
                          .Select(row => new BranchModel
                          {
                              ID = row["ID"].ToString(),
                              Name = row["Name"].ToString(),
                              Company_ID = row["Company_ID"].ToString(),
                              Company = row["Company"].ToString(),
                              HODName = row["HODName"].ToString(),
                              MobileNo = row["MobileNo"].ToString(),
                              PhoneNo = row["PhoneNo"].ToString(),
                              Email = row["Email"].ToString(),
                              Country = row["Country"].ToString(),
                              City = row["City"].ToString(),
                              State = row["State"].ToString(),
                              Address = row["Address"].ToString(),
                              LogoPath = row["LogoPath"].ToString(),
                              IsActive = row["IsActive"].ToString(),
                              Contact_ID = row["Contact_ID"].ToString(),                              
                          }).ToList();
                    }
                    ReturnData["CompanyData"] = serializer.Serialize(CompanyModel_list);

                }


                if (Type == "Delete")
                {
                    _UserSaveModel.Clear();
                    ht_param.Clear();
                    ht_param.Add("@ID", ht["COMPANY_ID"]);
                    ht_param.Add("@MODE", "DELETE");
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    db.SysAddUpdateDelete("[INSERT_BRANCH_DETAILS]", ref ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            UserSaveModel _UserSaveModelDetails = new UserSaveModel();
                            _UserSaveModelDetails.CustomErrorState = item["CustomErrorState"].ToString();
                            _UserSaveModelDetails.CustomMessage = item["CustomMessage"].ToString();
                            _UserSaveModel.Add(_UserSaveModelDetails);
                        }
                    }
                    ReturnData["CompanyData"] = serializer.Serialize(_UserSaveModel);
                    //ReturnData["CompanyData"] = serializer.Serialize("deleted successfully.");
                }



                _errorDetail.Clear();
                ErrorModel _error = new ErrorModel();
                _error.Error = "false";
                _error.ErrorMessage = "Success";
                _errorDetail.Add(_error);
                ReturnData["ErrorDetail"] = serializer.Serialize(_errorDetail);

                HttpContext.Current.Response.AppendHeader("ResponseHeader", "200");


            }
            catch (Exception ex)
            {
                _errorDetail.Clear();
                ErrorModel _error = new ErrorModel();
                _error.Error = "true";
                _error.ErrorMessage = "Some problem occurred please try again later";
                _errorDetail.Add(_error);
                ReturnData["ErrorDetail"] = serializer.Serialize(_errorDetail);
                HttpContext.Current.Response.AppendHeader("ResponseHeader", "500");
            }
            return ReturnData;
        }



        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static Hashtable LoginDetails(Hashtable ht, string Type, string Req)
        {
            List<PermissionModel> _PermissionModelList = new List<PermissionModel>();

            ReturnData.Clear();
            try
            {

                if (Type == "Login")
                {
                    if (Req == "NormalLogin")
                    {


                        _ErrorModel.Clear();
                        ReturnData.Clear();
                        ErrorModel _error = new ErrorModel();
                        _error.Error = "0";
                        _error.ErrorMessage = "Sucess";
                        _ErrorModel.Add(_error);
                        ReturnData["ErrorDetail"] = serializer.Serialize(_ErrorModel);

                        ht_param2.Clear();
                        ds.Clear();
                        ht_param.Clear();
                        ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                        ht_param.Add("@Contact_ID", ht["Contact_ID"].ToString());
                        ds = db.SysFetchDataInDataSet("[LOGIN_CHECK_BY_BRANCH_CONTACT]", ht_param);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["ERROR_ID"].ToString() == "0")
                            {
                                ht_param2.Add("MENU", ds.Tables[0].Rows[0]["MENU"].ToString().Trim());

                            }
                        }

                        serializer.MaxJsonLength = 1000000000;

                        _PermissionModelList.Clear();

                        if (ds.Tables.Count >= 2)
                        {

                            _PermissionModelList = ds.Tables[1].AsEnumerable()
                              .Select(row => new PermissionModel
                              {
                                  Url = row["url"].ToString(),
                                  MenuID = row["ID"].ToString(),
                                  MenuName = row["MenuName"].ToString(),
                                  Role_ID = row["RoleID"].ToString(),
                                  B_Add = row["B_Add"].ToString(),
                                  B_Edit = row["B_Edit"].ToString(),
                                  B_Delete = row["B_Delete"].ToString(),
                                  B_View = row["B_View"].ToString(),
                                  Status = row["Status"].ToString(),
                              }).ToList();
                            ReturnData["PagePermission"] = serializer.Serialize(_PermissionModelList);
                        }

                        ReturnData["Login"] = serializer.Serialize(ht_param2);


                    }
                    else
                    {
                        _ErrorModel.Clear();
                        ReturnData.Clear();
                        ErrorModel _error = new ErrorModel();
                        _error.Error = "2";
                        _error.ErrorMessage = "Some problem occurred please try again later";
                        _ErrorModel.Add(_error);
                        ReturnData["ErrorDetail"] = serializer.Serialize(_ErrorModel);
                        HttpContext.Current.Response.AppendHeader("ResponseHeader", "500");

                    }
                }

            }
            catch (Exception ex)
            {
                _ErrorModel.Clear();
                ReturnData.Clear();
                ErrorModel _error = new ErrorModel();
                _error.Error = "2";
                _error.ErrorMessage = "Some problem occurred please try again later";
                _ErrorModel.Add(_error);
                ReturnData["ErrorDetail"] = serializer.Serialize(_ErrorModel);
                HttpContext.Current.Response.AppendHeader("ResponseHeader", "500");
            }
            return ReturnData;
        }
    }
}