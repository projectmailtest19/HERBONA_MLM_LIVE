using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class RoleModel
    {

        public string ID { get; set; }
        public string Name { get; set; }
        public string Short_Name { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
    }
}