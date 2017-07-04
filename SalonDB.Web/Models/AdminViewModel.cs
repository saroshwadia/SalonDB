using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SalonDB.Data.Core.Domain;

namespace SalonDB.Web.Models
{
    public class AdminViewModel
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public List<Service> Services { get; set; }
        public List<Category> Categories { get; set; }
        public List<Staff> Staffs { get; set; }
        public List<Store> Stores { get; set; }
        public List<Company> Companies { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Supplier> Suppliers { get; set; }
    }
}