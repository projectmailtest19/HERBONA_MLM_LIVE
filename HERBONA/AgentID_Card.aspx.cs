using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartTrucking.Model;
using System.Collections;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
namespace HERBONA
{
    public partial class AgentID_Card : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<ErrorModel> _ErrorModel = new List<ErrorModel>();
        static List<AgentIDCardModel> AgentIDCardModel_list = new List<AgentIDCardModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Company_ID"] == null || HttpContext.Current.Session["Company_ID"] == "")
            {
                Response.Redirect("Signup.aspx");

            }
        }
        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static Hashtable ContactDetails(Hashtable ht, string Type, string Req)
        {
            try
            {
                string[] words = null;
                string Data = Req;

                ReturnData.Clear();

                if (Type == "Fill")
                {
                  
                            AgentIDCardModel_list.Clear();

                            ht_param.Clear();
                            ht_param.Add("@ID", ht["ID"].ToString());
                            ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                            ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                            ds = db.SysFetchDataInDataSet("[GetAgentIDCardDetails]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                AgentIDCardModel_list = ds.Tables[0].AsEnumerable()
                               .Select(row => new AgentIDCardModel
                               {
                                   ID = row["ID"].ToString(),
                                   Name = row["Name"].ToString(),
                                   Account_Number = row["Account_Number"].ToString(),
                                   ImageURL = row["ImageURL"].ToString(),
                                   Countey_Name = row["Countey_Name"].ToString(),
                                   State_Name = row["State_Name"].ToString(),
                                   District_Name = row["District_Name"].ToString(),
                                   Pan_No = row["Pan_No"].ToString(),
                                   Valid_Upto = row["Valid_Upto"].ToString()
                               }).ToList();
                            }
                            ReturnData["FillIDCardDetails"] = serializer.Serialize(AgentIDCardModel_list);
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