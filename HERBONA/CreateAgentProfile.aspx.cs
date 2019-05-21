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
   
    public partial class CreateAgentProfile : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<CountryModel> _CountryModel = new List<CountryModel>();
        static List<ErrorModel> _ErrorModel = new List<ErrorModel>();
        static List<ContactModel> _Contactlist = new List<ContactModel>();
        static List<UserSaveModel> _UserSaveModel = new List<UserSaveModel>();
        static List<Role_ddl_Model> _Role_ddl_Model = new List<Role_ddl_Model>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Company_ID"] == null || HttpContext.Current.Session["Company_ID"] == "")
            {
                Response.Redirect("Login.aspx");

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
                        }

                      

                        if (Data == "Edit")
                        {
                            _CountryModel.Clear();

                            ht_param.Clear();
                            ht_param.Add("@ID", ht["ID"].ToString());
                            ds = db.SysFetchDataInDataSet("[GetSelectedContactDetailsProfile]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                _Contactlist = ds.Tables[0].AsEnumerable()
                                 .Select(row => new ContactModel
                                 {
                                     ID = row["ID"].ToString(),
                                     Name = row["Name"].ToString(),
                                     RName = row["RoleId"].ToString(),
                                     MobileNo = row["MobileNo"].ToString(),
                                     PhoneNo = row["PhoneNo"].ToString(),
                                     Email = row["Email"].ToString(),
                                     Country = row["Country"].ToString(),
                                     City = row["City"].ToString(),
                                     State = row["State"].ToString(),                                 
                                     Address = row["Address"].ToString(),
                                     WebsiteUrl = row["WebsiteUrl"].ToString(),
                                     LogoPath = row["LogoPath"].ToString(),
                                     IsActive = row["IsActive"].ToString()
                                 }).ToList();
                            }
                            ReturnData["ContactData"] = serializer.Serialize(_Contactlist);
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
                if (Type == "District")
                {
                    _CountryModel.Clear();

                    ht_param.Clear();
                    ht_param.Add("@State_ID", ht["State_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[GetDistrictList]", ht_param);

                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            CountryModel CountryModel_Detail = new CountryModel();
                            CountryModel_Detail.Name = item["NAME"].ToString();
                            CountryModel_Detail.COUNTRY_ID = Convert.ToInt32(item["District_ID"].ToString());
                            _CountryModel.Add(CountryModel_Detail);
                        }
                    }
                    ReturnData["District"] = serializer.Serialize(_CountryModel);
                }



                if (Type == "Update")
                {
                    _UserSaveModel.Clear();

                    ht_param.Clear();
                    ht_param.Add("@ID", ht["ID"]);
                    ht_param.Add("@Name", ht["Name"].ToString());
                    // ht_param.Add("@RoleId", ht["RoleId"].ToString());
                    if (ht["RoleId"].ToString() == "")
                    {
                        ht_param.Add("@RoleId", DBNull.Value);
                    }
                    else
                    {
                        ht_param.Add("@RoleId", ht["RoleId"].ToString());
                    }
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
                   // ht_param.Add("@Type", ht["Type"].ToString());
                    ht_param.Add("@Address", ht["Address"].ToString());
                    ht_param.Add("@WebsiteUrl", ht["WebsiteUrl"].ToString());
                    ht_param.Add("@LogoPath", ht["Logo"].ToString());
                    ht_param.Add("@MODE", ht["MODE"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[INSERT_Contact_DETAILS]", ht_param);
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
                    //ReturnData["Update"] = serializer.Serialize("updated successfully.");

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
    }
}