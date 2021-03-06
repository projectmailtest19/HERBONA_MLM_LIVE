﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class ItemDetails_ListModel
    {
        public string ID { get; set; }
        public string CATEGORY_ID { get; set; }
        public string NAME { get; set; }
        public string PBO_PRICE { get; set; }
        public string PRODUCT_SVP { get; set; }
        public string DISCOUNT_PERCENTAGE { get; set; }
        public string DISCOUNT_AMOUNT { get; set; }
        public string CODE { get; set; }
        public string GST_ID { get; set; }
        public string MRP { get; set; }
        public string SALE_PRICE { get; set; }
        public string ImageURL { get; set; }
        public string IsActive { get; set; }
        public string CATEGORY_NAME { get; set; }
        public string IGST_PERCENTAGE { get; set; }
        public string CGST_PERCENTAGE { get; set; }
        public string SGST_PERCENTAGE { get; set; }
        public string QUANTITY { get; set; }
        public string Total_SVP { get; set; }
        public string Total_Amount { get; set; }
    }
    public class ItemDetailsModel
    {
        public string ID { get; set; }
        public string CATEGORY_ID { get; set; }
        public string NAME { get; set; }
        public string PBO_PRICE { get; set; }
        public string PRODUCT_SVP { get; set; }
        public string DISCOUNT_PERCENTAGE { get; set; }
        public string DISCOUNT_AMOUNT { get; set; }
        public string CODE { get; set; }
        public string GST_ID { get; set; }
        public string MRP { get; set; }
        public string SALE_PRICE { get; set; }
        public string ImageURL { get; set; }
        public string IsActive { get; set; }
        public string CATEGORY_NAME { get; set; }
        public string IGST_PERCENTAGE { get; set; }
        public string CGST_PERCENTAGE { get; set; }
        public string SGST_PERCENTAGE { get; set; }
    }
    public class OrderTotalModel
    {
        public string ORDER_DATE { get; set; }
        public string INVOICE_DATE { get; set; }
        public string INVOICE_NUMBER { get; set; }
        public string TOTAL_SVP { get; set; }
        public string TOTAL_AMOUNT { get; set; }
        public string ORDER_NUMBER { get; set; }
    }

    public class ShippingAddressModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string addressline { get; set; }
        public string District_Name { get; set; }
        public string State_Name { get; set; }
        public string Country_Name { get; set; }
        public string pincode { get; set; }
        public string MobileNo { get; set; }
        public string is_default { get; set; }
    }
    public class ShippingMethodModel
    {
        public string ID { get; set; }
        public string NAME { get; set; }
        public string CODE { get; set; }
        public string IsActive { get; set; }
    }
}