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
    public partial class CreateCustomerDetails : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<CountryModel> _CountryModel = new List<CountryModel>();

        static List<ErrorModel> _ErrorModel = new List<ErrorModel>();
        static List<CustomerContactDetailsModel> _TruckLocationModel = new List<CustomerContactDetailsModel>();
        static List<CustomerDetailsModel> _CustomerDetailsModel = new List<CustomerDetailsModel>();
        static List<UserSaveModel> _UserSaveModel = new List<UserSaveModel>();
        static List<UserSaveModelWithID> _UserSaveModelWithID = new List<UserSaveModelWithID>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Company_ID"] == null || HttpContext.Current.Session["Company_ID"] == "")
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
                    words = null;
                    words = Req.Split('@');
                    for (int m = 0; words.Count() > m; m++)
                    {

                        Data = words[m].ToString();

                        if (Data == "Country")
                        {
                            _CountryModel.Clear();
                            ht_param.Clear();
                            ds = db.SysFetchDataInDataSet("[GetCountryList]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    CountryModel CountryModel_Detail = new CountryModel();
                                    CountryModel_Detail.Name = item["NAME"].ToString();
                                    CountryModel_Detail.COUNTRY_ID = Convert.ToInt32(item["COUNTRY_ID"].ToString());
                                    _CountryModel.Add(CountryModel_Detail);
                                }
                            }
                            ReturnData["Country"] = serializer.Serialize(_CountryModel);


                            GetStateforDefaultCountry(_CountryModel[0].COUNTRY_ID.ToString());

                        }
                        if (Data == "Fill1")
                        {
                            _CountryModel.Clear();
                            _CustomerDetailsModel.Clear();
                            ht_param.Clear();
                            ht_param.Add("@ID", ht["ID"].ToString());
                            ds = db.SysFetchDataInDataSet("[GetSelectedCustomerDetails]", ht_param);

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
                        if (Data == "ContactDetails")
                        {
                            _CountryModel.Clear();
                            _TruckLocationModel.Clear();
                            ht_param.Clear();
                            ht_param.Add("@BT_ID", ht["ID"].ToString());
                            ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                            ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                            ds = db.SysFetchDataInDataSet("[GET_CUSTOMER_DETAILS_Contact]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                _TruckLocationModel = ds.Tables[0].AsEnumerable()
                                  .Select(row => new CustomerContactDetailsModel
                                  {
                                      ID = row["ID"].ToString(),
                                      Contact_Name = row["Contact_Name"].ToString(),
                                      Designation = row["Designation"].ToString(),
                                      Email = row["Email"].ToString(),
                                      Phone = row["Phone"].ToString(),
                                      Fax = row["Fax"].ToString()
                                  }).ToList();
                            }
                            ReturnData["ContactDetails"] = serializer.Serialize(_TruckLocationModel);
                        }
                    }
                }

                if (Type == "State")
                {
                    _CountryModel.Clear();

                    ht_param.Clear();
                    ht_param.Add("@COUNTRY_ID", ht["COUNTRY_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[GetStateList]", ht_param);

                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            CountryModel CountryModel_Detail = new CountryModel();
                            CountryModel_Detail.Name = item["NAME"].ToString();
                            CountryModel_Detail.COUNTRY_ID = Convert.ToInt32(item["LOCATION_ID"].ToString());
                            _CountryModel.Add(CountryModel_Detail);
                        }
                    }
                    ReturnData["State"] = serializer.Serialize(_CountryModel);
                }


                if (Type == "Save")
                {
                    _UserSaveModelWithID.Clear();

                    ht_param.Clear();
                    ht_param.Add("@ID", ht["ID"]);
                    ht_param.Add("@Company_Name", ht["Company_Name"]);
                    ht_param.Add("@Account_Number", ht["Account_Number"]);
                    if (ht["Country"].ToString() == "")
                    {
                        ht_param.Add("@Country", DBNull.Value);
                    }
                    else
                    {
                        ht_param.Add("@Country", ht["Country"].ToString());
                    }

                    if (ht["State"].ToString() == "")
                    {
                        ht_param.Add("@State", DBNull.Value);
                    }
                    else
                    {
                        ht_param.Add("@State", ht["State"].ToString());
                    }
                    ht_param.Add("@City", ht["City"].ToString());
                    ht_param.Add("@Zip_Code", ht["Zip_Code"].ToString());
                    ht_param.Add("@Address1", ht["Address1"].ToString());
                    ht_param.Add("@Address2", ht["Address2"].ToString());
                    ht_param.Add("@Accnt_Payable_Email", ht["Accnt_Payable_Email"].ToString());
                  

                    ht_param.Add("@ContactID", ht["ContactID"].ToString());
                    ht_param.Add("@ContactName", ht["ContactName"].ToString());
                    ht_param.Add("@Designation", ht["Designation"].ToString());
                    ht_param.Add("@ContactEmail", ht["ContactEmail"].ToString());
                    ht_param.Add("@ContactPhoneNo", ht["ContactPhoneNo"].ToString());
                    ht_param.Add("@ContactFax", ht["ContactFax"].ToString());

                    ht_param.Add("@Mode", ht["MODE"].ToString());

                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[INSERT_CUSTOMER_DETAILS_Basic]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            UserSaveModelWithID _UserSaveModelIDDetails = new UserSaveModelWithID();
                            _UserSaveModelIDDetails.ID = item["ID"].ToString();
                            _UserSaveModelIDDetails.CustomErrorState = item["CustomErrorState"].ToString();
                            _UserSaveModelIDDetails.CustomMessage = item["CustomMessage"].ToString();
                            _UserSaveModelWithID.Add(_UserSaveModelIDDetails);
                        }
                    }
                    ReturnData["Save"] = serializer.Serialize(_UserSaveModelWithID);

                }
                if (Type == "Delete")
                {
                    _UserSaveModel.Clear();

                    ht_param.Clear();
                    ht_param.Add("@ID", ht["ID"]);
                    ht_param.Add("@MODE", "DELETE");              
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[INSERT_CUSTOMER_DETAILS_Contact]", ht_param);
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
                    ReturnData["Delete"] = serializer.Serialize(_UserSaveModel);               
                }       

                _ErrorModel.Clear();
                ErrorModel _error = new ErrorModel();
                _error.Error = "false";
                _error.ErrorMessage = "sucess";
                _ErrorModel.Add(_error);
                ReturnData["ErrorDetail"] = serializer.Serialize(_ErrorModel);
                HttpContext.Current.Response.AppendHeader("ResponseHeader", "200");

            }
            catch (Exception ex)
            {
                _ErrorModel.Clear();
                ReturnData.Clear();
                ErrorModel _error = new ErrorModel();
                _error.Error = "true";
                _error.ErrorMessage = "Some problem occurred please try again later";
                _ErrorModel.Add(_error);
                ReturnData["ErrorDetail"] = serializer.Serialize(_ErrorModel);
                HttpContext.Current.Response.AppendHeader("ResponseHeader", "500");
            }
            return ReturnData;
        }
     
        private static void GetStateforDefaultCountry(string countryID)
        {
            _CountryModel.Clear();

            ht_param.Clear();
            ht_param.Add("@COUNTRY_ID", countryID);
            ds = db.SysFetchDataInDataSet("[GetStateList]", ht_param);

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    CountryModel CountryModel_Detail = new CountryModel();
                    CountryModel_Detail.Name = item["NAME"].ToString();
                    CountryModel_Detail.COUNTRY_ID = Convert.ToInt32(item["LOCATION_ID"].ToString());
                    _CountryModel.Add(CountryModel_Detail);
                }
            }
            ReturnData.Remove("State");
            ReturnData["State"] = serializer.Serialize(_CountryModel);
        }
    }
}