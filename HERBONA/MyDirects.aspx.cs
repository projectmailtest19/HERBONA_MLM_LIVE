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
    public partial class MyDirects : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<CountryModel> _CountryModel = new List<CountryModel>();
        static List<ErrorModel> _errorDetail = new List<ErrorModel>();
        static List<NoOfDirectsModel> NoOfDirectsModel_list = new List<NoOfDirectsModel>();
        static List<UserSaveModel> _UserSaveModel = new List<UserSaveModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Company_ID"] == null || HttpContext.Current.Session["Company_ID"] == "")
            {
                Response.Redirect("Signup.aspx");

            }

        }
        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static Hashtable ContactDetails(Hashtable ht, string Type, string Req)
        {
            try
            {
                string[] words = null;
                string Data = Req;

                ReturnData.Clear();
             
                if (Type == "Fill")
                {
                    NoOfDirectsModel_list.Clear();
                    ht_param.Clear();
                    ht_param.Add("@company_id", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@branch_id", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@login_id", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[Get_MyDirects]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        NoOfDirectsModel_list = ds.Tables[0].AsEnumerable()
                          .Select(row => new NoOfDirectsModel
                          {
                              MemberID = row["MemberID"].ToString(),
                              Name = row["Name"].ToString(),
                              RegistrationDate = row["RegistrationDate"].ToString(),
                              Position = row["Position"].ToString()
                          }).ToList();
                    }
                    ReturnData["AgentData"] = serializer.Serialize(NoOfDirectsModel_list);

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