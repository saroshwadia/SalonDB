using SalonDB.Data.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonDB.Web.Models
{
    public class SalesViewModel
    {
        public Guid TransactionID { get; set; }
        public int TransactionNumber { get; set; }
        public string CustomerName { get; set; }
        public string StaffName { get; set; }
        public Guid PaymentTypeID { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal TaxPercent { get; set; }
        public decimal Total { get; set; }
        public decimal TipAmount { get; set; }
        public string Status { get; set; }
        public string PaymentType { get; set; }
    }
}