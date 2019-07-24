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
    public partial class CreateAddress : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<CountryModel> _CountryModel = new List<CountryModel>();
        static List<Cust_TypeModel> _Cust_TypeModel = new List<Cust_TypeModel>();
        static List<ErrorModel> _ErrorModel = new List<ErrorModel>();
        static List<AddressModel> _Addresslist = new List<AddressModel>();
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
        public static Hashtable AddressDetails(Hashtable ht, string Type, string Req)
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



                            _Cust_TypeModel.Clear();
                            ht_param.Clear();
                            ds = db.SysFetchDataInDataSet("[GetCust_type_List]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    Cust_TypeModel Cust_TypeModel_Detail = new Cust_TypeModel();
                                    Cust_TypeModel_Detail.Type = item["Type"].ToString();
                                    Cust_TypeModel_Detail.Cust_Type_ID = Convert.ToInt32(item["ID"].ToString());
                                    _Cust_TypeModel.Add(Cust_TypeModel_Detail);
                                }
                            }
                            ReturnData["Cust_Type"] = serializer.Serialize(_Cust_TypeModel);
                            GetStateforDefaultCountry(_CountryModel[0].COUNTRY_ID.ToString());
                        }
                        if (Data == "Edit")
                        {
                            _CountryModel.Clear();
                            _Cust_TypeModel.Clear();
                            ht_param.Clear();
                            ht_param.Add("@ID", ht["ID"].ToString());
                            ds = db.SysFetchDataInDataSet("[GetSelectedADRESSDetails]", ht_param);

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

                            GetStateforDefaultCountry(_Addresslist[0].Country);
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
                    _UserSaveModel.Clear();

                    ht_param.Clear();
                    ht_param.Add("@ID", ht["ID"]);
                    ht_param.Add("@Company_Name", ht["Company_Name"].ToString());
                   // ht_param.Add("@Customer_Type", ht["Customer_Type"].ToString());
                    if (ht["Customer_Type"].ToString() == "")
                    {
                        ht_param.Add("@Customer_Type", DBNull.Value);
                    }
                    else
                    {
                        ht_param.Add("@Customer_Type", ht["Customer_Type"].ToString());
                    }
                    ht_param.Add("@Street", ht["Street"].ToString());
                    ht_param.Add("@Apt_Suite_Other", ht["Apt_Suite_Other"].ToString());
                    ht_param.Add("@City", ht["City"].ToString());
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
                    ht_param.Add("@Zip_Code", ht["Zip_Code"].ToString());
                    ht_param.Add("@CellNo", ht["CellNo"].ToString());
                    ht_param.Add("@PhoneNo", ht["PhoneNo"].ToString());
                    ht_param.Add("@Fax", ht["Fax"].ToString());
                    ht_param.Add("@Email", ht["Email"].ToString());
                    ht_param.Add("@WebsiteUrl", ht["WebsiteUrl"].ToString());
                    ht_param.Add("@Contact", ht["Contact"].ToString());
                    ht_param.Add("@Notes", ht["Notes"].ToString());
                    ht_param.Add("@Motor_Carrier_Number", ht["Motor_Carrier_Number"].ToString());
                    ht_param.Add("@Tax_ID", ht["Tax_ID"].ToString());
                    ht_param.Add("@MODE", ht["MODE"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
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
                    ReturnData["Save"] = serializer.Serialize(_UserSaveModel);
                    //ReturnData["Save"] = serializer.Serialize("saved successfully.");

                }
               
            
                if (Type == "Update")
                {
                    _UserSaveModel.Clear();

                    ht_param.Clear();
                    ht_param.Add("@ID", ht["ID"]);
                    ht_param.Add("@Company_Name", ht["Company_Name"].ToString());
                    //ht_param.Add("@Customer_Type", ht["Customer_Type"].ToString());
                    if (ht["Customer_Type"].ToString() == "")
                    {
                        ht_param.Add("@Customer_Type", DBNull.Value);
                    }
                    else
                    {
                        ht_param.Add("@Customer_Type", ht["Customer_Type"].ToString());
                    }
                    ht_param.Add("@Street", ht["Street"].ToString());
                    ht_param.Add("@Apt_Suite_Other", ht["Apt_Suite_Other"].ToString());
                    ht_param.Add("@City", ht["City"].ToString());
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
                    ht_param.Add("@Zip_Code", ht["Zip_Code"].ToString());
                    ht_param.Add("@CellNo", ht["CellNo"].ToString());
                    ht_param.Add("@PhoneNo", ht["PhoneNo"].ToString());
                    ht_param.Add("@Fax", ht["Fax"].ToString());
                    ht_param.Add("@Email", ht["Email"].ToString());
                    ht_param.Add("@WebsiteUrl", ht["WebsiteUrl"].ToString());
                    ht_param.Add("@Contact", ht["Contact"].ToString());
                    ht_param.Add("@Notes", ht["Notes"].ToString());
                    ht_param.Add("@Motor_Carrier_Number", ht["Motor_Carrier_Number"].ToString());
                    ht_param.Add("@Tax_ID", ht["Tax_ID"].ToString());
                    ht_param.Add("@MODE", ht["MODE"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
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