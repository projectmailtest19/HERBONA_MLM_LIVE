using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class TruckLocationModel
    {
        public string ID { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip_Code { get; set; }
        public string Current_Odometer { get; set; }
        public string Date { get; set; }
        public string IsActive { get; set; }
    }
}