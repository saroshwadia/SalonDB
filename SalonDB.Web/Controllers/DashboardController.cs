using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SalonDB.Data;
using SalonDB.Data.Core.Domain;
using SalonDB.Data.Persistence;
using SalonDB.Web.Models;

namespace SalonDB.Web.Controllers
{
    public class DashboardController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
        LoginViewModel LoginInfo = new LoginViewModel();
        Staff CurrentStaff = null;

        // GET: Dashboard
        [AuthorizeRoles(eRoles.Admin, eRoles.Owner)]
        public ActionResult Index()
        {
            var DateFrom = DateTime.Now.Date;
            var DateTo = DateTime.Now.Date.AddDays(1).AddMilliseconds(-1);
            var AppointmentCol = new List<AppointmentViewModel>();
            var CustomerCol = new List<CustomerViewModel>();
            var ServiceCol = new List<ServiceViewModel>();
            var ProductCol = new List<ProductViewModel>();
            var ChartSalesByStaffCol = new List<ChartViewModel>();
            var ChartSalesByStoreCol = new List<ChartViewModel>();
            var ChartSalesByHour = new List<ChartViewModel>();
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var TopCount = 5;
            var Counter = 0;
            var GenerateData = true;
            var LoadAllAppointments = false;
            var CurrentMonthStartDate = DateTime.Now.Date;
            var CurrentMonthEndDate = DateTime.Now.Date;
            DateTime StartingDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
            DateTime EndingDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 21, 0, 0);

            //var oSW = new Stopwatch();

            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);

            if (LoginInfo != null && LoginInfo.StaffID != null && LoginInfo.StoreID != Guid.Empty)
            {
                CurrentStaff = unitOfWork.Staffs.Get(LoginInfo.StaffID);
            }

            unitOfWork.RollBack();

            if (LoginInfo != null && LoginInfo.CompanyID != null)
            {

                bool IsAdmin = DBProvider.IsUserAdmin(CurrentStaff);
                bool IsOwner = DBProvider.IsUserOwner(CurrentStaff);
                bool IsStaff = DBProvider.IsUserStaff(CurrentStaff);

                //oSW.Start();

                //foreach (var item in unitOfWork.Appointments.GetAppointmentsNotPaid(LoginInfo.StoreID, DateFrom, DateTo, LoadAllAppointments))
                //{
                //    TimeSpan oTimeSpan = item.EndTime.Value.Subtract(item.StartTime.Value);
                //    var CustomerEnt = unitOfWork.Customers.Get(item.CustomerID);
                //    var StaffEnt = unitOfWork.Staffs.Get(item.StaffID);
                //    if (LoginInfo.StaffID == StaffEnt.StaffID || IsAdmin || IsOwner)
                //    {
                //        AppointmentCol.Add(new Models.AppointmentViewModel { AppointmentID = (Guid)item.AppointmentID, StaffID = (Guid)item.StaffID, CustomerID = (Guid)item.CustomerID, Subject = item.Subject, AppointmentStart = item.StartTime.Value, AppointmentEnd = item.EndTime.Value, Duration = oTimeSpan.Minutes, CustomerName = $"{CustomerEnt.FirstName} {CustomerEnt.LastName}", StaffName = $"{StaffEnt.FirstName} {StaffEnt.LastName}" });
                //    }
                //}

                CurrentMonthStartDate = new DateTime(DateFrom.Year, DateFrom.Month, 01);
                CurrentMonthEndDate = new DateTime(DateFrom.Year, DateFrom.Month, DateTime.DaysInMonth(DateFrom.Year, DateFrom.Month)).AddDays(1).AddMilliseconds(-1);

                foreach (var item in SalonDB.Data.DBProvider.GetTopServices(TopCount, LoginInfo.StoreID, CurrentMonthStartDate.Date, CurrentMonthEndDate.Date))
                {
                    ServiceCol.Add(new Models.ServiceViewModel { ServiceID = Guid.Empty, Name = item.Name, Total = item.Total });
                }

                foreach (var item in SalonDB.Data.DBProvider.GetTopProducts(TopCount, LoginInfo.StoreID, CurrentMonthStartDate.Date, CurrentMonthEndDate.Date))
                {
                    ProductCol.Add(new Models.ProductViewModel { ProductID = Guid.Empty, Name = item.Name, Total = item.Total });
                }

                double TotalStoreActual = 0;
                double TotalStoreBudget = 0;

                foreach (var item in unitOfWork.Staffs.FindAll(c => c.StoreID == LoginInfo.StoreID))
                {
                    Counter++;
                    var ChartByStaffEnt = new ChartViewModel(Counter, $"{item.FirstName} {item.LastName}", rnd.Next(100, 300), rnd.Next(100, 500));
                    TotalStoreActual += ChartByStaffEnt.Value1;
                    TotalStoreBudget += ChartByStaffEnt.Value2;
                    if (IsAdmin)
                    {
                        ChartSalesByStaffCol.Add(ChartByStaffEnt);
                    }
                    else if (LoginInfo.StaffID == item.StaffID)
                    {
                        ChartSalesByStaffCol.Add(ChartByStaffEnt);
                    }
                }

                var StoreEnt = unitOfWork.Stores.Get(LoginInfo.StoreID);
                ChartSalesByStoreCol.Add(new ChartViewModel(Counter, $"{StoreEnt.Name}", TotalStoreActual, TotalStoreBudget));

                //Chart Sales By Hour
                var SalesByHourResult = SalonDB.Data.DBProvider.GetSalesByHour(LoginInfo.StoreID, StartingDateTime, EndingDateTime);

                foreach (var item in SalesByHourResult)
                {
                    var SalesDate = (DateTime)item.Key;
                    var Total = (Double)item.Value;
                    ChartSalesByHour.Add(new ChartViewModel(SalesDate.Hour, $"{SalesDate.Hour}:00", Total, 0, 0, 0, 0));
                }

                //oSW.Stop();
                //var ET = oSW.Elapsed.TotalMilliseconds;
            }

            var POSViewModelEnt = new POSViewModel()
            {
                StaffEnt = CurrentStaff,
                ActionName = "None",
                ActionMessage = "...",
                AppointmentCol = AppointmentCol,
                //POSViewModelEnt.CustomerCol = CustomerCol;
                ServiceCol = ServiceCol,
                ProductCol = ProductCol,
                TargetController = "Home",
                TargetAction = "Index",
                ChartSalesByStaffCol = ChartSalesByStaffCol,
                ChartSalesByStoreCol = ChartSalesByStoreCol,
                ChartSalesByHourCol = ChartSalesByHour
            };
            if (LoginInfo != null)
            {
                POSViewModelEnt.TotalSales = SalonDB.Data.DBProvider.GetSales(LoginInfo.StoreID, CurrentMonthStartDate, CurrentMonthEndDate);
                POSViewModelEnt.TotalAppointmentsToday = SalonDB.Data.DBProvider.GetTotalAppointmentsToday(LoginInfo.StoreID);
                POSViewModelEnt.TotalAppointmentsLastWeek = SalonDB.Data.DBProvider.GetTotalAppointmentsLastWeek(LoginInfo.StoreID);
                POSViewModelEnt.TotalAppointmentsLastYear = SalonDB.Data.DBProvider.GetTotalAppointmentsLastYear(LoginInfo.StoreID);
            }
            var CategoryList = new Dictionary<string, string>();
            CategoryList.Add("Value1", "Goal");
            CategoryList.Add("Value2", "Actual");

            ViewBag.Category = CategoryList;

            return View(POSViewModelEnt);
        }
    }
}