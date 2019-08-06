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
    public partial class TicketQueryReasonMaster : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();
        public static DataTable dt = new DataTable();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<ErrorModel> _ErrorModel = new List<ErrorModel>();
        static List<TicketQuery> _TicketQueryList = new List<TicketQuery>();
        static List<_TicketQueryReasonMaster> _TicketQueryReasonMasterList = new List<_TicketQueryReasonMaster>();
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
                //if (Type == "SaveVideo")
                //{
                //    if (Req == "SaveVideo")
                //    {
                //        ht_param.Clear();
                //        ht_param.Add("@Name", ht["Name"].ToString());
                //        ht_param.Add("@Description", ht["Description"].ToString());
                //        ht_param.Add("@VideoPath", ht["VideoPath"].ToString());
                //        ht_param.Add("@VideoThumbPath", ht["VideoThumbPath"].ToString());
                //        ht_param.Add("@VideoSize", ht["VideoSize"].ToString());
                //        ht_param.Add("@LoginUser_ID", ht["LoginUser_ID"].ToString());
                //        ht_param.Add("@BranchID", ht["BranchID"].ToString());
                //        ht_param.Add("@CompanyID", ht["CompanyID"].ToString());
                //        ds = db.SysFetchDataInDataSet("[Sp_Video_Insert]", ht_param);
                //        if (ds.Tables[0].Rows.Count > 0)
                //        {
                //            ht_param2.Clear();
                //            ReturnData["SaveVideo"] = serializer.Serialize(ht_param2);
                //        }
                //        else
                //        {
                //            _ErrorModel.Clear();
                //            ReturnData.Clear();
                //            ErrorModel _error = new ErrorModel();
                //            _error.Error = "2";
                //            _error.ErrorMessage = "Some problem occurred please try again later";
                //            _ErrorModel.Add(_error);
                //            ReturnData["ErrorDetail"] = serializer.Serialize(_ErrorModel);
                //            HttpContext.Current.Response.AppendHeader("ResponseHeader", "500");
                //        }
                //    }
                //}
                if (Type == "GetTicketQuery")
                {
                    if (Req == "GetTicketQuery")
                    {
                        _TicketQueryList.Clear();
                        ht_param.Clear();
                        ht_param.Add("@Branch_ID", ht["BranchID"].ToString());
                        ht_param.Add("@Company_ID", ht["CompanyID"].ToString());
                        ds = db.SysFetchDataInDataSet("[TicketQueryMaster_Select]", ht_param);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            _TicketQueryList = ds.Tables[0].AsEnumerable()
                                      .Select(row => new TicketQuery
                                      {
                                          id = row["id"].ToString(),
                                          name = row["name"].ToString(),
                                      }).ToList();

                        }
                        ReturnData["TicketQuery"] = serializer.Serialize(_TicketQueryList);
                    }
                }
                if (Type == "GetSavedTicketQueryList")
                {
                    if (Req == "GetSavedTicketQueryList")
                    {
                        _TicketQueryReasonMasterList.Clear();
                        ht_param.Clear();
                        ht_param.Add("@Branch_ID", ht["BranchID"].ToString());
                        ht_param.Add("@Company_ID", ht["CompanyID"].ToString());
                        ht_param.Add("@TicketID", ht["TicketID"].ToString());
                        ds = db.SysFetchDataInDataSet("[TicketQueryReasonMaster_Select]", ht_param);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            _TicketQueryReasonMasterList = ds.Tables[0].AsEnumerable()
                                      .Select(row => new _TicketQueryReasonMaster
                                      {
                                          id = row["id"].ToString(),
                                          name = row["name"].ToString(),
                                          PayScheduleNo = row["PayScheduleNo"].ToString(),
                                          CreditedAmount = row["CreditedAmount"].ToString(),
                                          EstimatedAmount = row["EstimatedAmount"].ToString(),
                                          Comments = row["Comments"].ToString(),
                                          orderid = row["orderid"].ToString(),
                                          Attatchments = row["Attatchments"].ToString(),
                                          subject = row["subject"].ToString(),
                                          IsActive = row["IsActive"].ToString(),
                                      }).ToList();

                        }
                        ReturnData["GetSavedTicketQueryList"] = serializer.Serialize(_TicketQueryReasonMasterList);
                    }
                }
                if (Type == "EditTicketQueryList")
                {
                    if (Req == "EditTicketQueryList")
                    {
                        _TicketQueryReasonMasterList.Clear();
                        ht_param.Clear();
                        ht_param.Add("@Branch_ID", ht["BranchID"].ToString());
                        ht_param.Add("@Company_ID", ht["CompanyID"].ToString());
                        ht_param.Add("@TicketID", ht["TicketID"].ToString());
                        ht_param.Add("@ID", ht["ID"].ToString());
                        ds = db.SysFetchDataInDataSet("[TicketQueryReasonMaster_Select]", ht_param);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            _TicketQueryReasonMasterList = ds.Tables[0].AsEnumerable()
                                      .Select(row => new _TicketQueryReasonMaster
                                      {
                                          id = row["id"].ToString(),
                                          name = row["name"].ToString(),
                                          PayScheduleNo = row["PayScheduleNo"].ToString(),
                                          CreditedAmount = row["CreditedAmount"].ToString(),
                                          EstimatedAmount = row["EstimatedAmount"].ToString(),
                                          Comments = row["Comments"].ToString(),
                                          orderid = row["orderid"].ToString(),
                                          Attatchments = row["Attatchments"].ToString(),
                                          subject = row["subject"].ToString(),
                                          IsActive = row["IsActive"].ToString(),
                                      }).ToList();

                        }
                        ReturnData["EditTicketQueryList"] = serializer.Serialize(_TicketQueryReasonMasterList);
                    }
                }
                if (Type == "SaveTicketQuery")
                {
                    if (Req == "SaveTicketQuery")
                    {
                        _TicketQueryReasonMasterList.Clear();
                        ht_param.Clear();
                        if (ht["ID"].ToString() != "")
                        {
                            ht_param.Add("@ID", ht["ID"].ToString());
                        }
                        ht_param.Add("@TicketID", ht["TicketID"].ToString());
                        ht_param.Add("@name", ht["name"].ToString());
                        ht_param.Add("@PayScheduleNo", ht["PayScheduleNo"].ToString());
                        ht_param.Add("@CreditedAmount", ht["CreditedAmount"].ToString());
                        ht_param.Add("@EstimatedAmount", ht["EstimatedAmount"].ToString());
                        ht_param.Add("@Comments", ht["Comments"].ToString());
                        ht_param.Add("@orderid", ht["orderid"].ToString());
                        ht_param.Add("@Attatchments", ht["Attatchments"].ToString());
                        ht_param.Add("@subject", ht["subject"].ToString());
                        ht_param.Add("@IsActive", ht["IsActive"].ToString());
                        ht_param.Add("@Branch_ID", ht["BranchID"].ToString());
                        ht_param.Add("@Company_ID", ht["CompanyID"].ToString());
                        ds = db.SysFetchDataInDataSet("[TicketQueryReasonMaster_Insert]", ht_param);
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
                        ReturnData["SaveTicketQuery"] = serializer.Serialize(ht_param);
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
    public class TicketQuery
    {
        public string id { get; set; }
        public string name { get; set; }
        public string IsActive { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Company_ID { get; set; }
        public string Branch_ID { get; set; }
    }

    public class _TicketQueryReasonMaster
    {
        public string id { get; set; }
        public string TicketQueryMasterId { get; set; }
        public string name { get; set; }
        public string PayScheduleNo { get; set; }
        public string CreditedAmount { get; set; }
        public string EstimatedAmount { get; set; }
        public string Comments { get; set; }
        public string orderid { get; set; }
        public string Attatchments { get; set; }
        public string subject { get; set; }
        public string IsActive { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Company_ID { get; set; }
        public string Branch_ID { get; set; }
    }
}