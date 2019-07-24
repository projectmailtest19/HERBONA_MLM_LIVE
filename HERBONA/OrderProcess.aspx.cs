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
    public partial class OrderProcess : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<ErrorModel> _ErrorModel = new List<ErrorModel>();
        static List<UserSaveModel> _UserSaveModel = new List<UserSaveModel>();
        static List<UserSaveModelWithID> _UserSaveModelWithID = new List<UserSaveModelWithID>();
        static List<Wallet_balanceModel> _Wallet_balanceModel = new List<Wallet_balanceModel>();
        static List<Payment_DetailsModel> _Payment_DetailsModel = new List<Payment_DetailsModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Company_ID"] == null || HttpContext.Current.Session["Company_ID"] == "")
            {
                Response.Redirect("Signup.aspx");

            }

        }

        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static Hashtable PaymentDetails(Hashtable ht, string Type, string Req)
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

                      
                        if (Data == "Wallet_Balance")
                        {
                            _Wallet_balanceModel.Clear();
                            ht_param.Clear();
                            ht_param.Add("@Order_Details_id", ht["Order_Details_id"].ToString());
                            ds = db.SysFetchDataInDataSet("[GET_MEMBER_WALLET_BALANCE]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                _Wallet_balanceModel = ds.Tables[0].AsEnumerable()
                                  .Select(row => new Wallet_balanceModel
                                  {
                                      Wallet_Balance = row["Wallet_Balance"].ToString()
                                  }).ToList();
                            }
                            ReturnData["Wallet_Balance"] = serializer.Serialize(_Wallet_balanceModel);
                        }

                        if (Data == "Payment_Details")
                        {
                            _Payment_DetailsModel.Clear();
                            ht_param.Clear();
                            ht_param.Add("@Order_Details_id", ht["Order_Details_id"].ToString());
                            ds = db.SysFetchDataInDataSet("[GET_MEMBER_SHIPPING]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                _Payment_DetailsModel = ds.Tables[0].AsEnumerable()
                                  .Select(row => new Payment_DetailsModel
                                  {
                                      SALES_AMOUNT = row["SALES_AMOUNT"].ToString(),
                                      SHIPPING = row["SHIPPING"].ToString(),
                                      NET_AMOUNT = row["NET_AMOUNT"].ToString()
                                  }).ToList();
                            }
                            ReturnData["Payment_Details"] = serializer.Serialize(_Payment_DetailsModel);
                        }

                    }
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

        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static Hashtable SaveOrderPaymentDetailsList(Hashtable ht, string Type, string Req, List<OrderPaymentDetailsList_Model> OrderPaymentDetailsList)
        {
            string Data = "";
            string obj = "";

            Hashtable ht_Blank = new Hashtable();
            Hashtable ReturnData = new Hashtable();
            DBFunctions db = new DBFunctions();
            DataTable dt = new DataTable();
            DataTable dt_OrderPaymentDetails = new DataTable();


            List<ErrorModel> _ErrorDetails = new List<ErrorModel>();

            ReturnData.Clear();
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            try
            {
                if (Type == "OrderPaymentDetails")
                {
                    _UserSaveModelWithID.Clear();


                    ht_param.Clear();

                    dt_OrderPaymentDetails = SaveParameters_OrderPaymentDetailsList(OrderPaymentDetailsList);
                    ht_param.Add("@UDT_ORDER_PAYMENT_DETAILS", dt_OrderPaymentDetails);
                    ht_param.Add("@Order_Details_id", ht["Order_Details_id"].ToString());
                    ds = db.SysFetchDataInDataSet("[SAVE_ORDER_PAYMENT_DETAILS]", ht_param);
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
                    ReturnData["OrderPaymentDetails"] = serializer.Serialize(_UserSaveModelWithID);

                }

                ErrorModel _error = new ErrorModel();
                _error.Error = "false";
                _error.ErrorMessage = "Success";
                _ErrorDetails.Add(_error);
                ReturnData["ErrorDetail"] = serializer.Serialize(_ErrorDetails);

                HttpContext.Current.Response.AppendHeader("ResponseHeader", "200");
            }
            catch (Exception ex)
            {

                ErrorModel _error = new ErrorModel();
                _error.Error = "true";
                _error.ErrorMessage = "Some problem occurred please try again later";//ex.ToString();
                _ErrorDetails.Add(_error);
                ReturnData["ErrorDetail"] = serializer.Serialize(_ErrorDetails);

                HttpContext.Current.Response.AppendHeader("ResponseHeader", "500");
            }


            return ReturnData;
        }
        public static DataTable SaveParameters_OrderPaymentDetailsList(List<OrderPaymentDetailsList_Model> OrderPaymentDetailsList)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NAME", typeof(string));
            dt.Columns.Add("AMOUNT", typeof(decimal));

            foreach (var item in OrderPaymentDetailsList)
            {
                dt.Rows.Add(item.NAME, item.AMOUNT);
            }

            return dt;
        }
        public class OrderPaymentDetailsList_Model
        {
            public string NAME { get; set; }
            public decimal AMOUNT { get; set; }

        }
    }
}