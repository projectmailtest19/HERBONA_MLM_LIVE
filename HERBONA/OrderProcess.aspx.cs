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
                Response.Redirect("Login.aspx");

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


    }
}