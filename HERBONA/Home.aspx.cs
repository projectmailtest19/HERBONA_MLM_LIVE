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
    public partial class Home : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<CountryModel> _CountryModel = new List<CountryModel>();
        static List<Cust_TypeModel> _Cust_TypeModel = new List<Cust_TypeModel>();
        static List<ErrorModel> _ErrorModel = new List<ErrorModel>();
        static List<DashboardDataModel> _DashboardDataModel = new List<DashboardDataModel>();
        static List<UserSaveModel> _UserSaveModel = new List<UserSaveModel>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static Hashtable DashboardDetails(Hashtable ht, string Type, string Req)
        {
            try
            {
                string[] words = null;
                string Data = Req;

                ReturnData.Clear();

                if (Type == "DashboardDetails")
                {

                    _DashboardDataModel.Clear();
                            ht_param.Clear();
                            ht_param.Add("@company_id", HttpContext.Current.Session["Company_ID"].ToString());
                            ht_param.Add("@branch_id", HttpContext.Current.Session["Branch_ID"].ToString());
                            ht_param.Add("@login_id", HttpContext.Current.Session["Login_user_ID"].ToString());
                            ds = db.SysFetchDataInDataSet("[get_dashboard_data]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                        _DashboardDataModel = ds.Tables[0].AsEnumerable()
                                  .Select(row => new DashboardDataModel
                                  {
                                      personal_purchase_invoice = row["personal_purchase_invoice"].ToString(),
                                      next_due_date_repurchase = row["next_due_date_repurchase"].ToString(),
                                      current_payschedule_purchase = row["current_payschedule_purchase"].ToString(),
                                      total_ftb = row["total_ftb"].ToString(),
                                      total_tlb = row["total_tlb"].ToString(),
                                      total_dplx = row["total_dplx"].ToString(),
                                      total_rab = row["total_rab"].ToString(),
                                      car_travel_fund = row["car_travel_fund"].ToString(),
                                      house_fund = row["house_fund"].ToString(),
                                      leadership_bonus = row["leadership_bonus"].ToString(),
                                      elite_ranking_bonus = row["elite_ranking_bonus"].ToString(),
                                      retail_profit = row["retail_profit"].ToString(),
                                      current_rank_tittle = row["current_rank_tittle"].ToString(),
                                      no_of_directs = row["no_of_directs"].ToString()
                                  }).ToList();
                            }
                            ReturnData["DashboardDetails"] = serializer.Serialize(_DashboardDataModel);
                     
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