﻿using SmartTrucking.Model;
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
    public partial class AgentList : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<CountryModel> _CountryModel = new List<CountryModel>();
        static List<ErrorModel> _errorDetail = new List<ErrorModel>();
        static List<AgentListModel> AgentListModel_list = new List<AgentListModel>();
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
        public static Hashtable ContactDetails(Hashtable ht, string Type, string Req)
        {
            try
            {
                string[] words = null;
                string Data = Req;

                ReturnData.Clear();
             
                if (Type == "Fill")
                {
                    AgentListModel_list.Clear();
                    ht_param.Clear();
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[GetAgentPersonalDetails]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        AgentListModel_list = ds.Tables[0].AsEnumerable()
                          .Select(row => new AgentListModel
                          {
                              ID = row["ID"].ToString(),
                              Name = row["Name"].ToString(),
                              MobileNo = row["MobileNo"].ToString(),
                              Email = row["Email"].ToString(),
                              Gender = row["Gender"].ToString(),
                              ImageURL = row["ImageURL"].ToString(),
                              country_id = row["country_id"].ToString(),
                              state_id = row["state_id"].ToString(),
                              district_id = row["district_id"].ToString(),
                              Address = row["Address"].ToString(),
                              pincode = row["pincode"].ToString(),
                              IsAgentActive = row["IsAgentActive"].ToString()
                          }).ToList();
                    }
                    ReturnData["AgentData"] = serializer.Serialize(AgentListModel_list);

                }
              
              
                if (Type == "StatusUpdate")
                {
                    _UserSaveModel.Clear();
                    ht_param.Clear();
                    ht_param.Add("@ID", ht["ID"]);
                    ds=db.SysFetchDataInDataSet("[UpdateAgentActiveStatus]", ht_param);
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
                    ReturnData["CompanyData"] = serializer.Serialize(_UserSaveModel);
                    //ReturnData["ContactData"] = serializer.Serialize("deleted successfully.");
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