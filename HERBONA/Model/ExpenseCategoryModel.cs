using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class ExpenseCategoryModel
    {
        public string ID { get; set; }
        public string ExpenseCategory_Name { get; set; }
        public string ExpenseCategory_Description { get; set; }
        public string IsActive { get; set; }
    }
}