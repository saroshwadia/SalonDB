//using BusinessObjects;
using SalonDB.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonDB.Web.Models
{
    public class POSViewModel
    {
        public Staff StaffEnt { get; set; }
        public Guid ServiceID { get; set; }
        public Guid ProductID { get; set; }
        public Guid AppointmentID { get; set; }
        public string ActionName { get; set; }
        public string ActionMessage { get; set; }
        public bool DataSaved { get; set; }
        public string StaffName
        {
            get
            {
                var ReturnValue = string.Empty;

                if (StaffEnt != null)
                {
                    ReturnValue = $"{StaffEnt.FirstName} {StaffEnt.LastName}";
                }

                return ReturnValue;
            }
        }
        public List<AppointmentViewModel> AppointmentCol { get; set; }
        public List<CustomerViewModel> CustomerCol { get; set; }
        public List<ServiceViewModel> ServiceCol { get; set; }
        public List<ProductViewModel> ProductCol { get; set; }
        public List<StaffViewModel> StaffCol { get; set; }
        public List<ServiceProductViewModel> ServiceProductViewModelCol { get; set; }
    }

    public class AppointmentViewModel
    {
        public Guid AppointmentID { get; set; }
        public Guid CustomerID { get; set; }
        public String Subject { get; set; }
        public String CustomerName { get; set; }
        public String StaffName { get; set; }
        public DateTime AppointmentStart { get; set; }
        public DateTime AppointmentEnd { get; set; }
        public int Duration { get; set; }
    }

    public class CustomerViewModel
    {
        public Guid CustomerID { get; set; }
        public String Name { get; set; }
    }

    public class ServiceViewModel
    {
        public Guid ServiceID { get; set; }
        public String Name { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductViewModel
    {
        public Guid ProductID { get; set; }
        public String Name { get; set; }
        public decimal Price { get; set; }
    }

    public class StaffViewModel
    {
        public Guid StaffID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Password { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String PostalCode { get; set; }
        public String Role { get; set; }
        public decimal Commission { get; set; }
        public decimal Rate { get; set; }
        public string ResourceColor { get; set; }
        public String CompanyName { get; set; }
        public String StoreName { get; set; }
        //public string FullName { get { return $"{this.FirstName} {this.LastName}"; } }
        public string Name { get; set; }
    }
}