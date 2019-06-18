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
    public partial class ShippingDetails : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<CountryModel> _CountryModel = new List<CountryModel>();
        static List<ErrorModel> _errorDetail = new List<ErrorModel>();
        static List<ShippingAddressModel> ShippingAddressModel_list = new List<ShippingAddressModel>();
        static List<ShippingMethodModel> ShippingMethodModel_list = new List<ShippingMethodModel>();
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
        public static Hashtable ContactDetails(Hashtable ht, string Type, string Req)
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
                if (Type == "FillShippingAddress")
                {
                    ShippingAddressModel_list.Clear();
                    ht_param.Clear();
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@Contact_id", ht["Contact_id"].ToString());
                    ds = db.SysFetchDataInDataSet("[GetShipping_Address]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        ShippingAddressModel_list = ds.Tables[0].AsEnumerable()
                          .Select(row => new ShippingAddressModel
                          {
                              id = row["id"].ToString(),
                              name = row["name"].ToString(),
                              addressline = row["addressline"].ToString(),
                              District_Name = row["District_Name"].ToString(),
                              State_Name = row["State_Name"].ToString(),
                              Country_Name = row["Country_Name"].ToString(),
                              pincode = row["pincode"].ToString(),
                              MobileNo = row["MobileNo"].ToString(),
                              is_default = row["is_default"].ToString()
                          }).ToList();
                    }
                    ReturnData["FillShippingAddress"] = serializer.Serialize(ShippingAddressModel_list);

                }
                if (Type == "FillShippingMethod")
                {
                    ShippingMethodModel_list.Clear();
                    ht_param.Clear();
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[GET_SHIPPING_METHOD]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        ShippingMethodModel_list = ds.Tables[0].AsEnumerable()
                          .Select(row => new ShippingMethodModel
                          {
                              ID = row["ID"].ToString(),
                              NAME = row["NAME"].ToString(),
                              CODE = row["CODE"].ToString(),
                              IsActive = row["IsActive"].ToString()
                          }).ToList();
                    }
                    ReturnData["FillShippingMethod"] = serializer.Serialize(ShippingMethodModel_list);

                }
                if (Type == "SaveAddress")
                {
                    _UserSaveModelWithID.Clear();

                    ht_param.Clear();
                    ht_param.Add("@Contact_ID", ht["Contact_ID"].ToString());
                    ht_param.Add("@Name", ht["Name"].ToString());
                    ht_param.Add("@MobileNo", ht["MobileNo"].ToString());
                    if (ht["country_id"].ToString() == "")
                    {
                        ht_param.Add("@country_id", DBNull.Value);
                    }
                    else
                    {
                        ht_param.Add("@country_id", ht["country_id"].ToString());
                    }

                    if (ht["state_id"].ToString() == "")
                    {
                        ht_param.Add("@state_id", DBNull.Value);
                    }
                    else
                    {
                        ht_param.Add("@state_id", ht["state_id"].ToString());
                    }
                    if (ht["district_id"].ToString() == "")
                    {
                        ht_param.Add("@district_id", DBNull.Value);
                    }
                    else
                    {
                        ht_param.Add("@district_id", ht["district_id"].ToString());
                    }
                    ht_param.Add("@addressline", ht["addressline"].ToString());
                    ht_param.Add("@pincode", ht["pincode"].ToString());
                    ht_param.Add("@city", ht["city"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[INSERT_Delivery_Address]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            UserSaveModelWithID ___UserSaveModelWithIDDetails = new UserSaveModelWithID();
                            ___UserSaveModelWithIDDetails.CustomErrorState = item["CustomErrorState"].ToString();
                            ___UserSaveModelWithIDDetails.CustomMessage = item["CustomMessage"].ToString();
                            ___UserSaveModelWithIDDetails.ID = item["ID"].ToString();
                            _UserSaveModelWithID.Add(___UserSaveModelWithIDDetails);
                        }
                    }
                    ReturnData["SaveAddress"] = serializer.Serialize(_UserSaveModelWithID);

                }

                if (Type == "SaveOrder_Details")
                {
                    _UserSaveModelWithID.Clear();

                    ht_param.Clear();
                    ht_param.Add("@Member_Id", ht["Member_Id"].ToString());
                    ht_param.Add("@Order_ID", ht["Order_ID"].ToString());
                    ht_param.Add("@ShippingMethod_ID", ht["ShippingMethod_ID"].ToString());
                    ht_param.Add("@Address_ID", ht["Address_ID"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[INSERT_Order_Details]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            UserSaveModelWithID ___UserSaveModelWithIDDetails = new UserSaveModelWithID();
                            ___UserSaveModelWithIDDetails.CustomErrorState = item["CustomErrorState"].ToString();
                            ___UserSaveModelWithIDDetails.CustomMessage = item["CustomMessage"].ToString();
                            ___UserSaveModelWithIDDetails.ID = item["ID"].ToString();
                            _UserSaveModelWithID.Add(___UserSaveModelWithIDDetails);
                        }
                    }
                    ReturnData["SaveOrder_Details"] = serializer.Serialize(_UserSaveModelWithID);

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