//using BusinessObjects;
using SalonDB.Data.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonDB.Web.Models
{
    public class POSViewModel
    {
        public Guid? TransactionID { get; set; }
        public Staff StaffEnt { get; set; }
        public Customer CustomerEnt { get; set; }
        public Guid? StaffID { get; set; }
        public Guid ServiceID { get; set; }
        public Guid ProductID { get; set; }
        public Guid? AppointmentID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid WalkInCustomerID { get; set; }
        public string ActionName { get; set; }
        public string ActionMessage { get; set; }
        public bool DataSaved { get; set; }
        public bool FromInvoice { get; set; }
        public string TargetController { get; set; }
        public string TargetAction { get; set; }
        public string AppointmentIDString
        {
            get
            {
                var ReturnValue = string.Empty;

                if (AppointmentID == null || AppointmentID == Guid.Empty)
                {
                    ReturnValue = string.Empty;
                }
                else
                {
                    ReturnValue = AppointmentID.ToString();
                }

                return ReturnValue;
            }
        }
        public string TransactionIDString
        {
            get
            {
                var ReturnValue = string.Empty;

                if (TransactionID == null || TransactionID == Guid.Empty)
                {
                    ReturnValue = string.Empty;
                }
                else
                {
                    ReturnValue = TransactionID.ToString();
                }

                return ReturnValue;
            }
        }
        public string StaffIDString
        {
            get
            {
                var ReturnValue = string.Empty;

                if (StaffID == null || StaffID == Guid.Empty)
                {
                    ReturnValue = string.Empty;
                }
                else
                {
                    ReturnValue = StaffID.ToString();
                }

                return ReturnValue;
            }
        }
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
        public List<TransactionViewModel> TransactionCol { get; set; }
        public List<CustomerViewModel> CustomerCol { get; set; }
        public List<ServiceViewModel> ServiceCol { get; set; }
        public List<ProductViewModel> ProductCol { get; set; }
        public List<StaffViewModel> StaffCol { get; set; }
        public List<ServiceProductViewModel> ServiceProductViewModelCol { get; set; }
        public List<PaymentTypeViewModel> PaymentTypeCol { get; set; }
        public List<SalesViewModel> SalesCol { get; set; }
        public List<ChartViewModel> ChartSalesByStaffCol { get; set; }
        public List<ChartViewModel> ChartSalesByStoreCol { get; set; }
        public List<ChartViewModel> ChartSalesByHourCol { get; set; }
        public Dictionary<string, string> CategoryList { get; set; }

        public decimal TotalSales { get; set; }
        public int TotalAppointmentsToday { get; set; }
        public int TotalAppointmentsLastWeek { get; set; }
        public int TotalAppointmentsLastYear { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }

    public class AppointmentViewModel
    {
        public Guid AppointmentID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid StaffID { get; set; }
        public String Subject { get; set; }
        public String CustomerName { get; set; }
        public String StaffName { get; set; }
        public DateTime AppointmentStart { get; set; }
        public DateTime AppointmentEnd { get; set; }
        public int Duration { get; set; }
        public String Status { get; set; }
    }

    public class TransactionViewModel
    {
        public Guid TransactionID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid StaffID { get; set; }
        public String Subject { get; set; }
        public String CustomerName { get; set; }
        public String StaffName { get; set; }
    }

    public class CustomerViewModel
    {
        public Guid CustomerID { get; set; }
        public String Name { get; set; }
    }

    public class PaymentTypeViewModel
    {
        public Guid PaymentTypeID { get; set; }
        public String Name { get; set; }
        public int Sequence { get; set; }
        public bool Other { get; set; }
    }

    public class ServiceViewModel
    {
        public Guid ServiceID { get; set; }
        public String Name { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public int Duration { get; set; }
    }

    public class ProductViewModel
    {
        public Guid ProductID { get; set; }
        public String Name { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
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

    public class SalesChartViewModel
    {
        public string X { get; set; }
        public int Y { get; set; }
    }
}