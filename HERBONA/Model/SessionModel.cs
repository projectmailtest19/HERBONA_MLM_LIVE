using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class SessionModel
    {
        public string ID { get; set; }
        public string Session_Name { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public string IsActive { get; set; } 
       
    }
    
}