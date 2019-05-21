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

  
    public partial class Permission : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();      
        static List<ErrorModel> _errorDetail = new List<ErrorModel>();
        static List<RoleModel> RoleModel_list = new List<RoleModel>();
        static List<PermissionModel> PermissionModel_list = new List<PermissionModel>();
        static Dictionary<string, object> dictionary = new Dictionary<string, object>();
        static List<UserSaveModel> _UserSaveModel = new List<UserSaveModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Company_ID"] == null || HttpContext.Current.Session["Company_ID"] == "")
            {
                Response.Redirect("Login.aspx");

            }
        }
        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static Hashtable RoleDetailsList(Hashtable ht, string Type, string Req)
        {
            try
            {
                string Data = Req;
                RoleModel_list.Clear();
                ReturnData.Clear();
              
                if (Type == "Fill")
                {
                    if (Data == "GetPermissionList")
                    {
                        dictionary = new Dictionary<string, object>();
                        ht_param.Clear();
                        ht_param.Add("@Roll_Id", ht["roleid"].ToString());
                        ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                        ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                        ds = db.SysFetchDataInDataSet("[GET_PERMISSION_DETAILS]", ht_param);
                        if (ds.Tables.Count > 0)
                        {
                            PermissionModel_list = ds.Tables[0].AsEnumerable()
                              .Select(row => new PermissionModel
                              {
                                  Permission_ID = row["Permission_ID"].ToString(),
                                  MenuID = row["MenuID"].ToString(),
                                  Role_ID = row["RoleID"].ToString(),
                                  MenuName = row["MenuName"].ToString(),
                                  B_Add = row["B_Add"].ToString(),
                                  B_Edit = row["B_Edit"].ToString(),
                                  B_Delete = row["B_Delete"].ToString(),
                                  B_View = row["B_View"].ToString(),
                                  B_Payment = row["B_Payment"].ToString(),
                                  Role_Name = row["RoleName"].ToString()
                              }).ToList();
                        }
                        serializer.MaxJsonLength = 1000000000;
                        dictionary.Add("data", PermissionModel_list);
                        ReturnData["GetPermissionList"] = serializer.Serialize(dictionary);

                    }
                }
              
              
                if (Type == "Insert")
                {
                    if (Data == "SaveAllMenuPermission")
                    {
                        ht_param.Clear();
                        string PermissionID = ht["PermissionID"].ToString();
                        string MenuID = ht["MenuID"].ToString();
                        string B_Add = ht["B_Add"].ToString();
                        string B_Edit = ht["B_Edit"].ToString();
                        string B_Delete = ht["B_Delete"].ToString();
                        string B_View = ht["B_View"].ToString();
                        string B_Payment = ht["B_Payment"].ToString();
                        string Role_ID = ht["roleid"].ToString();

                        char[] splitchar = { ',' };
                        string[] menuidArr = MenuID.Split(splitchar);
                        string[] purchaseidArr = PermissionID.Split(splitchar);
                        string[] add = B_Add.Split(splitchar);
                        string[] edit = B_Edit.Split(splitchar);
                        string[] delete = B_Delete.Split(splitchar);
                        string[] view = B_View.Split(splitchar);
                        string[] payment = B_Payment.Split(splitchar);

                        string[] _count = menuidArr.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        int count = _count.Count();
                        List<PermissionModel> _permissionModel = new List<PermissionModel>();
                        for (int i = 0; count > i; i++)
                        {
                            ht_param.Clear();
                            ht_param.Add("@ID", purchaseidArr[i].ToString());
                            ht_param.Add("@MenuID", menuidArr[i].ToString());
                            ht_param.Add("@RoleID", Role_ID);
                            ht_param.Add("@B_Add", add[i].ToString() == "true" ? 1 : 0);
                            ht_param.Add("@B_Edit", edit[i].ToString() == "true" ? 1 : 0);
                            ht_param.Add("@B_Delete", delete[i].ToString() == "true" ? 1 : 0);
                            ht_param.Add("@B_View", view[i].ToString() == "true" ? 1 : 0);
                            ht_param.Add("@B_Payment", payment[i].ToString() == "true" ? 1 : 0);
                            ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                            ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                            ds = db.SysFetchDataInDataSet("[CU_PERMISSION]", ht_param);
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
                            ReturnData["SaveAllMenuPermission"] = serializer.Serialize(_UserSaveModel);
                        }
                        //ReturnData["SaveAllMenuPermission"] = "success";

                    }
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