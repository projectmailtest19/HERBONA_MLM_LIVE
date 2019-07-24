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
    public partial class CompanyList : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<CountryModel> _CountryModel = new List<CountryModel>();
        static List<ErrorModel> _errorDetail = new List<ErrorModel>();
        static List<CompanyModel> CompanyModel_list = new List<CompanyModel>();
        static List<UserSaveModel> _UserSaveModel = new List<UserSaveModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Login_user_ID"] == null || HttpContext.Current.Session["Login_user_ID"] == "")
            {
                Response.Redirect("Signup.aspx");

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
                    ds = db.SysFetchDataInDataSet("[GetCompanyList]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        CompanyModel_list = ds.Tables[0].AsEnumerable()
                          .Select(row => new CompanyModel
                          {
                              ID = row["ID"].ToString(),
                              CompanyName = row["CompanyName"].ToString(),
                              CEOName = row["CEOName"].ToString(),
                              MobileNo = row["MobileNo"].ToString(),
                              PhoneNo = row["PhoneNo"].ToString(),
                              Email = row["Email"].ToString(),
                              Country = row["Country"].ToString(),
                              City = row["City"].ToString(),
                              State = row["State"].ToString(),
                              CompanyType = row["CompanyType"].ToString(),
                              Address = row["Address"].ToString(),
                              WebsiteUrl = row["WebsiteUrl"].ToString(),
                              LogoPath = row["LogoPath"].ToString(),
                              IsActive = row["IsActive"].ToString()
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
                    ds = db.SysFetchDataInDataSet("[INSERT_COMPANY_DETAILS]", ht_param);
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

    }
}