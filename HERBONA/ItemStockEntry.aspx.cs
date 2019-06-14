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
    public partial class ItemStockEntry : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();     
        static List<ErrorModel> _errorDetail = new List<ErrorModel>();
        static List<ItemDetails_ListModel> _gstlistModel = new List<ItemDetails_ListModel>();
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
                    ht_param.Add("@login_id", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[GET_ITEM_DETAILS]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        _gstlistModel = ds.Tables[0].AsEnumerable()
                          .Select(row => new ItemDetails_ListModel
                          {
                              ID = row["ID"].ToString(),
                              CATEGORY_ID = row["CATEGORY_ID"].ToString(),
                              NAME = row["NAME"].ToString(),
                              PBO_PRICE = row["PBO_PRICE"].ToString(),
                              PRODUCT_SVP = row["PRODUCT_SVP"].ToString(),
                              DISCOUNT_PERCENTAGE = row["DISCOUNT_PERCENTAGE"].ToString(),
                              DISCOUNT_AMOUNT = row["DISCOUNT_AMOUNT"].ToString(),
                              CODE = row["CODE"].ToString(),
                              GST_ID = row["GST_ID"].ToString(),
                              MRP = row["MRP"].ToString(),
                              SALE_PRICE = row["SALE_PRICE"].ToString(),
                              ImageURL = row["ImageURL"].ToString(),
                              IsActive = row["IsActive"].ToString(),
                              CATEGORY_NAME = row["CATEGORY_NAME"].ToString(),
                              IGST_PERCENTAGE = row["IGST_PERCENTAGE"].ToString(),
                              CGST_PERCENTAGE = row["CGST_PERCENTAGE"].ToString(),
                              SGST_PERCENTAGE = row["SGST_PERCENTAGE"].ToString() 
                          }).ToList();
                    }
                    ReturnData["LoadData"] = serializer.Serialize(_gstlistModel);

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