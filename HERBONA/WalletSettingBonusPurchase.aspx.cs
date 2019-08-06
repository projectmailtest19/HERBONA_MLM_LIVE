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
    public partial class WalletSettingBonusPurchase : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();
        public static DataTable dt = new DataTable();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<ErrorModel> _ErrorModel = new List<ErrorModel>();
        static List<WALLET_PAYMENT_TYPE> _WALLET_PAYMENT_TYPEList = new List<WALLET_PAYMENT_TYPE>();
        static List<TicketQueryReasonMaster> _TicketQueryReasonMasterList = new List<TicketQueryReasonMaster>();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static Hashtable AjaxTicketQueryMasterDetails(Hashtable ht, string Type, string Req)
        {
            ReturnData.Clear();
            serializer.MaxJsonLength = 1000000000;
            try
            {
                
                if (Type == "GetWALLET_PAYMENT_TYPE")
                {
                    if (Req == "GetWALLET_PAYMENT_TYPE")
                    {
                        _WALLET_PAYMENT_TYPEList.Clear();
                        ht_param.Clear();
                        ht_param.Add("@Branch_ID", ht["BranchID"].ToString());
                        ht_param.Add("@Company_ID", ht["CompanyID"].ToString());
                        ds = db.SysFetchDataInDataSet("[WALLET_PAYMENT_TYPE_Select]", ht_param);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            _WALLET_PAYMENT_TYPEList = ds.Tables[0].AsEnumerable()
                                      .Select(row => new WALLET_PAYMENT_TYPE
                                      {
                                          id = row["ID"].ToString(),
                                          name = row["NAME"].ToString(),
                                      }).ToList();

                        }
                        ReturnData["GetWALLET_PAYMENT_TYPE"] = serializer.Serialize(_WALLET_PAYMENT_TYPEList);
                    }
                }
                if (Type == "GetWallet_Setting_Bonus_PurchaseList")
                {
                    if (Req == "GetWallet_Setting_Bonus_PurchaseList")
                    {
                        _WALLET_PAYMENT_TYPEList.Clear();
                        ht_param.Clear();
                        ht_param.Add("@Branch_ID", ht["BranchID"].ToString());
                        ht_param.Add("@Company_ID", ht["CompanyID"].ToString()); 
                        ds = db.SysFetchDataInDataSet("[Wallet_Setting_Bonus_Purchase_Select]", ht_param);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            _WALLET_PAYMENT_TYPEList = ds.Tables[0].AsEnumerable()
                                      .Select(row => new WALLET_PAYMENT_TYPE
                                      {
                                          id = row["id"].ToString(),
                                          name = row["name"].ToString(),
                                          WALLET_PAYMENT_TYPE_ID = row["WALLET_PAYMENT_TYPE_ID"].ToString(),
                                          WALLET_PAYMENT_TYPE_NAME = row["WALLET_PAYMENT_TYPE_NAME"].ToString(),
                                      }).ToList();

                        }
                        ReturnData["GetWallet_Setting_Bonus_PurchaseList"] = serializer.Serialize(_WALLET_PAYMENT_TYPEList);
                    }
                }
                if (Type == "EditWallet_Setting_Bonus_Purchase")
                {
                    if (Req == "EditWallet_Setting_Bonus_Purchase")
                    {
                        _WALLET_PAYMENT_TYPEList.Clear();
                        ht_param.Clear();
                        ht_param.Add("@ID", ht["ID"].ToString());
                        ht_param.Add("@Branch_ID", ht["BranchID"].ToString());
                        ht_param.Add("@Company_ID", ht["CompanyID"].ToString());
                        ds = db.SysFetchDataInDataSet("[Wallet_Setting_Bonus_Purchase_Select]", ht_param);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            _WALLET_PAYMENT_TYPEList = ds.Tables[0].AsEnumerable()
                                      .Select(row => new WALLET_PAYMENT_TYPE
                                      {
                                          id = row["id"].ToString(),
                                          name = row["name"].ToString(),
                                          WALLET_PAYMENT_TYPE_ID = row["WALLET_PAYMENT_TYPE_ID"].ToString(),
                                          WALLET_PAYMENT_TYPE_NAME = row["WALLET_PAYMENT_TYPE_NAME"].ToString(),
                                      }).ToList();

                        }
                        ReturnData["EditWallet_Setting_Bonus_Purchase"] = serializer.Serialize(_WALLET_PAYMENT_TYPEList);
                    }
                }
                if (Type == "SaveWallet_Setting_Bonus_Purchase")
                {
                    if (Req == "SaveWallet_Setting_Bonus_Purchase")
                    { 
                        ht_param.Clear();
                        if (ht["ID"].ToString() != "")
                        {
                            ht_param.Add("@ID", ht["ID"].ToString());
                        } 
                        ht_param.Add("@name", ht["name"].ToString());
                        ht_param.Add("@WALLET_PAYMENT_TYPE_ID", ht["WALLET_PAYMENT_TYPE_ID"].ToString()); 
                        ht_param.Add("@Branch_ID", ht["BranchID"].ToString());
                        ht_param.Add("@Company_ID", ht["CompanyID"].ToString());
                        ds = db.SysFetchDataInDataSet("[Wallet_Setting_Bonus_Purchase_Insert]", ht_param);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["ERROR"].ToString() == "1")
                            {
                                ht_param.Clear();
                                ht_param.Add("Message", "Some problem occurred please try again later.");
                            }
                            else
                            {
                                ht_param.Clear();
                                ht_param.Add("Message", "Saved successfully");
                            }
                        }
                        ReturnData["SaveWallet_Setting_Bonus_Purchase"] = serializer.Serialize(ht_param);
                    }
                }
            }
            catch (Exception ex)
            {
                _ErrorModel.Clear();
                ReturnData.Clear();
                ErrorModel _error = new ErrorModel();
                _error.Error = "2";
                _error.ErrorMessage = "Some problem occurred please try again later";
                _ErrorModel.Add(_error);
                ReturnData["ErrorDetail"] = serializer.Serialize(_ErrorModel);
                HttpContext.Current.Response.AppendHeader("ResponseHeader", "500");
            }
            return ReturnData;
        }
    }
    public class WALLET_PAYMENT_TYPE
    {
        public  string id { get; set; }
        public  string name { get; set; } 
        public string WALLET_PAYMENT_TYPE_ID { get; set; }
        public string WALLET_PAYMENT_TYPE_NAME { get; set; }
    }
}
