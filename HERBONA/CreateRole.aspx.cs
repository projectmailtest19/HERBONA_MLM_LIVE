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
    public partial class CreateRole : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<ErrorModel> _ErrorModel = new List<ErrorModel>();
        static List<RoleModel> _Rolelist = new List<RoleModel>();
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
        public static Hashtable RoleDetails(Hashtable ht, string Type, string Req)
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
                            ht_param.Add("@ID", ht["ROLE_ID"].ToString());
                            ds = db.SysFetchDataInDataSet("[GetSelectedRoleDetails]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                _Rolelist = ds.Tables[0].AsEnumerable()
                                  .Select(row => new RoleModel
                                  {
                                      ID = row["ID"].ToString(),
                                      Name = row["Name"].ToString(),
                                      Short_Name = row["Short_Name"].ToString(),
                                      Description = row["Description"].ToString(),
                                      IsActive = row["IsActive"].ToString()
                                  }).ToList();
                            }
                            ReturnData["RoleData"] = serializer.Serialize(_Rolelist);
                        
                        }
                    }
                }   
              
                if (Type == "Save")
                {
                    ht_param.Clear();
                    ht_param.Add("@ID", ht["ID"]);
                    ht_param.Add("@Name", ht["Name"].ToString());
                    ht_param.Add("@Short_Name", ht["Short_Name"].ToString());
                    ht_param.Add("@Description", ht["Description"].ToString());                   
                    ht_param.Add("@MODE", ht["MODE"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[INSERT_Role_DETAILS]", ht_param);
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
                    //ReturnData["Save"] = serializer.Serialize("saved successfully.");

                }            
             
                if (Type == "Update")
                {
                    ht_param.Clear();
                    ht_param.Add("@ID", ht["ID"]);
                    ht_param.Add("@Name", ht["Name"].ToString());
                    ht_param.Add("@Short_Name", ht["Short_Name"].ToString());
                    ht_param.Add("@Description", ht["Description"].ToString());                   
                    ht_param.Add("@MODE", ht["MODE"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[INSERT_Role_DETAILS]", ht_param);
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
                    //ReturnData["Update"] = serializer.Serialize("updated successfully.");

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