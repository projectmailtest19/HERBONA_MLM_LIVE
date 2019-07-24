using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class ErrorModel
    {
        public string Error { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class UserSaveModel
    {
        public string CustomErrorState { get; set; }
        public string CustomMessage { get; set; }
    }
    public class UserSaveModelWithID
    {
        public string ID { get; set; }
        public string CustomErrorState { get; set; }
        public string CustomMessage { get; set; }

    }
    public class UserSaveModelWithPopupdetails
    {
        public string CustomErrorState { get; set; }
        public string CustomMessage { get; set; }
        public string Account_Number { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }

    }
    public class UserSaveModelWithEmailDetails
    {
        public string ID { get; set; }
        public string CustomErrorState { get; set; }
        public string CustomMessage { get; set; }
        public string Email_ID { get; set; }
        public string Passward { get; set; }
        public string Agent_Name { get; set; }
    }
}