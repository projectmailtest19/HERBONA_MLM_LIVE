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
   
    public partial class Company_Profile : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<CountryModel> _CountryModel = new List<CountryModel>();
        static List<ErrorModel> _ErrorModel = new List<ErrorModel>();
        static List<CompanyModel> _companylist = new List<CompanyModel>();
        static List<UserSaveModel> _UserSaveModel = new List<UserSaveModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Company_ID"] == null || HttpContext.Current.Session["Company_ID"] == "")
            {
                Response.Redirect("Login.aspx");

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
                        if (Data == "Edit")
                        {
                            _CountryModel.Clear();

                            ht_param.Clear();
                            ht_param.Add("@ID", ht["COMPANY_ID"].ToString());
                            ds = db.SysFetchDataInDataSet("[GetSelectedCompanyDetailsProfile]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                _companylist = ds.Tables[0].AsEnumerable()
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
                                      IsActive = row["IsActive"].ToString(),
                                      Contact_ID = row["Contact_ID"].ToString()
                                  }).ToList();
                            }
                            ReturnData["CompanyData"] = serializer.Serialize(_companylist);

                            GetStateforDefaultCountry(_companylist[0].Country);
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
                
                
               
                if (Type == "Update")
                {
                    _UserSaveModel.Clear();

                    ht_param.Clear();
                    ht_param.Add("@ID", ht["ID"]);
                    ht_param.Add("@CompanyName", ht["CompanyName"].ToString());
                    ht_param.Add("@CEOName", ht["CEOName"].ToString());
                    ht_param.Add("@MobileNo", ht["MobileNo"].ToString());
                    ht_param.Add("@PhoneNo", ht["PhoneNo"].ToString());
                    ht_param.Add("@Email", ht["Email"].ToString());
                    //ht_param.Add("@Country", ht["Country"].ToString());
                    if (ht["Country"].ToString() == "")
                    {
                        ht_param.Add("@Country", DBNull.Value);
                    }
                    else
                    {
                        ht_param.Add("@Country", ht["Country"].ToString());
                    }

                    //ht_param.Add("@State", ht["State"].ToString());
                    if (ht["State"].ToString() == "")
                    {
                        ht_param.Add("@State", DBNull.Value);
                    }
                    else
                    {
                        ht_param.Add("@State", ht["State"].ToString());
                    }
                    ht_param.Add("@City", ht["City"].ToString());
                    ht_param.Add("@CompanyType", ht["CompanyType"].ToString());
                    ht_param.Add("@Address", ht["Address"].ToString());
                    ht_param.Add("@WebsiteUrl", ht["WebsiteUrl"].ToString());
                    ht_param.Add("@LogoPath", ht["Logo"].ToString());
                    ht_param.Add("@MODE", ht["MODE"].ToString());
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
                    ReturnData["Update"] = serializer.Serialize(_UserSaveModel);                  

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