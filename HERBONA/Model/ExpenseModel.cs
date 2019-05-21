using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class ExpenseModel
    {
        public string ID { get; set; }
        public string Expense_category_ID { get; set; }
        public string Expense_Date { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }
        public string Unit_ID { get; set; }
        public string Gallons { get; set; }
        public string Odometer { get; set; }
        public string Fuel_Vendor_ID { get; set; }
        public string Country_ID { get; set; }
        public string State_ID { get; set; }
        public string IsActive { get; set; }
    }
}