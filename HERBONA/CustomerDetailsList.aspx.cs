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
    public partial class CustomerDetailsList : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<CountryModel> _CountryModel = new List<CountryModel>();
        static List<ErrorModel> _errorDetail = new List<ErrorModel>();
        static List<CustomerDetailsModel> _CustomerDetailsModel = new List<CustomerDetailsModel>();
        static List<UserSaveModel> _UserSaveModel = new List<UserSaveModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Login_user_ID"] == null || HttpContext.Current.Session["Login_user_ID"] == "")
            {
                Response.Redirect("Login.aspx");

            }
        }
        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static Hashtable CustomerDetails(Hashtable ht, string Type, string Req)
        {
            try
            {
                string[] words = null;
                string Data = Req;

                ReturnData.Clear();

                if (Type == "Fill")
                {
                    _CustomerDetailsModel.Clear();
                    ht_param.Clear();
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[GetCustomerDetailsList]", ht_param);
                   
                    if (ds.Tables.Count > 0)
                    {
                        _CustomerDetailsModel = ds.Tables[0].AsEnumerable()
                          .Select(row => new CustomerDetailsModel
                          {
                              ID = row["ID"].ToString(),
                              Company_Name = row["Company_Name"].ToString(),
                              Account_Number = row["Account_Number"].ToString(),
                              Country = row["Country"].ToString(),
                              State = row["State"].ToString(),
                              City = row["City"].ToString(),
                              Zip_Code = row["Zip_Code"].ToString(),
                              Address1 = row["Address1"].ToString(),
                              Address2 = row["Address2"].ToString(),
                              Accnt_Payable_Email = row["Accnt_Payable_Email"].ToString(),
                              IsActive = row["IsActive"].ToString()
                          }).ToList();
                    }
                    ReturnData["BasicData"] = serializer.Serialize(_CustomerDetailsModel);
                }

                if (Type == "Delete")
                {
                    _UserSaveModel.Clear();

                    ht_param.Clear();
                    ht_param.Add("@ID", ht["ID"]);
                    //  ht_param.Add("@MODE", "DELETE");
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[CustomerDetailsDelete]", ht_param);
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
                    ReturnData["CustomerData"] = serializer.Serialize(_UserSaveModel);
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