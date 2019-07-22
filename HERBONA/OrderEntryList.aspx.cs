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
    public partial class OrderEntryList : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();     
        static List<ErrorModel> _errorDetail = new List<ErrorModel>();
        static List<OrderEntryListModel> _OrderEntryListModel = new List<OrderEntryListModel>();
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
        public static Hashtable AllLoadDetails(Hashtable ht, string Type, string Req)
        {
            try
            {
                string[] words = null;
                string Data = Req;

                ReturnData.Clear();
              
                if (Type == "Fill")
                {
                    if (Data == "LoadList")
                    {
                        ht_param.Clear();
                        ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                        ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                        ht_param.Add("@login_id", HttpContext.Current.Session["Login_user_ID"].ToString());
                        ds = db.SysFetchDataInDataSet("[GET_ORDER_ENTRY]", ht_param);
                        if (ds.Tables.Count > 0)
                        {
                            _OrderEntryListModel = ds.Tables[0].AsEnumerable()
                              .Select(row => new OrderEntryListModel
                              {
                                  ID = row["ID"].ToString(),
                                  MEMEBER_ID = row["MEMEBER_ID"].ToString(),
                                  Account_Number = row["Account_Number"].ToString(),
                                  ORDER_DATE = row["ORDER_DATE"].ToString(),
                                  ORDER_NUMBER = row["ORDER_NUMBER"].ToString(),
                                  INVOICE_DATE = row["INVOICE_DATE"].ToString(),
                                  INVOICE_NUMBER = row["INVOICE_NUMBER"].ToString(),
                                  PAYMENT_STATUS = row["PAYMENT_STATUS"].ToString(),
                                  ModeOfPayment = row["ModeOfPayment"].ToString(),
                                  TOTAL_SVP = row["TOTAL_SVP"].ToString(),
                                  TOTAL_AMOUNT = row["TOTAL_AMOUNT"].ToString(),
                                  ORDER_TYPE = row["ORDER_TYPE"].ToString(),
                                  IsActive = row["IsActive"].ToString(),
                                  MEMEBER_NAME = row["MEMEBER_NAME"].ToString()
                              }).ToList();
                        }
                        ReturnData["LoadData"] = serializer.Serialize(_OrderEntryListModel);
                    }
                    if (Data == "Search")
                    {
                        ht_param.Clear();
                        ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                        ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                        ht_param.Add("@login_id", HttpContext.Current.Session["Login_user_ID"].ToString());
                        if (ht["ORDER_NUMBER"].ToString() == "")
                        {
                            ht_param.Add("@ORDER_NUMBER", DBNull.Value);
                        }
                        else
                        {
                            ht_param.Add("@ORDER_NUMBER", ht["ORDER_NUMBER"].ToString());
                        }
                        if (ht["FROM_ORDER_DATE"].ToString() == "")
                        {
                            ht_param.Add("@FROM_ORDER_DATE", DBNull.Value);
                        }
                        else
                        {
                            ht_param.Add("@FROM_ORDER_DATE", ht["FROM_ORDER_DATE"].ToString());
                        }
                        if (ht["TO_ORDER_DATE"].ToString() == "")
                        {
                            ht_param.Add("@TO_ORDER_DATE", DBNull.Value);
                        }
                        else
                        {
                            ht_param.Add("@TO_ORDER_DATE", ht["TO_ORDER_DATE"].ToString());
                        }
                        ds = db.SysFetchDataInDataSet("[GET_ORDER_ENTRY]", ht_param);
                        if (ds.Tables.Count > 0)
                        {
                            _OrderEntryListModel = ds.Tables[0].AsEnumerable()
                              .Select(row => new OrderEntryListModel
                              {
                                  ID = row["ID"].ToString(),
                                  MEMEBER_ID = row["MEMEBER_ID"].ToString(),
                                  Account_Number = row["Account_Number"].ToString(),
                                  ORDER_DATE = row["ORDER_DATE"].ToString(),
                                  ORDER_NUMBER = row["ORDER_NUMBER"].ToString(),
                                  INVOICE_DATE = row["INVOICE_DATE"].ToString(),
                                  INVOICE_NUMBER = row["INVOICE_NUMBER"].ToString(),
                                  PAYMENT_STATUS = row["PAYMENT_STATUS"].ToString(),
                                  ModeOfPayment = row["ModeOfPayment"].ToString(),
                                  TOTAL_SVP = row["TOTAL_SVP"].ToString(),
                                  TOTAL_AMOUNT = row["TOTAL_AMOUNT"].ToString(),
                                  ORDER_TYPE = row["ORDER_TYPE"].ToString(),
                                  IsActive = row["IsActive"].ToString(),
                                  MEMEBER_NAME = row["MEMEBER_NAME"].ToString()
                              }).ToList();
                        }
                        ReturnData["LoadData"] = serializer.Serialize(_OrderEntryListModel);
                    }
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