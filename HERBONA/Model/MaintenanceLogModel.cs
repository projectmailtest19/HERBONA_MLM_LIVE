using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class MaintenanceLogModel
    {
        public string ID { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
        public string Maintenance_Vendor { get; set; }
        public string Amount { get; set; }
        public string Repair_Date { get; set; }
        public string Odometer { get; set; }
       
        public string IsActive { get; set; }
    }
}