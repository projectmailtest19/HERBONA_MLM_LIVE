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
        static List<UserSaveModelWithID> _UserSaveModelWithID = new List<UserSaveModelWithID>();
        static List<AgentAddressProofListModel> _AgentAddressProofListModel = new List<AgentAddressProofListModel>();
        static List<AgentBankProofListModel> _AgentBankProofListModel = new List<AgentBankProofListModel>();
        static List<UserSaveModelWithEmailDetails> _UserSaveModelWithEmailDetails = new List<UserSaveModelWithEmailDetails>();
        static List<AgentListModel> AgentListModel_list = new List<AgentListModel>();
        static List<AgentSponsorModel> _AgentSponsorModel = new List<AgentSponsorModel>();
        static List<AgentBankDetailsModel> _AgentBankDetailsModel = new List<AgentBankDetailsModel>();
        static List<AgentPANListModel> _AgentPANListModel = new List<AgentPANListModel>();
        static List<AgentApplicationListModel> _AgentApplicationListModel = new List<AgentApplicationListModel>();
        static List<Sponsor_Details_Model> _Sponsor_Details_Model = new List<Sponsor_Details_Model>();
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
                        if (Data == "Sponsor")
                        {
                            _CountryModel.Clear();
                           
                            ht_param.Clear();
                            ht_param.Add("@Contact_id", ht["Contact_id"].ToString());
                            ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                            ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                            ds = db.SysFetchDataInDataSet("[GetAgent_Sponsor_Details]", ht_param);
                            if (ds.Tables[0].Rows.Count>0)
                            {
                                ds.Clear();
                                ht_param.Clear();                               
                                ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                                ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                                ds = db.SysFetchDataInDataSet("[GetALLSponsor]", ht_param);                               
                            }
                            else
                            {
                                ds.Clear();
                                ht_param.Clear();                             
                                ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                                ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                                ds = db.SysFetchDataInDataSet("[GetALLSponsor_FreeSide]", ht_param);
                            }

                            if (ds.Tables.Count > 0)
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    CountryModel CountryModel_Detail = new CountryModel();
                                    CountryModel_Detail.Name = item["NAME"].ToString();
                                    CountryModel_Detail.COUNTRY_ID = Convert.ToInt32(item["ID"].ToString());
                                    _CountryModel.Add(CountryModel_Detail);
                                }
                            }
                            ReturnData["Sponsor"] = serializer.Serialize(_CountryModel);
                        }
                        if (Data == "SplitSponsor")
                        {
                            _CountryModel.Clear();
                            ht_param.Clear();
                            ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                            ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                            ds = db.SysFetchDataInDataSet("[GetALLSponsor]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                foreach (DataRow item in ds.Tables[0].Rows)
                                {
                                    CountryModel CountryModel_Detail = new CountryModel();
                                    CountryModel_Detail.Name = item["NAME"].ToString();
                                    CountryModel_Detail.COUNTRY_ID = Convert.ToInt32(item["ID"].ToString());
                                    _CountryModel.Add(CountryModel_Detail);
                                }
                            }
                            ReturnData["SplitSponsor"] = serializer.Serialize(_CountryModel);
                        }

                        if (Data == "FillAddressProof")
                        {
                            _AgentAddressProofListModel.Clear();
                            ht_param.Clear();
                            ht_param.Add("@Contact_id", ht["Contact_id"].ToString());
                            ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                            ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                            ds = db.SysFetchDataInDataSet("[GetAgent_AddressProof_Details]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                _AgentAddressProofListModel = ds.Tables[0].AsEnumerable()
                                  .Select(row => new AgentAddressProofListModel
                                  {
                                      id = row["id"].ToString(),
                                      Contact_id = row["Contact_id"].ToString(),
                                      Address_Proof_Type = row["Address_Proof_Type"].ToString(),
                                      Address_Proof_URL = row["Address_Proof_URL"].ToString()
                                  }).ToList();
                            }
                            ReturnData["FillAddressProof"] = serializer.Serialize(_AgentAddressProofListModel);
                        }
                        if (Data == "FillBankProof")
                        {
                            _AgentBankProofListModel.Clear();
                            ht_param.Clear();
                            ht_param.Add("@Contact_id", ht["Contact_id"].ToString());
                            ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                            ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                            ds = db.SysFetchDataInDataSet("[GetAgent_BankProof_Details]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                _AgentBankProofListModel = ds.Tables[0].AsEnumerable()
                                  .Select(row => new AgentBankProofListModel
                                  {
                                      id = row["id"].ToString(),
                                      Contact_id = row["Contact_id"].ToString(),
                                      Bank_Proof_Type = row["Bank_Proof_Type"].ToString(),
                                      Bank_Proof_URL = row["Bank_Proof_URL"].ToString()
                                  }).ToList();
                            }
                            ReturnData["FillBankProof"] = serializer.Serialize(_AgentBankProofListModel);
                        }

                        if (Data == "FillPersonalDetails")
                        {
                            AgentListModel_list.Clear();

                            ht_param.Clear();
                            ht_param.Add("@ID", ht["Contact_id"].ToString());
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
                            ReturnData["FillPersonalDetails"] = serializer.Serialize(AgentListModel_list);
                        }
                        if (Data == "FillSponsorDetails")
                        {
                            _AgentSponsorModel.Clear();

                            ht_param.Clear();
                            ht_param.Add("@Contact_id", ht["Contact_id"].ToString());
                            ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                            ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                            ds = db.SysFetchDataInDataSet("[GetAgent_Sponsor_Details]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                _AgentSponsorModel = ds.Tables[0].AsEnumerable()
                               .Select(row => new AgentSponsorModel
                               {
                                   id = row["id"].ToString(),
                                   Contact_id = row["Contact_id"].ToString(),
                                   Sponsor_ID = row["Sponsor_ID"].ToString(),
                                   Placed_Name = row["Placed_Name"].ToString(),
                                   Placed_MemberID = row["Placed_MemberID"].ToString(),
                                   Placed_Team = row["Placed_Team"].ToString(),
                                   SplitSponsor_ID = row["SplitSponsor_ID"].ToString()
                               }).ToList();
                            }
                            ReturnData["FillSponsorDetails"] = serializer.Serialize(_AgentSponsorModel);
                        }
                        if (Data == "FillbankDetails")
                        {
                            _AgentBankDetailsModel.Clear();

                            ht_param.Clear();
                            ht_param.Add("@Contact_id", ht["Contact_id"].ToString());
                            ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                            ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                            ds = db.SysFetchDataInDataSet("[GetAgent_Bank_Details]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                _AgentBankDetailsModel = ds.Tables[0].AsEnumerable()
                               .Select(row => new AgentBankDetailsModel
                               {
                                   id = row["id"].ToString(),
                                   Contact_id = row["Contact_id"].ToString(),
                                   Account_Holder_Name = row["Account_Holder_Name"].ToString(),
                                   Account_Number = row["Account_Number"].ToString(),
                                   Bank_Name = row["Bank_Name"].ToString(),
                                   Account_Type = row["Account_Type"].ToString(),
                                   IFSC_Code = row["IFSC_Code"].ToString(),
                                   Branch_Name = row["Branch_Name"].ToString(),
                                   Pan_No = row["Pan_No"].ToString()
                               }).ToList();
                            }
                            ReturnData["FillbankDetails"] = serializer.Serialize(_AgentBankDetailsModel);
                        }
                        if (Data == "FillPAN")
                        {
                            _AgentPANListModel.Clear();

                            ht_param.Clear();
                            ht_param.Add("@Contact_id", ht["Contact_id"].ToString());
                            ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                            ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                            ds = db.SysFetchDataInDataSet("[GetAgent_PANCard_Details]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                _AgentPANListModel = ds.Tables[0].AsEnumerable()
                               .Select(row => new AgentPANListModel
                               {
                                   id = row["id"].ToString(),
                                   Contact_id = row["Contact_id"].ToString(),
                                   PANCard_URL = row["PANCard_URL"].ToString()
                               }).ToList();
                            }
                            ReturnData["FillPAN"] = serializer.Serialize(_AgentPANListModel);
                        }
                        if (Data == "FillApplication")
                        {
                            _AgentApplicationListModel.Clear();

                            ht_param.Clear();
                            ht_param.Add("@Contact_id", ht["Contact_id"].ToString());
                            ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                            ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                            ds = db.SysFetchDataInDataSet("[GetAgent_AppicationForm_Details]", ht_param);

                            if (ds.Tables.Count > 0)
                            {
                                _AgentApplicationListModel = ds.Tables[0].AsEnumerable()
                               .Select(row => new AgentApplicationListModel
                               {
                                   id = row["id"].ToString(),
                                   Contact_id = row["Contact_id"].ToString(),
                                   AppicationForm_URL = row["AppicationForm_URL"].ToString()
                               }).ToList();
                            }
                            ReturnData["FillApplication"] = serializer.Serialize(_AgentApplicationListModel);
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
                if (Type == "Sponsor_Details")
                {
                    _Sponsor_Details_Model.Clear();

                    ht_param.Clear();
                    ht_param.Add("@id", ht["id"].ToString());
                    ds = db.SysFetchDataInDataSet("[GetSelectedSponsor_Details]", ht_param);

                    if (ds.Tables.Count > 0)
                    {
                        _Sponsor_Details_Model = ds.Tables[0].AsEnumerable()
                       .Select(row => new Sponsor_Details_Model
                       {
                           MobileNo = row["MobileNo"].ToString(),
                           Account_Number = row["Account_Number"].ToString(),
                           Placed_MemberID = row["Placed_MemberID"].ToString()
                       }).ToList();
                    }
                    ReturnData["Sponsor_Details"] = serializer.Serialize(_Sponsor_Details_Model);
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

                if (Type == "SaveSponsor")
                {
                    _UserSaveModelWithID.Clear();

                    ht_param.Clear();
                    ht_param.Add("@Contact_id", ht["Contact_id"].ToString());
                    //ht_param.Add("@Sponsor_Account_No", ht["Sponsor_Account_No"].ToString());
                    ht_param.Add("@Sponsor_ID", ht["Sponsor_ID"].ToString());
                    //ht_param.Add("@Sponsor_MemberID", ht["Sponsor_MemberID"].ToString());
                    //ht_param.Add("@Sponsor_Mobile_Number", ht["Sponsor_Mobile_Number"].ToString());
                    ht_param.Add("@Placed_Name", ht["Placed_Name"].ToString());
                    //ht_param.Add("@Placed_MemberID", ht["Placed_MemberID"].ToString());
                    //ht_param.Add("@Placed_Team", ht["Placed_Team"].ToString());
                    ht_param.Add("@SplitSponsor_ID", ht["SplitSponsor_ID"].ToString());
                    ht_param.Add("@MODE", ht["MODE"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[INSERT_Agent_Sponsor_Details]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                              UserSaveModelWithID ___UserSaveModelWithIDDetails = new UserSaveModelWithID();
                            ___UserSaveModelWithIDDetails.CustomErrorState = item["CustomErrorState"].ToString();
                            ___UserSaveModelWithIDDetails.CustomMessage = item["CustomMessage"].ToString();
                            ___UserSaveModelWithIDDetails.ID = item["ID"].ToString();
                            _UserSaveModelWithID.Add(___UserSaveModelWithIDDetails);
                        }
                    }
                    ReturnData["SaveSponsor"] = serializer.Serialize(_UserSaveModelWithID);

                }

                if (Type == "UpdateSponsor")
                {
                    _UserSaveModelWithID.Clear();

                    ht_param.Clear();
                    ht_param.Add("@Contact_id", ht["Contact_id"].ToString());
                    //ht_param.Add("@Sponsor_Account_No", ht["Sponsor_Account_No"].ToString());
                    ht_param.Add("@Sponsor_ID", ht["Sponsor_ID"].ToString());
                    //ht_param.Add("@Sponsor_MemberID", ht["Sponsor_MemberID"].ToString());
                    //ht_param.Add("@Sponsor_Mobile_Number", ht["Sponsor_Mobile_Number"].ToString());
                    ht_param.Add("@Placed_Name", ht["Placed_Name"].ToString());
                    //ht_param.Add("@Placed_MemberID", ht["Placed_MemberID"].ToString());
                    //ht_param.Add("@Placed_Team", ht["Placed_Team"].ToString());
                    ht_param.Add("@SplitSponsor_ID", ht["SplitSponsor_ID"].ToString());
                    ht_param.Add("@MODE", ht["MODE"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[INSERT_Agent_Sponsor_Details]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            UserSaveModelWithID ___UserSaveModelWithIDDetails = new UserSaveModelWithID();
                            ___UserSaveModelWithIDDetails.CustomErrorState = item["CustomErrorState"].ToString();
                            ___UserSaveModelWithIDDetails.CustomMessage = item["CustomMessage"].ToString();
                            ___UserSaveModelWithIDDetails.ID = item["ID"].ToString();
                            _UserSaveModelWithID.Add(___UserSaveModelWithIDDetails);
                        }
                    }
                    ReturnData["UpdateSponsor"] = serializer.Serialize(_UserSaveModelWithID);

                }

                if (Type == "SaveBank")
                {
                    _UserSaveModelWithID.Clear();

                    ht_param.Clear();
                    ht_param.Add("@Contact_id", ht["Contact_id"].ToString());
                    ht_param.Add("@Account_Holder_Name", ht["Account_Holder_Name"].ToString());
                    ht_param.Add("@Account_Number", ht["Account_Number"].ToString());
                    ht_param.Add("@Bank_Name", ht["Bank_Name"].ToString());
                    if (ht["Account_Type"].ToString() == "")
                    {
                        ht_param.Add("@Account_Type", DBNull.Value);
                    }
                    else
                    {
                        ht_param.Add("@Account_Type", ht["Account_Type"].ToString());
                    }
                    ht_param.Add("@IFSC_Code", ht["IFSC_Code"].ToString());
                    ht_param.Add("@Branch_Name", ht["Branch_Name"].ToString());
                    ht_param.Add("@Pan_No", ht["Pan_No"].ToString());
                    ht_param.Add("@MODE", ht["MODE"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[INSERT_Agent_Bank_Details]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            UserSaveModelWithID ___UserSaveModelWithIDDetails = new UserSaveModelWithID();
                            ___UserSaveModelWithIDDetails.CustomErrorState = item["CustomErrorState"].ToString();
                            ___UserSaveModelWithIDDetails.CustomMessage = item["CustomMessage"].ToString();
                            ___UserSaveModelWithIDDetails.ID = item["ID"].ToString();
                            _UserSaveModelWithID.Add(___UserSaveModelWithIDDetails);
                        }
                    }
                    ReturnData["SaveBank"] = serializer.Serialize(_UserSaveModelWithID);

                }

                if (Type == "UpdateBank")
                {
                    _UserSaveModelWithID.Clear();

                    ht_param.Clear();
                    ht_param.Add("@Contact_id", ht["Contact_id"].ToString());
                    ht_param.Add("@Account_Holder_Name", ht["Account_Holder_Name"].ToString());
                    ht_param.Add("@Account_Number", ht["Account_Number"].ToString());
                    ht_param.Add("@Bank_Name", ht["Bank_Name"].ToString());
                    if (ht["Account_Type"].ToString() == "")
                    {
                        ht_param.Add("@Account_Type", DBNull.Value);
                    }
                    else
                    {
                        ht_param.Add("@Account_Type", ht["Account_Type"].ToString());
                    }
                    ht_param.Add("@IFSC_Code", ht["IFSC_Code"].ToString());
                    ht_param.Add("@Branch_Name", ht["Branch_Name"].ToString());
                    ht_param.Add("@Pan_No", ht["Pan_No"].ToString());
                    ht_param.Add("@MODE", ht["MODE"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[INSERT_Agent_Bank_Details]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            UserSaveModelWithID ___UserSaveModelWithIDDetails = new UserSaveModelWithID();
                            ___UserSaveModelWithIDDetails.CustomErrorState = item["CustomErrorState"].ToString();
                            ___UserSaveModelWithIDDetails.CustomMessage = item["CustomMessage"].ToString();
                            ___UserSaveModelWithIDDetails.ID = item["ID"].ToString();
                            _UserSaveModelWithID.Add(___UserSaveModelWithIDDetails);
                        }
                    }
                    ReturnData["UpdateBank"] = serializer.Serialize(_UserSaveModelWithID);

                }

                if (Type == "SavePAN")
                {
                    _UserSaveModelWithID.Clear();

                    ht_param.Clear();
                    ht_param.Add("@Contact_id", ht["Contact_id"].ToString());
                    ht_param.Add("@PANCard_URL", ht["PANCard_URL"].ToString());
                    ht_param.Add("@MODE", ht["MODE"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[INSERT_Agent_PANCard_Details]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            UserSaveModelWithID ___UserSaveModelWithIDDetails = new UserSaveModelWithID();
                            ___UserSaveModelWithIDDetails.CustomErrorState = item["CustomErrorState"].ToString();
                            ___UserSaveModelWithIDDetails.CustomMessage = item["CustomMessage"].ToString();
                            ___UserSaveModelWithIDDetails.ID = item["ID"].ToString();
                            _UserSaveModelWithID.Add(___UserSaveModelWithIDDetails);
                        }
                    }
                    ReturnData["SavePAN"] = serializer.Serialize(_UserSaveModelWithID);

                }

                if (Type == "UpdatePAN")
                {
                    _UserSaveModelWithID.Clear();

                    ht_param.Clear();
                    ht_param.Add("@Contact_id", ht["Contact_id"].ToString());
                    ht_param.Add("@PANCard_URL", ht["PANCard_URL"].ToString());
                    ht_param.Add("@MODE", ht["MODE"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[INSERT_Agent_PANCard_Details]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            UserSaveModelWithID ___UserSaveModelWithIDDetails = new UserSaveModelWithID();
                            ___UserSaveModelWithIDDetails.CustomErrorState = item["CustomErrorState"].ToString();
                            ___UserSaveModelWithIDDetails.CustomMessage = item["CustomMessage"].ToString();
                            ___UserSaveModelWithIDDetails.ID = item["ID"].ToString();
                            _UserSaveModelWithID.Add(___UserSaveModelWithIDDetails);
                        }
                    }
                    ReturnData["UpdatePAN"] = serializer.Serialize(_UserSaveModelWithID);

                }

                if (Type == "SaveApplication")
                {
                    _UserSaveModelWithID.Clear();

                    ht_param.Clear();
                    ht_param.Add("@Contact_id", ht["Contact_id"].ToString());
                    ht_param.Add("@AppicationForm_URL", ht["AppicationForm_URL"].ToString());
                    ht_param.Add("@MODE", ht["MODE"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[INSERT_Agent_AppicationForm_Details]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            UserSaveModelWithID ___UserSaveModelWithIDDetails = new UserSaveModelWithID();
                            ___UserSaveModelWithIDDetails.CustomErrorState = item["CustomErrorState"].ToString();
                            ___UserSaveModelWithIDDetails.CustomMessage = item["CustomMessage"].ToString();
                            ___UserSaveModelWithIDDetails.ID = item["ID"].ToString();
                            _UserSaveModelWithID.Add(___UserSaveModelWithIDDetails);
                        }
                    }
                    ReturnData["SaveApplication"] = serializer.Serialize(_UserSaveModelWithID);

                }

                if (Type == "UpdateApplication")
                {
                    _UserSaveModelWithID.Clear();

                    ht_param.Clear();
                    ht_param.Add("@Contact_id", ht["Contact_id"].ToString());
                    ht_param.Add("@AppicationForm_URL", ht["AppicationForm_URL"].ToString());
                    ht_param.Add("@MODE", ht["MODE"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[INSERT_Agent_AppicationForm_Details]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            UserSaveModelWithID ___UserSaveModelWithIDDetails = new UserSaveModelWithID();
                            ___UserSaveModelWithIDDetails.CustomErrorState = item["CustomErrorState"].ToString();
                            ___UserSaveModelWithIDDetails.CustomMessage = item["CustomMessage"].ToString();
                            ___UserSaveModelWithIDDetails.ID = item["ID"].ToString();
                            _UserSaveModelWithID.Add(___UserSaveModelWithIDDetails);
                        }
                    }
                    ReturnData["UpdateApplication"] = serializer.Serialize(_UserSaveModelWithID);

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



        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static Hashtable SaveAddressProofList(Hashtable ht, string Type, string Req, List<Address_Proof_Model> AddressProofList)
        {
            string Data = "";
            string obj = "";

            Hashtable ht_Blank = new Hashtable();
            Hashtable ReturnData = new Hashtable();
            DBFunctions db = new DBFunctions();
            DataTable dt = new DataTable();
            DataTable dt_AddressProof = new DataTable();


            List<ErrorModel> _ErrorDetails = new List<ErrorModel>();

            ReturnData.Clear();
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            try
            {
                if (Type == "SaveAddressProof")
                {
                    _UserSaveModelWithID.Clear();


                    ht_param.Clear();

                    dt_AddressProof = SaveParameters_AddressProof(AddressProofList);
                    ht_param.Add("@UDT_Agent_AddressProof_Details", dt_AddressProof);
                    ht_param.Add("@Contact_id", ht["Contact_id"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[INSERT_Agent_AddressProof_Details]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            UserSaveModelWithID _UserSaveModelIDDetails = new UserSaveModelWithID();
                            _UserSaveModelIDDetails.CustomErrorState = item["CustomErrorState"].ToString();
                            _UserSaveModelIDDetails.CustomMessage = item["CustomMessage"].ToString();
                            _UserSaveModelWithID.Add(_UserSaveModelIDDetails);
                        }
                    }
                    ReturnData["SaveAddressProof"] = serializer.Serialize(_UserSaveModelWithID);

                }

                ErrorModel _error = new ErrorModel();
                _error.Error = "false";
                _error.ErrorMessage = "Success";
                _ErrorDetails.Add(_error);
                ReturnData["ErrorDetail"] = serializer.Serialize(_ErrorDetails);

                HttpContext.Current.Response.AppendHeader("ResponseHeader", "200");
            }
            catch (Exception ex)
            {

                ErrorModel _error = new ErrorModel();
                _error.Error = "true";
                _error.ErrorMessage = "Some problem occurred please try again later";//ex.ToString();
                _ErrorDetails.Add(_error);
                ReturnData["ErrorDetail"] = serializer.Serialize(_ErrorDetails);

                HttpContext.Current.Response.AppendHeader("ResponseHeader", "500");
            }


            return ReturnData;
        }
        public static DataTable SaveParameters_AddressProof(List<Address_Proof_Model> AddressProofList)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Contact_id", typeof(int));
            dt.Columns.Add("Address_Proof_Type", typeof(string));
            dt.Columns.Add("Address_Proof_URL", typeof(string));

            foreach (var item in AddressProofList)
            {
                dt.Rows.Add(item.id, item.Contact_id, item.Address_Proof_Type,item.Address_Proof_URL);
            }

            return dt;
        }
        public class Address_Proof_Model
        {
            public int id { get; set; }
            public int Contact_id { get; set; }
            public string Address_Proof_Type { get; set; }
            public string Address_Proof_URL { get; set; }

        }

        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static Hashtable SaveBankProofList(Hashtable ht, string Type, string Req, List<Bank_Proof_Model> BankProofList)
        {
            string Data = "";
            string obj = "";

            Hashtable ht_Blank = new Hashtable();
            Hashtable ReturnData = new Hashtable();
            DBFunctions db = new DBFunctions();
            DataTable dt = new DataTable();
            DataTable dt_BankProof = new DataTable();


            List<ErrorModel> _ErrorDetails = new List<ErrorModel>();

            ReturnData.Clear();
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            try
            {
                if (Type == "SaveBankProof")
                {
                    _UserSaveModelWithID.Clear();


                    ht_param.Clear();

                    dt_BankProof = SaveParameters_BankProof(BankProofList);
                    ht_param.Add("@UDT_Agent_BankProof_Details", dt_BankProof);
                    ht_param.Add("@Contact_id", ht["Contact_id"].ToString());
                    ht_param.Add("@Company_ID", HttpContext.Current.Session["Company_ID"].ToString());
                    ht_param.Add("@Branch_ID", HttpContext.Current.Session["Branch_ID"].ToString());
                    ht_param.Add("@Login_user_ID", HttpContext.Current.Session["Login_user_ID"].ToString());
                    ds = db.SysFetchDataInDataSet("[INSERT_Agent_BankProof_Details]", ht_param);
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            UserSaveModelWithID _UserSaveModelIDDetails = new UserSaveModelWithID();
                            _UserSaveModelIDDetails.CustomErrorState = item["CustomErrorState"].ToString();
                            _UserSaveModelIDDetails.CustomMessage = item["CustomMessage"].ToString();
                            _UserSaveModelWithID.Add(_UserSaveModelIDDetails);
                        }
                    }
                    ReturnData["SaveBankProof"] = serializer.Serialize(_UserSaveModelWithID);

                }

                ErrorModel _error = new ErrorModel();
                _error.Error = "false";
                _error.ErrorMessage = "Success";
                _ErrorDetails.Add(_error);
                ReturnData["ErrorDetail"] = serializer.Serialize(_ErrorDetails);

                HttpContext.Current.Response.AppendHeader("ResponseHeader", "200");
            }
            catch (Exception ex)
            {

                ErrorModel _error = new ErrorModel();
                _error.Error = "true";
                _error.ErrorMessage = "Some problem occurred please try again later";//ex.ToString();
                _ErrorDetails.Add(_error);
                ReturnData["ErrorDetail"] = serializer.Serialize(_ErrorDetails);

                HttpContext.Current.Response.AppendHeader("ResponseHeader", "500");
            }


            return ReturnData;
        }
        public static DataTable SaveParameters_BankProof(List<Bank_Proof_Model> BankProofList)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Contact_id", typeof(int));
            dt.Columns.Add("Bank_Proof_Type", typeof(string));
            dt.Columns.Add("Bank_Proof_URL", typeof(string));

            foreach (var item in BankProofList)
            {
                dt.Rows.Add(item.id, item.Contact_id, item.Bank_Proof_Type, item.Bank_Proof_URL);
            }

            return dt;
        }
        public class Bank_Proof_Model
        {
            public int id { get; set; }
            public int Contact_id { get; set; }
            public string Bank_Proof_Type { get; set; }
            public string Bank_Proof_URL { get; set; }

        }

    }
}