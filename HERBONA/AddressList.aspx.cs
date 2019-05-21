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
    public partial class AddressList : System.Web.UI.Page
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
        static List<Cust_TypeModel> _Cust_TypeModel = new List<Cust_TypeModel>();
        static List<AddressModel> _Addresslist = new List<AddressModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Company_ID"] == null || HttpContext.Current.Session["Company_ID"] == "")
            {
                Response.Redirect("Login.aspx");

            }
        }
        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static Hashtable AddressDetails(Hashtable ht, string Type, string Req)
        {
            try
            {
                string[] words = null;
                string Data = Req;

                ReturnData.Clear();
               
                if (Type == "Fill")
                {
                    _Addresslist.Clear();
                    ht_param.Clear();
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[GetADDRESSList]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        _Addresslist = ds.Tables[0].AsEnumerable()
                          .Select(row => new AddressModel
                          {
                              ID = row["ID"].ToString(),
                              Company_Name = row["Company_Name"].ToString(),
                              Customer_Type = row["Customer_Type"].ToString(),
                              Street = row["Street"].ToString(),
                              Apt_Suite_Other = row["Apt_Suite_Other"].ToString(),
                              City = row["City"].ToString(),
                              Country = row["Country"].ToString(),
                              State = row["State"].ToString(),
                              Zip_Code = row["Zip_Code"].ToString(),
                              CellNo = row["CellNo"].ToString(),
                              PhoneNo = row["PhoneNo"].ToString(),
                              Fax = row["Fax"].ToString(),
                              Email = row["Email"].ToString(),
                              WebsiteUrl = row["WebsiteUrl"].ToString(),
                              Contact = row["Contact"].ToString(),
                              Notes = row["Notes"].ToString(),
                              Motor_Carrier_Number = row["Motor_Carrier_Number"].ToString(),
                              Tax_ID = row["Tax_ID"].ToString(),
                              IsActive = row["IsActive"].ToString()
                          }).ToList();
                    }
                    ReturnData["AddressData"] = serializer.Serialize(_Addresslist);

                }
              
                if (Type == "Delete")
                {
                    _UserSaveModel.Clear();

                    ht_param.Clear();
                    ht_param.Add("@ID", ht["ID"]);
                    ht_param.Add("@MODE", "DELETE");
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[INSERT_ADDRESS_DETAILS]", ht_param);
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
                    ReturnData["AddressData"] = serializer.Serialize(_UserSaveModel);
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