using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SalonDB.Data.Core.Domain;
using System.Collections;
using Syncfusion.JavaScript.DataSources;
using Syncfusion.Linq;
using SalonDB.Data;
using SalonDB.Web.Models;
using SalonDB.Web;
using SalonDB.Data.Persistence;

namespace SalonManagement.Web.Controllers
{
    public class CustomerInfoController : Controller
    {
        // GET: Products
        UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
        LoginViewModel LoginInfo = new LoginViewModel();
        Staff CurrentStaff = null;

        public ActionResult Index()
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);
            var Data = SalonDB.Data.DBProvider.GetCustomers(LoginInfo.CompanyID);

            return View(Data);
        }

        public ActionResult CustomerDetails(Guid id)
        {
            var Customer = DBProvider.GetCustomer(id);

            return View(Customer);
        }

        public ActionResult CustomerAppointments(Guid id)
        {
            var AppointmentCol = new List<AppointmentViewModel>();
            var DateFrom = DateTime.Now.Date;
            var DateTo = DateTime.MaxValue; //DateTime.Now.Date.AddDays(1).AddMilliseconds(-1);
            var LoadAllAppointments = false;
            var IsAdmin = true;
            var IsOwner = true;
            var CustomerEnt = unitOfWork.Customers.Get(id);

            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);
            CurrentStaff = unitOfWork.Staffs.Get(LoginInfo.StaffID);

            foreach (var item in unitOfWork.Appointments.GetAppointmentsNotPaid(LoginInfo.StoreID, DateFrom, DateTo, LoadAllAppointments, id))
            {
                TimeSpan oTimeSpan = item.EndTime.Value.Subtract(item.StartTime.Value);
                var StaffEnt = unitOfWork.Staffs.Get(item.StaffID);
                if (LoginInfo.StaffID == StaffEnt.StaffID || IsAdmin || IsOwner)
                {
                    AppointmentCol.Add(new SalonDB.Web.Models.AppointmentViewModel { AppointmentID = (Guid)item.AppointmentID, StaffID = (Guid)item.StaffID, CustomerID = (Guid)item.CustomerID, Subject = item.Subject, AppointmentStart = item.StartTime.Value, AppointmentEnd = item.EndTime.Value, Duration = oTimeSpan.Minutes, CustomerName = $"{CustomerEnt.FirstName} {CustomerEnt.LastName}", StaffName = $"{StaffEnt.FirstName} {StaffEnt.LastName}", Status = GetAppointmentStatus(item.Status) });
                }
            }

            var POSViewModelEnt = new POSViewModel()
            {
                StaffEnt = CurrentStaff,
                CustomerEnt = CustomerEnt,
                DateFrom = DateFrom,
                DateTo = DateTo,
                ActionName = "None",
                ActionMessage = "...",
                AppointmentCol = AppointmentCol,
                //POSViewModelEnt.CustomerCol = CustomerCol;
                ServiceCol = null,
                ProductCol = null,
                TargetController = "Home",
                TargetAction = "Index",
                ChartSalesByStaffCol = null,
                ChartSalesByStoreCol = null,
                ChartSalesByHourCol = null
            };

            return View(POSViewModelEnt);
        }

        public ActionResult CustomerTransactions(Guid id)
        {
            var SalesCol = new List<SalesViewModel>();
            var DateFrom = DateTime.MinValue;
            var DateTo = DateTime.MaxValue; //DateTime.Now.Date.AddDays(1).AddMilliseconds(-1);
            var IsAdmin = true;
            var IsOwner = true;
            var CustomerEnt = unitOfWork.Customers.Get(id);
            var MinDate = DateTime.MaxValue;
            var MaxDate = DateTime.MinValue;

            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);
            CurrentStaff = unitOfWork.Staffs.Get(LoginInfo.StaffID);

            foreach (var item in DBProvider.GetCustomerSales(DateFrom.Date, DateTo.Date, CustomerEnt.CustomerID, LoginInfo.CompanyID))
            {
                if (MinDate > item.TransactionDate.Value)
                {
                    MinDate = item.TransactionDate.Value;
                }

                if (MaxDate < item.TransactionDate.Value)
                {
                    MaxDate = item.TransactionDate.Value;
                }

                var StaffEnt = unitOfWork.Staffs.Get((Guid)item.StaffID);
                if (LoginInfo.StaffID == StaffEnt.StaffID || IsAdmin || IsOwner)
                {
                    SalesCol.Add(new SalonDB.Web.Models.SalesViewModel { TransactionID = (Guid)item.TransactionID, CustomerName = $"{CustomerEnt.FirstName} {CustomerEnt.LastName}", StaffName = $"{StaffEnt.FirstName} {StaffEnt.LastName}", Amount = item.Amount, TaxPercent = item.TaxPercent, DiscountPercent = item.DiscountPercent, TipAmount = item.TipAmount, Total = item.Total, TransactionDate = (DateTime)item.TransactionDate, TransactionNumber = item.TransactionNumber, Status = item.Status, PaymentTypeID = (Guid)item.PaymentTypeID, PaymentType = item.PaymentType });
                }
            }

            var POSViewModelEnt = new POSViewModel()
            {
                StaffEnt = CurrentStaff,
                CustomerEnt = CustomerEnt,
                DateFrom = MinDate,
                DateTo = MaxDate,
                ActionName = "None",
                ActionMessage = "...",
                //AppointmentCol = AppointmentCol,
                //POSViewModelEnt.CustomerCol = CustomerCol;
                ServiceCol = null,
                ProductCol = null,
                SalesCol = SalesCol,
                TargetController = "Home",
                TargetAction = "Index",
                ChartSalesByStaffCol = null,
                ChartSalesByStoreCol = null,
                ChartSalesByHourCol = null
            };

            //if (SalesCol.Count == 0)
            //{
            //    POSViewModelEnt.DateFrom = null;
            //    POSViewModelEnt.DateTo = null;
            //}

            return View(POSViewModelEnt);
        }

        private string GetAppointmentStatus(int status)
        {
            var ReturnValue = SalonDB.Data.CategorizeSettings.GetStatus(status.ToString());

            return ReturnValue;
        }

    }
}
