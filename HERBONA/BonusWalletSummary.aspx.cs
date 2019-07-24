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
    public partial class BonusWalletSummary : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();     
        static List<ErrorModel> _errorDetail = new List<ErrorModel>();
        static List<PurchaseWalletSummaryModel> _PurchaseWalletSummaryModel = new List<PurchaseWalletSummaryModel>();
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
                        ds = db.SysFetchDataInDataSet("[get_Bonus_Wallet_Summary]", ht_param);
                        if (ds.Tables.Count > 0)
                        {
                            _PurchaseWalletSummaryModel = ds.Tables[0].AsEnumerable()
                              .Select(row => new PurchaseWalletSummaryModel
                              {
                                  Transaction_Date = row["Transaction_Date"].ToString(),
                                  PayShedule = row["PayShedule"].ToString(),
                                  Credited_Amount = row["Credited_Amount"].ToString(),
                                  Debited_Amount = row["Debited_Amount"].ToString(),
                                  Balance = row["Balance"].ToString(),
                                  Type = row["Type"].ToString(),
                                  Narration = row["Narration"].ToString()
                              }).ToList();
                        }
                        ReturnData["LoadData"] = serializer.Serialize(_PurchaseWalletSummaryModel);
                    }
                    if (Data == "Search")
                    {
                        ht_param.Clear();
                        ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                        ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                        ht_param.Add("@login_id", HttpContext.Current.Session["Login_user_ID"].ToString());                       
                        if (ht["FROM_DATE"].ToString() == "")
                        {
                            ht_param.Add("@FROM_DATE", DBNull.Value);
                        }
                        else
                        {
                            ht_param.Add("@FROM_DATE", ht["FROM_DATE"].ToString());
                        }
                        if (ht["TO_DATE"].ToString() == "")
                        {
                            ht_param.Add("@TO_DATE", DBNull.Value);
                        }
                        else
                        {
                            ht_param.Add("@TO_DATE", ht["TO_DATE"].ToString());
                        }
                        ds = db.SysFetchDataInDataSet("[get_Bonus_Wallet_Summary]", ht_param);
                        if (ds.Tables.Count > 0)
                        {
                            _PurchaseWalletSummaryModel = ds.Tables[0].AsEnumerable()
                            .Select(row => new PurchaseWalletSummaryModel
                            {
                                Transaction_Date = row["Transaction_Date"].ToString(),
                                PayShedule = row["PayShedule"].ToString(),
                                Credited_Amount = row["Credited_Amount"].ToString(),
                                Debited_Amount = row["Debited_Amount"].ToString(),
                                Balance = row["Balance"].ToString(),
                                Type = row["Type"].ToString(),
                                Narration = row["Narration"].ToString()
                            }).ToList();
                        }
                        ReturnData["LoadData"] = serializer.Serialize(_PurchaseWalletSummaryModel);
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