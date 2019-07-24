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
    public partial class CreateShippingCharges : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<ErrorModel> _ErrorModel = new List<ErrorModel>();
        static List<UserSaveModel> _UserSaveModel = new List<UserSaveModel>();
        static List<ShippingChargesModel> _gstModel = new List<ShippingChargesModel>();
        static List<CountryModel> _CountryModel = new List<CountryModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Company_ID"] == null || HttpContext.Current.Session["Company_ID"] == "")
            {
                Response.Redirect("Signup.aspx");

            }
        }

        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static Hashtable TaxDetails(Hashtable ht, string Type, string Req)
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
                            ht_param.Clear();
                            ht_param.Add("@ID", ht["ID"].ToString());
                            ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                            ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                            ht_param.Add("@login_id", HttpContext.Current.Session["Login_user_ID"].ToString());
                            ds = db.SysFetchDataInDataSet("[GET_SHIPPING_CHARGES]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                _gstModel = ds.Tables[0].AsEnumerable()
                                  .Select(row => new ShippingChargesModel
                                  {
                                      ID = row["ID"].ToString(),
                                      DISTRICT_ID = row["DISTRICT_ID"].ToString(),
                                      CHARGE_PERCENTAGE = row["CHARGE_PERCENTAGE"].ToString(),
                                      CHARGE_AMOUNT = row["CHARGE_AMOUNT"].ToString(),
                                      DISTRICT_NAME = row["DISTRICT_NAME"].ToString(),
                                      country_id = row["country_id"].ToString(),
                                      state_id = row["state_id"].ToString(),
                                      IsActive = row["IsActive"].ToString()
                                  }).ToList();
                            }

                            ReturnData["TaxData"] = serializer.Serialize(_gstModel);

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
                            CountryModel_Detail.COUNTRY_ID = Convert.ToInt32(item["DISTRICT_ID"].ToString());
                            _CountryModel.Add(CountryModel_Detail);
                        }
                    }
                    ReturnData["District"] = serializer.Serialize(_CountryModel);
                }
                if (Type == "Save")
                {
                    _UserSaveModel.Clear();

                    ht_param.Clear();
                    ht_param.Add("@CHARGE_PERCENTAGE", ht["CHARGE_PERCENTAGE"].ToString());
                    ht_param.Add("@CHARGE_AMOUNT", ht["CHARGE_AMOUNT"].ToString());
                    ht_param.Add("@DISTRICT_ID", ht["DISTRICT_ID"].ToString());
                    ht_param.Add("@IsActive", ht["IsActive"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@login_id", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[SAVE_UPDATE_SHIPPING_CHARGES]", ht_param);
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
                }


                if (Type == "Update")
                {
                    _UserSaveModel.Clear();

                    ht_param.Clear();
                    ht_param.Add("@ID", ht["ID"]);
                    ht_param.Add("@CHARGE_PERCENTAGE", ht["CHARGE_PERCENTAGE"].ToString());
                    ht_param.Add("@CHARGE_AMOUNT", ht["CHARGE_AMOUNT"].ToString());
                    ht_param.Add("@DISTRICT_ID", ht["DISTRICT_ID"].ToString());
                    ht_param.Add("@IsActive", ht["IsActive"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@login_id", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[SAVE_UPDATE_SHIPPING_CHARGES]", ht_param);
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
    }
}