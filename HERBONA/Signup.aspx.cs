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
    public partial class Signup : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();
        public static DataTable dt = new DataTable();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<ErrorModel> _ErrorModel = new List<ErrorModel>();
        List<LoginModel> _GetLoginModelList = new List<LoginModel>();
        List<MenuViewModel> _MenuViewModel_list = new List<MenuViewModel>();
        List<ForgotPwdModel> _ForgotPwdModelList = new List<ForgotPwdModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();
            }
        }
        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static Hashtable LoginDetails(Hashtable ht, string Type, string Req)
        {
            List<PermissionModel> _PermissionModelList = new List<PermissionModel>();

            ReturnData.Clear();
            try
            {

                if (Type == "Login")
                {
                    if (Req == "NormalLogin")
                    {

                        ht_param.Clear();
                        ht_param.Add("@Email", ht["Email"].ToString());
                        ht_param.Add("@Password", ht["Password"].ToString());
                        ds = db.SysFetchDataInDataSet("[Getloginuser]", ht_param);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string CustomErrorState = ds.Tables[0].Rows[0]["CustomErrorState"].ToString().Trim();
                            string CustomMessage = ds.Tables[0].Rows[0]["CustomMessage"].ToString().Trim();

                            if (CustomErrorState == "0")
                            {
                                _ErrorModel.Clear();
                                ReturnData.Clear();
                                ErrorModel _error = new ErrorModel();
                                _error.Error = "0";
                                _error.ErrorMessage = "Sucess";
                                _ErrorModel.Add(_error);
                                ReturnData["ErrorDetail"] = serializer.Serialize(_ErrorModel);


                                ht_param2.Clear();
                                ht_param2.Add("COMPANY_ID", ds.Tables[1].Rows[0]["COMPANY_ID"].ToString());
                                ht_param2.Add("BRANCH_ID", ds.Tables[1].Rows[0]["BRANCH_ID"].ToString());
                                ht_param2.Add("CONTACT_ID", ds.Tables[1].Rows[0]["CONTACT_ID"].ToString().Trim());
                                ht_param2.Add("COMPANY_LOGOPATH", ds.Tables[1].Rows[0]["COMPANY_LOGOPATH"].ToString().Trim());
                                ht_param2.Add("BRANCH_LOGOPATH", ds.Tables[1].Rows[0]["BRANCH_LOGOPATH"].ToString().Trim());
                                //ht_param2.Add("CONTACT_LOGOPATH", ds.Tables[1].Rows[0]["CONTACT_LOGOPATH"].ToString().Trim());
                                ht_param2.Add("COMPANY_NAME", ds.Tables[1].Rows[0]["COMPANY_NAME"].ToString().Trim());
                                ht_param2.Add("BRANCH_NAME", ds.Tables[1].Rows[0]["BRANCH_NAME"].ToString().Trim());
                                ht_param2.Add("CONTACT_NAME", ds.Tables[1].Rows[0]["CONTACT_NAME"].ToString().Trim());
                                ht_param2.Add("ROLEID", ds.Tables[1].Rows[0]["ROLEID"].ToString().Trim());
                                ht_param2.Add("IsAgent", ds.Tables[1].Rows[0]["IsAgent"].ToString().Trim());
                                //ht_param2.Add("CONTACT_TYPE", ds.Tables[1].Rows[0]["CONTACT_TYPE"].ToString().Trim());


                                HttpContext.Current.Session["Company_ID"] = ds.Tables[1].Rows[0]["COMPANY_ID"].ToString();
                                HttpContext.Current.Session["Branch_ID"] = ds.Tables[1].Rows[0]["BRANCH_ID"].ToString();
                                HttpContext.Current.Session["Login_user_ID"] = ds.Tables[1].Rows[0]["CONTACT_ID"].ToString();
                                HttpContext.Current.Session["ROLEID"] = ds.Tables[1].Rows[0]["ROLEID"].ToString();
                                //HttpContext.Current.Session["CONTACT_TYPE"] = ds.Tables[1].Rows[0]["CONTACT_TYPE"].ToString();


                                ds.Clear();
                                ht_param.Clear();
                                ht_param.Add("@UID", ht["Email"].ToString());
                                ht_param.Add("@PWD", ht["Password"].ToString());
                                ds = db.SysFetchDataInDataSet("[LOGIN_CHECK2]", ht_param);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    if (ds.Tables[0].Rows[0]["ERROR_ID"].ToString() == "0")
                                    {
                                        ht_param2.Add("MENU", ds.Tables[0].Rows[0]["MENU"].ToString().Trim());

                                    }
                                }

                                serializer.MaxJsonLength = 1000000000;

                                _PermissionModelList.Clear();

                                if (ds.Tables.Count >= 2)
                                {

                                    _PermissionModelList = ds.Tables[1].AsEnumerable()
                                      .Select(row => new PermissionModel
                                      {
                                          Url = row["url"].ToString(),
                                          MenuID = row["ID"].ToString(),
                                          MenuName = row["MenuName"].ToString(),
                                          Role_ID = row["RoleID"].ToString(),
                                          B_Add = row["B_Add"].ToString(),
                                          B_Edit = row["B_Edit"].ToString(),
                                          B_Delete = row["B_Delete"].ToString(),
                                          B_View = row["B_View"].ToString(),
                                          Status = row["Status"].ToString(),
                                      }).ToList();
                                    ReturnData["PagePermission"] = serializer.Serialize(_PermissionModelList);
                                }

                                ReturnData["Login"] = serializer.Serialize(ht_param2);

                            }

                            else if (CustomErrorState == "1")
                            {

                                _ErrorModel.Clear();
                                ReturnData.Clear();
                                ErrorModel _error = new ErrorModel();
                                _error.Error = "1";
                                _error.ErrorMessage = "Some problem occurred please try again later";
                                _ErrorModel.Add(_error);
                                ReturnData["ErrorDetail"] = serializer.Serialize(_ErrorModel);
                                HttpContext.Current.Response.AppendHeader("ResponseHeader", "500");
                            }

                            else if (CustomErrorState == "2")
                            {

                                _ErrorModel.Clear();
                                ReturnData.Clear();
                                ErrorModel _error = new ErrorModel();
                                _error.Error = "2";
                                _error.ErrorMessage = CustomMessage;

                                _ErrorModel.Add(_error);
                                ReturnData["ErrorDetail"] = serializer.Serialize(_ErrorModel);
                                HttpContext.Current.Response.AppendHeader("ResponseHeader", "500");
                            }
                        }
                        else
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
}