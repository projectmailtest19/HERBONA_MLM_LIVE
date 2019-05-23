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
   
    public partial class CreateAgentProfile : System.Web.UI.Page
    {
        public static DBFunctions db = new DBFunctions();
        public static Hashtable ReturnData = new Hashtable();
        public static Hashtable ht_param = new Hashtable();
        public static Hashtable ht_param2 = new Hashtable();
        public static DataSet ds = new DataSet();

        public static JavaScriptSerializer serializer = new JavaScriptSerializer();
        static List<CountryModel> _CountryModel = new List<CountryModel>();
        static List<ErrorModel> _ErrorModel = new List<ErrorModel>();
        static List<ContactModel> _Contactlist = new List<ContactModel>();
        static List<UserSaveModel> _UserSaveModel = new List<UserSaveModel>();
        static List<UserSaveModelWithEmailDetails> _UserSaveModelWithEmailDetails = new List<UserSaveModelWithEmailDetails>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Company_ID"] == null || HttpContext.Current.Session["Company_ID"] == "")
            {
                Response.Redirect("Login.aspx");

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
                    words = null;
                    words = Req.Split('@');
                    for (int m = 0; words.Count() > m; m++)
                    {

                        Data = words[m].ToString();

                        if (Data == "Country")
                        {
                            _CountryModel.Clear();
                            ht_param.Clear();
                            ds = db.SysFetchDataInDataSet("[GetCountryList]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    CountryModel CountryModel_Detail = new CountryModel();
                                    CountryModel_Detail.Name = item["NAME"].ToString();
                                    CountryModel_Detail.COUNTRY_ID = Convert.ToInt32(item["COUNTRY_ID"].ToString());
                                    _CountryModel.Add(CountryModel_Detail);
                                }
                            }
                            ReturnData["Country"] = serializer.Serialize(_CountryModel);
                        }

                      

                        if (Data == "Edit")
                        {
                            _CountryModel.Clear();

                            ht_param.Clear();
                            ht_param.Add("@ID", ht["ID"].ToString());
                            ds = db.SysFetchDataInDataSet("[GetSelectedContactDetailsProfile]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                _Contactlist = ds.Tables[0].AsEnumerable()
                                 .Select(row => new ContactModel
                                 {
                                     ID = row["ID"].ToString(),
                                     Name = row["Name"].ToString(),
                                     RName = row["RoleId"].ToString(),
                                     MobileNo = row["MobileNo"].ToString(),
                                     PhoneNo = row["PhoneNo"].ToString(),
                                     Email = row["Email"].ToString(),
                                     Country = row["Country"].ToString(),
                                     City = row["City"].ToString(),
                                     State = row["State"].ToString(),                                 
                                     Address = row["Address"].ToString(),
                                     WebsiteUrl = row["WebsiteUrl"].ToString(),
                                     LogoPath = row["LogoPath"].ToString(),
                                     IsActive = row["IsActive"].ToString()
                                 }).ToList();
                            }
                            ReturnData["ContactData"] = serializer.Serialize(_Contactlist);
                        }
                    }
                }
              
             
                if (Type == "State")
                {
                    _CountryModel.Clear();

                    ht_param.Clear();
                    ht_param.Add("@COUNTRY_ID", ht["COUNTRY_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[GetStateList]", ht_param);

                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            CountryModel CountryModel_Detail = new CountryModel();
                            CountryModel_Detail.Name = item["NAME"].ToString();
                            CountryModel_Detail.COUNTRY_ID = Convert.ToInt32(item["LOCATION_ID"].ToString());
                            _CountryModel.Add(CountryModel_Detail);
                        }
                    }
                    ReturnData["State"] = serializer.Serialize(_CountryModel);
                }
                if (Type == "District")
                {
                    _CountryModel.Clear();

                    ht_param.Clear();
                    ht_param.Add("@State_ID", ht["State_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[GetDistrictList]", ht_param);

                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            CountryModel CountryModel_Detail = new CountryModel();
                            CountryModel_Detail.Name = item["NAME"].ToString();
                            CountryModel_Detail.COUNTRY_ID = Convert.ToInt32(item["District_ID"].ToString());
                            _CountryModel.Add(CountryModel_Detail);
                        }
                    }
                    ReturnData["District"] = serializer.Serialize(_CountryModel);
                }



                if (Type == "Save")
                {
                    _UserSaveModelWithEmailDetails.Clear();

                    ht_param.Clear();
                    //ht_param.Add("@ID", ht["ID"]);
                    ht_param.Add("@Name", ht["Name"].ToString());
                    if (ht["Gender"].ToString() == "")
                    {
                        ht_param.Add("@Gender", DBNull.Value);
                    }
                    else
                    {
                        ht_param.Add("@Gender", ht["Gender"].ToString());
                    }
                    ht_param.Add("@MobileNo", ht["MobileNo"].ToString());
                    ht_param.Add("@Email", ht["Email"].ToString());
                    ht_param.Add("@ImageURL", ht["ImageURL"].ToString());
                    if (ht["country_id"].ToString() == "")
                    {
                        ht_param.Add("@country_id", DBNull.Value);
                    }
                    else
                    {
                        ht_param.Add("@country_id", ht["country_id"].ToString());
                    }

                    if (ht["state_id"].ToString() == "")
                    {
                        ht_param.Add("@state_id", DBNull.Value);
                    }
                    else
                    {
                        ht_param.Add("@state_id", ht["state_id"].ToString());
                    }
                    if (ht["district_id"].ToString() == "")
                    {
                        ht_param.Add("@district_id", DBNull.Value);
                    }
                    else
                    {
                        ht_param.Add("@district_id", ht["district_id"].ToString());
                    }
                    ht_param.Add("@addressline", ht["addressline"].ToString());
                    ht_param.Add("@pincode", ht["pincode"].ToString());
                    ht_param.Add("@MODE", ht["MODE"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[INSERT_Contact_DETAILS_Agent]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            //string CustomErrorState = ds.Tables[0].Rows[0]["CustomErrorState"].ToString().Trim();
                            //string CustomMessage = ds.Tables[0].Rows[0]["CustomMessage"].ToString().Trim();
                            //if (CustomErrorState == "0")
                            //{
                            //    string ToEmail_id = ds.Tables[0].Rows[0]["Email_ID"].ToString().Trim();
                            //    string New_password = ds.Tables[0].Rows[0]["Passward"].ToString().Trim();
                            //    string Name = ds.Tables[0].Rows[0]["Agent_Name"].ToString().Trim();

                            //    var myMailMessage = new System.Net.Mail.MailMessage();
                            //    myMailMessage.From = new System.Net.Mail.MailAddress("<noreply> projectmailtest19@gmail.com");
                            //    myMailMessage.To.Add(ToEmail_id);// Mail would be sent to this address
                            //    myMailMessage.IsBodyHtml = true;
                            //    myMailMessage.Subject = "New Autogenerated Password From HERBONA";
                            //    myMailMessage.Body = "<span> Dear " + Name + ",<br/><br/></span><span>Thank you for registering ,<br/> </span><span><b>Your Password is :" + New_password + "</b></span>";
                            //    var smtpServer = new System.Net.Mail.SmtpClient("ftp.gmail.com");
                            //    smtpServer.Host = ("smtp.gmail.com");
                            //    smtpServer.Port = 587;
                            //    smtpServer.Credentials = new System.Net.NetworkCredential("projectmailtest19@gmail.com", "Admin@123#");
                            //    smtpServer.EnableSsl = true;
                            //    smtpServer.Send(myMailMessage);

                            //}



                                UserSaveModelWithEmailDetails __UserSaveModelWithEmail = new UserSaveModelWithEmailDetails();
                            __UserSaveModelWithEmail.CustomErrorState = item["CustomErrorState"].ToString();
                            __UserSaveModelWithEmail.CustomMessage = item["CustomMessage"].ToString();
                            __UserSaveModelWithEmail.ID = item["ID"].ToString();
                            __UserSaveModelWithEmail.Email_ID = item["Email_ID"].ToString();
                            __UserSaveModelWithEmail.Passward = item["Passward"].ToString();
                            __UserSaveModelWithEmail.Agent_Name = item["Agent_Name"].ToString();
                            _UserSaveModelWithEmailDetails.Add(__UserSaveModelWithEmail);
                        }
                    }
                    ReturnData["Save"] = serializer.Serialize(_UserSaveModelWithEmailDetails);

                }

                if (Type == "Update")
                {
                    _UserSaveModelWithEmailDetails.Clear();

                    ht_param.Clear();
                    ht_param.Add("@ID", ht["ID"]);
                    ht_param.Add("@Name", ht["Name"].ToString());
                    if (ht["Gender"].ToString() == "")
                    {
                        ht_param.Add("@Gender", DBNull.Value);
                    }
                    else
                    {
                        ht_param.Add("@Gender", ht["Gender"].ToString());
                    }
                    ht_param.Add("@MobileNo", ht["MobileNo"].ToString());
                    ht_param.Add("@Email", ht["Email"].ToString());
                    ht_param.Add("@ImageURL", ht["ImageURL"].ToString());
                    if (ht["country_id"].ToString() == "")
                    {
                        ht_param.Add("@country_id", DBNull.Value);
                    }
                    else
                    {
                        ht_param.Add("@country_id", ht["country_id"].ToString());
                    }

                    if (ht["state_id"].ToString() == "")
                    {
                        ht_param.Add("@state_id", DBNull.Value);
                    }
                    else
                    {
                        ht_param.Add("@state_id", ht["state_id"].ToString());
                    }
                    if (ht["district_id"].ToString() == "")
                    {
                        ht_param.Add("@district_id", DBNull.Value);
                    }
                    else
                    {
                        ht_param.Add("@district_id", ht["district_id"].ToString());
                    }
                    ht_param.Add("@addressline", ht["addressline"].ToString());
                    ht_param.Add("@pincode", ht["pincode"].ToString());
                    ht_param.Add("@MODE", ht["MODE"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[INSERT_Contact_DETAILS_Agent]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            UserSaveModelWithEmailDetails __UserSaveModelWithEmail = new UserSaveModelWithEmailDetails();
                            __UserSaveModelWithEmail.CustomErrorState = item["CustomErrorState"].ToString();
                            __UserSaveModelWithEmail.CustomMessage = item["CustomMessage"].ToString();
                            __UserSaveModelWithEmail.ID = item["ID"].ToString();
                            __UserSaveModelWithEmail.Email_ID = item["Email_ID"].ToString();
                            __UserSaveModelWithEmail.Passward = item["Passward"].ToString();
                            __UserSaveModelWithEmail.Agent_Name = item["Agent_Name"].ToString();
                            _UserSaveModelWithEmailDetails.Add(__UserSaveModelWithEmail);
                        }
                    }
                    ReturnData["Update"] = serializer.Serialize(_UserSaveModelWithEmailDetails);

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