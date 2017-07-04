using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonDB.Data.Core
{
    public partial class spSalesOvertimeByService_Result
    {
        public int TransactionNumber { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public decimal TaxTaxPercent { get; set; }
        public string TType { get; set; }
        public System.Guid TransactionID { get; set; }
        public System.Guid CompanyID { get; set; }
        public Nullable<int> Month { get; set; }
    }

    public partial class spServiceSalesOvertime_Result
    {
        public string Name { get; set; }
        public Nullable<decimal> Amount { get; set; }
    }

    public partial class spSalesComparison_Result
    {
        public Nullable<decimal> Revenue { get; set; }
        public string MonthName { get; set; }
        public Nullable<int> Month { get; set; }
        public Nullable<decimal> CurrentYear { get; set; }
        public Nullable<decimal> PreviousYear { get; set; }
        public System.Guid CompanyID { get; set; }
    }

    public partial class spSalesByCompany_Result
    {
        public int TransactionNumber { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public decimal TaxPercent { get; set; }
        public string TType { get; set; }
        public System.Guid TransactionID { get; set; }
        public System.Guid CompanyID { get; set; }
        public Nullable<int> Month { get; set; }
    }

    public partial class spServiceTransactionsByCompany_Result
    {
        public int TransactionNumber { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public decimal TaxTaxPercent { get; set; }
        public string TType { get; set; }
        public System.Guid TransactionID { get; set; }
        public System.Guid CompanyID { get; set; }
        public Nullable<int> Month { get; set; }
        public string StrMonth { get; set; }
    }

    public partial class spPOS_Result
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> DiscountPercent { get; set; }
        public Nullable<decimal> Total { get; set; }
    }

    public partial class spTransactionData_Result
    {
        public int TransactionNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> DiscountPercent { get; set; }
        public Nullable<decimal> TaxPercent { get; set; }
        public Nullable<decimal> Total { get; set; }
        public string PaymentType { get; set; }
    }

    public partial class spTopServiceProducts_Result
    {
        public string Name { get; set; }
        public decimal Total { get; set; }
    }

    public partial class spSalesByHour_Result
    {
        public DateTime Hour { get; set; }
        public decimal Total { get; set; }
        public int Count { get; set; }
    }

    public partial class spCategorySummaryDetail_Result
    {
        public string Name { get; set; }
        public System.Guid CategoryID { get; set; }
        public Nullable<decimal> ServiceCount { get; set; }
        public Nullable<decimal> ServiceTotal { get; set; }
        public Nullable<decimal> ProductCount { get; set; }
        public Nullable<decimal> ProductTotal { get; set; }
    }

    public partial class spCategoryDetailProduct_Result
    {
        public int TransactionNumber { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
     public System.Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }

        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> TotalCost { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
    }

    public partial class spCategoryDetailService_Result
    {
        public int TransactionNumber { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public System.Guid CategoryID { get; set; }
        public string CategoryName { get; set; }

        public string Name { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }

        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> TotalCost { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
    }

    public partial class spCashOutSummary_Result
    {
       
        public string Name { get; set; }
        public Nullable<int> PCount { get; set; }
        public Nullable<decimal> Total { get; set; }
     
    }

    public partial class spCashOutDetail_Result
    {
        public string Name { get; set; }
        public int TransactionNumber { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> TipAmount { get; set; }
    }
}
