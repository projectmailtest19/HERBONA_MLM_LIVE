using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class ItemCategorylistModel
    {
        public string ID { get; set; }
        public string NAME { get; set; }
        public string CODE { get; set; }
        public string ImageURL { get; set; } 
        public string IsActive { get; set; }
    }
    public class ItemCategoryModel
    {
        public string ID { get; set; }
        public string NAME { get; set; }
        public string CODE { get; set; }
        public string ImageURL { get; set; }
        public string IsActive { get; set; }
    }
}