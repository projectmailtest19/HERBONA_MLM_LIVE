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
    public partial class Ticket_Details : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<ErrorModel> _ErrorModel = new List<ErrorModel>();
        static List<UserSaveModel> _UserSaveModel = new List<UserSaveModel>();
        static List<ActiveTicketModel> _ActiveTicketModel = new List<ActiveTicketModel>();
        static List<ActiveTicketCommentModel> _ActiveTicketCommentModel = new List<ActiveTicketCommentModel>();

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


                        ht_param.Clear();
                        ht_param.Add("@TickerNumber", ht["TickerNumber"].ToString());
                        ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                        ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                        ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                        ds = db.SysFetchDataInDataSet("[TicketView_Get]", ht_param);

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

                            _ActiveTicketCommentModel = ds.Tables[1].AsEnumerable()
                          .Select(row => new ActiveTicketCommentModel
                          {
                              comments = row["comments"].ToString(),
                              Colour = row["Colour"].ToString()
                          }).ToList();
                        }

                        ReturnData["TicketView"] = serializer.Serialize(_ActiveTicketModel);

                        ReturnData["TicketViewComment"] = serializer.Serialize(_ActiveTicketCommentModel);

                    }

                }

                if (Type == "Save")
                {
                    _UserSaveModel.Clear();

                    ht_param.Clear();
                    ht_param.Add("@TickerNumber", ht["TickerNumber"].ToString());
                    ht_param.Add("@Comments", ht["Comments"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@login_id", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[TicketQueryDetails_Insert]", ht_param);
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


                //if (Type == "Update")
                //{
                //    _UserSaveModel.Clear();

                //    ht_param.Clear();
                //    ht_param.Add("@ID", ht["ID"]);
                //    ht_param.Add("@CGST_PERCENTAGE", ht["CGST_PERCENTAGE"].ToString());
                //    ht_param.Add("@SGST_PERCENTAGE", ht["SGST_PERCENTAGE"].ToString());
                //    ht_param.Add("@IGST_PERCENTAGE", ht["IGST_PERCENTAGE"].ToString());
                //    ht_param.Add("@IsActive", ht["IsActive"].ToString());
                //    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                //    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                //    ht_param.Add("@login_id", HttpContext.Current.Session["Login_user_ID"].ToString());
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
                //    ReturnData["Update"] = serializer.Serialize(_UserSaveModel);
                //}



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