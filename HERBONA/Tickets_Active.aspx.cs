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
    public partial class Tickets_Active : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<ErrorModel> _errorDetail = new List<ErrorModel>();
        static List<ActiveTicketModel> _ActiveTicketModel = new List<ActiveTicketModel>();
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
        public static Hashtable AllLoadDetails(Hashtable ht, string Type, string Req)
        {
            try
            {
                string[] words = null;
                string Data = Req;

                ReturnData.Clear();

                if (Type == "Fill")
                {

                    ht_param.Clear();
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    if (HttpContext.Current.Session["IsAgent"].ToString() == "1")
                    {
                        ds = db.SysFetchDataInDataSet("[TicketAgentActive_Get]", ht_param);
                    }
                    else
                    {
                        ds = db.SysFetchDataInDataSet("[TicketAdminActive_Get]", ht_param);
                    }
                    if (ds.Tables.Count > 0)
                    {
                        _ActiveTicketModel = ds.Tables[0].AsEnumerable()
                          .Select(row => new ActiveTicketModel
                          {
                              TickerNumber = row["TickerNumber"].ToString(),
                              TicketDate = row["TicketDate"].ToString(),
                              TicketLabel = row["TicketLabel"].ToString(),
                              QueryType = row["QueryType"].ToString(),
                              Status = row["Status"].ToString(),
                              PayScheduleNo = row["PayScheduleNo"].ToString(),
                              CreditedAmount = row["CreditedAmount"].ToString(),
                              EstimatedAmount = row["EstimatedAmount"].ToString(),
                              Attatchments = row["Attatchments"].ToString(),
                              Subject = row["Subject"].ToString(),
                              ORDER_NUMBER = row["ORDER_NUMBER"].ToString(),
                              AnsweredBy = row["AnsweredBy"].ToString(),
                              AssignedTO = row["AssignedTO"].ToString(),
                              ActionPendingFrom = row["ActionPendingFrom"].ToString(),
                          }).ToList();
                    }
                    ReturnData["LoadData"] = serializer.Serialize(_ActiveTicketModel);

                }
                //if (Type == "setStatus")
                //{
                //    _UserSaveModel.Clear();

                //    ht_param.Clear();
                //    ht_param.Add("@ID", ht["ID"]);                
                //    ht_param.Add("@IsActive", ht["IsActive"]);
                //    ht_param.Add("@login_id", HttpContext.Current.Session["Login_user_ID"].ToString());
                //    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                //    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                //    ds = db.SysFetchDataInDataSet("[SAVE_UPDATE_GST]", ht_param);
                //    if (ds.Tables.Count > 0)
                //    {
                //        foreach (DataRow item in ds.Tables[0].Rows)
                //        {
                //            UserSaveModel _UserSaveModelDetails = new UserSaveModel();
                //            _UserSaveModelDetails.CustomErrorState = item["CustomErrorState"].ToString();
                //            _UserSaveModelDetails.CustomMessage = item["CustomMessage"].ToString();
                //            _UserSaveModel.Add(_UserSaveModelDetails);
                //        }
                //    }
                //    ReturnData["setStatus"] = serializer.Serialize(_UserSaveModel);
                //}

                //if (Type == "Delete")
                //{
                //    _UserSaveModel.Clear();

                //    ht_param.Clear();
                //    ht_param.Add("@ID", ht["ID"]);
                //    ht_param.Add("@IsActive", ht["IsActive"]);
                //    ht_param.Add("@login_id", HttpContext.Current.Session["Login_user_ID"].ToString());
                //    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                //    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                //    ds = db.SysFetchDataInDataSet("[SAVE_UPDATE_GST]", ht_param);
                //    if (ds.Tables.Count > 0)
                //    {
                //        foreach (DataRow item in ds.Tables[0].Rows)
                //        {
                //            UserSaveModel _UserSaveModelDetails = new UserSaveModel();
                //            _UserSaveModelDetails.CustomErrorState = item["CustomErrorState"].ToString();
                //            _UserSaveModelDetails.CustomMessage = item["CustomMessage"].ToString();
                //            _UserSaveModel.Add(_UserSaveModelDetails);
                //        }
                //    }
                //    ReturnData["Delete"] = serializer.Serialize(_UserSaveModel);
                //}


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