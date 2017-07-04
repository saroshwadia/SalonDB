using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonDB.Web.Models
{
    public class ServiceProductViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal DiscountPercentage { get; set; }
        public bool IsService { get; set; }
        public int Sequence { get; set; }
        public decimal Total
        {
            get
            {
                decimal ReturnValue = 0;
                decimal DiscountAmount = 0;
                decimal Amount = 0;

                try
                {
                    Amount = Price * Quantity;
                    DiscountAmount = (DiscountPercentage / 100) * Amount;
                    ReturnValue = Amount - DiscountAmount;
                }
                catch (Exception)
                {
                    ReturnValue = 0;
                }

                return ReturnValue;
            }
        }

        public ServiceProductViewModel()
        {
        }

        public ServiceProductViewModel(Guid iD, string name, decimal price, int quantity, decimal discountPercentage, bool isService, int sequence)
        {
            ID = iD;
            Name = name;
            Price = price;
            Quantity = quantity;
            DiscountPercentage = discountPercentage;
            IsService = isService;
            Sequence = sequence;
        }

    }
}