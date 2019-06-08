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
    public partial class CreateVacationTour : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<ErrorModel> _ErrorModel = new List<ErrorModel>();      
        static List<UserSaveModel> _UserSaveModel = new List<UserSaveModel>();
        static List<VacationTourModel> _gstModel = new List<VacationTourModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Company_ID"] == null || HttpContext.Current.Session["Company_ID"] == "")
            {
                Response.Redirect("Login.aspx");

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

                        
                        if (Data == "Edit")
                        {
                            ht_param.Clear();
                            ht_param.Add("@ID", ht["ID"].ToString());
                            ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                            ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                            ht_param.Add("@login_id", HttpContext.Current.Session["Login_user_ID"].ToString());
                            ds = db.SysFetchDataInDataSet("[GET_VACATION_TOUR]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                _gstModel = ds.Tables[0].AsEnumerable()
                                  .Select(row => new VacationTourModel
                                  {
                                      ID = row["ID"].ToString(),
                                      TOUR_NAME = row["TOUR_NAME"].ToString(),
                                      LEFT_POINT = row["LEFT_POINT"].ToString(),
                                      LEFT_POINT_DETAIL = row["LEFT_POINT_DETAIL"].ToString(),
                                      RIGHT_POINT = row["RIGHT_POINT"].ToString(),
                                      RIGHT_POINT_DETAIL = row["RIGHT_POINT_DETAIL"].ToString(),
                                      IsActive = row["IsActive"].ToString()
                                  }).ToList();
                            }
                            
                            ReturnData["TaxData"] = serializer.Serialize(_gstModel);
                        
                        }
                    }
                } 
              
                if (Type == "Save")
                {
                    _UserSaveModel.Clear();

                    ht_param.Clear();                   
                    ht_param.Add("@TOUR_NAME", ht["TOUR_NAME"].ToString());
                    ht_param.Add("@LEFT_POINT", ht["LEFT_POINT"].ToString());
                    ht_param.Add("@LEFT_POINT_DETAIL", ht["LEFT_POINT_DETAIL"].ToString());
                    ht_param.Add("@RIGHT_POINT", ht["RIGHT_POINT"].ToString());
                    ht_param.Add("@RIGHT_POINT_DETAIL", ht["RIGHT_POINT_DETAIL"].ToString());
                    ht_param.Add("@IsActive", ht["IsActive"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@login_id", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[SAVE_UPDATE_VACATION_TOUR]", ht_param);
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
             
              
                if (Type == "Update")
                {
                    _UserSaveModel.Clear();

                    ht_param.Clear();
                    ht_param.Add("@ID", ht["ID"]);
                    ht_param.Add("@TOUR_NAME", ht["TOUR_NAME"].ToString());
                    ht_param.Add("@LEFT_POINT", ht["LEFT_POINT"].ToString());
                    ht_param.Add("@LEFT_POINT_DETAIL", ht["LEFT_POINT_DETAIL"].ToString());
                    ht_param.Add("@RIGHT_POINT", ht["RIGHT_POINT"].ToString());
                    ht_param.Add("@RIGHT_POINT_DETAIL", ht["RIGHT_POINT_DETAIL"].ToString());
                    ht_param.Add("@IsActive", ht["IsActive"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@login_id", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[SAVE_UPDATE_VACATION_TOUR]", ht_param);
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
                    ReturnData["Update"] = serializer.Serialize(_UserSaveModel);
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