using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class gstlistModel
    {
        public string ID { get; set; }
        public string CGST_PERCENTAGE { get; set; }
        public string SGST_PERCENTAGE { get; set; }
        public string IGST_PERCENTAGE { get; set; }
        public string IsActive { get; set; }
    }
    public class gstModel
    {
        public string ID { get; set; }
        public string CGST { get; set; }
        public string SGST { get; set; }
        public string IGST { get; set; }
    }
}