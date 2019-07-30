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
    public partial class Ticket_Create : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<ErrorModel> _ErrorModel = new List<ErrorModel>();      
        static List<UserSaveModel> _UserSaveModel = new List<UserSaveModel>();
        static List<ItemCategoryModel> _ItemCategoryModel = new List<ItemCategoryModel>();
        static List<gstModel> _gstModel = new List<gstModel>();
        static List<ItemDetailsModel> _ItemDetailsModel = new List<ItemDetailsModel>();
        static List<TicketQueryReasonMasterModel> _TicketQueryReasonMasterModel = new List<TicketQueryReasonMasterModel>();

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

                        if (Data == "PaySchedule")
                        {
                            _ItemCategoryModel.Clear();
                            ht_param.Clear();
                            ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                            ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                            ht_param.Add("@login_id", HttpContext.Current.Session["Login_user_ID"].ToString());
                            ds = db.SysFetchDataInDataSet("[get_PaySchedule]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    ItemCategoryModel ItemCategoryModel_Detail = new ItemCategoryModel();
                                    ItemCategoryModel_Detail.NAME = item["PaySchedule"].ToString();
                                    ItemCategoryModel_Detail.ID =  item["id"].ToString();
                                    _ItemCategoryModel.Add(ItemCategoryModel_Detail);
                                }
                            }
                            ReturnData["PaySchedule"] = serializer.Serialize(_ItemCategoryModel);
                        }
                        if (Data == "TicketQueryMaster")
                        {
                            _ItemCategoryModel.Clear();
                            ht_param.Clear();
                            ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                            ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                            ht_param.Add("@login_id", HttpContext.Current.Session["Login_user_ID"].ToString());
                            ds = db.SysFetchDataInDataSet("[get_TicketQueryMaster]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    ItemCategoryModel ItemCategoryModel_Detail = new ItemCategoryModel();
                                    ItemCategoryModel_Detail.NAME = item["name"].ToString();
                                    ItemCategoryModel_Detail.ID = item["id"].ToString();
                                    _ItemCategoryModel.Add(ItemCategoryModel_Detail);
                                }
                            }
                            ReturnData["TicketQueryMaster"] = serializer.Serialize(_ItemCategoryModel);
                        }
                        if (Data == "TicketQueryReasonMaster")
                        {
                            _TicketQueryReasonMasterModel.Clear();
                            ht_param.Clear();
                            ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                            ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                            ht_param.Add("@login_id", HttpContext.Current.Session["Login_user_ID"].ToString());
                            ht_param.Add("@TicketQueryMasterId", ht["TicketQueryMasterId"].ToString());
                            ds = db.SysFetchDataInDataSet("[get_TicketQueryReasonMaster]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    TicketQueryReasonMasterModel TicketQueryReasonMasterModel_Detail = new TicketQueryReasonMasterModel();
                                    TicketQueryReasonMasterModel_Detail.id = item["id"].ToString();
                                    TicketQueryReasonMasterModel_Detail.name = item["name"].ToString();
                                    TicketQueryReasonMasterModel_Detail.PayScheduleNo = item["PayScheduleNo"].ToString();
                                    TicketQueryReasonMasterModel_Detail.CreditedAmount = item["CreditedAmount"].ToString();
                                    TicketQueryReasonMasterModel_Detail.EstimatedAmount = item["EstimatedAmount"].ToString();
                                    TicketQueryReasonMasterModel_Detail.Comments = item["Comments"].ToString();
                                    TicketQueryReasonMasterModel_Detail.orderid = item["orderid"].ToString();
                                    TicketQueryReasonMasterModel_Detail.Attatchments = item["Attatchments"].ToString();
                                    TicketQueryReasonMasterModel_Detail.subject = item["subject"].ToString();
                                    _TicketQueryReasonMasterModel.Add(TicketQueryReasonMasterModel_Detail);
                                }
                            }
                            ReturnData["TicketQueryReasonMaster"] = serializer.Serialize(_TicketQueryReasonMasterModel);
                        }
                    }
                } 
              
                if (Type == "Save")
                {
                    _UserSaveModel.Clear();

                    ht_param.Clear();                   
                    ht_param.Add("@TicketQueryMasterId", ht["TicketQueryMasterId"].ToString());
                    ht_param.Add("@TicketQueryReasonMasterId", ht["TicketQueryReasonMasterId"].ToString());
                    ht_param.Add("@Contact_id", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ht_param.Add("@PayScheduleNo", ht["PayScheduleNo"].ToString());
                    ht_param.Add("@CreditedAmount", ht["CreditedAmount"].ToString());
                    ht_param.Add("@EstimatedAmount", ht["EstimatedAmount"].ToString());
                    ht_param.Add("@ORDER_NUMBER", ht["ORDER_NUMBER"].ToString());
                    ht_param.Add("@Attatchments", ht["Attatchments"].ToString());
                    ht_param.Add("@Subject", ht["Subject"].ToString());
                    ht_param.Add("@Comments", ht["Comments"].ToString()); 
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@login_id", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[TicketQuery_Insert]", ht_param);
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