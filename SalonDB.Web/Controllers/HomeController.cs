#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
//using BusinessObjects;
using SalonDB.Data.Core.Domain;
using SalonDB.Data;
using SalonDB.Data.Persistence;
using SalonDB.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;

namespace SalonDB.Web.Controllers
{

    public class HomeController : Controller
    {

        UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
        LoginViewModel LoginInfo = new LoginViewModel();
        Staff CurrentStaff = null;

        [AllowAnonymous]
        //[AuthorizeRoles(eRoles.Admin, eRoles.POS, eRoles.FrontDesk, eRoles.User)]
        public ActionResult Index(bool fromLogout = false)
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

            if (System.Diagnostics.Debugger.IsAttached && !fromLogout && (LoginInfo == null || LoginInfo.StaffID == null))
            {
                LoginController controller = (LoginController)DependencyResolver.Current.GetService(typeof(LoginController));
                LoginViewModel model = this.GetRandomUser();
                string returnUrl = null;

                if (controller.LogMein(model, returnUrl, this.HttpContext))
                {
                    //MvcApplication.FirstTime = false;
                    return RedirectToAction("Index", "Home"); // auth succeed 
                }
            }

            if (GenerateData)
            {
                var MaxTransactions = 0;
                var MaxAppointments = 0;
                var StartDate = DateTime.Now.Date;
                var EndtDate = StartDate.AddDays(7); //new DateTime(2017, 06, 29);

                //SalonDB.Data.DBProvider.GenerateTransactionData(CurrentStaff, MaxTransactions, StartDate, EndtDate, MaxAppointments);

                //var Result = DBProvider.DeleteAppointment(new Guid("BF8B7F4C-93EA-4268-9E40-0ECAE829246A"));
            }

            unitOfWork.RollBack();

            if (LoginInfo != null && LoginInfo.CompanyID != null)
            {

                bool IsAdmin = DBProvider.IsUserAdmin(CurrentStaff);
                bool IsOwner = DBProvider.IsUserOwner(CurrentStaff);
                bool IsStaff = DBProvider.IsUserStaff(CurrentStaff);

                //oSW.Start();

                foreach (var item in unitOfWork.Appointments.GetAppointmentsNotPaid(LoginInfo.StoreID, DateFrom, DateTo, LoadAllAppointments))
                {
                    TimeSpan oTimeSpan = item.EndTime.Value.Subtract(item.StartTime.Value);
                    var CustomerEnt = unitOfWork.Customers.Get(item.CustomerID);
                    var StaffEnt = unitOfWork.Staffs.Get(item.StaffID);
                    if (LoginInfo.StaffID == StaffEnt.StaffID || IsAdmin || IsOwner)
                    {
                        AppointmentCol.Add(new Models.AppointmentViewModel { AppointmentID = (Guid)item.AppointmentID, StaffID = (Guid)item.StaffID, CustomerID = (Guid)item.CustomerID, Subject = item.Subject, AppointmentStart = item.StartTime.Value, AppointmentEnd = item.EndTime.Value, Duration = oTimeSpan.Minutes, CustomerName = $"{CustomerEnt.FirstName} {CustomerEnt.LastName}", StaffName = $"{StaffEnt.FirstName} {StaffEnt.LastName}" });
                    }
                }

                CurrentMonthStartDate = new DateTime(DateFrom.Year, DateFrom.Month, 01);
                CurrentMonthEndDate = new DateTime(DateFrom.Year, DateFrom.Month, DateTime.DaysInMonth(DateFrom.Year, DateFrom.Month)).AddDays(1).AddMilliseconds(-1);

                //foreach (var item in SalonDB.Data.DBProvider.GetTopServices(TopCount, LoginInfo.StoreID, CurrentMonthStartDate.Date, CurrentMonthEndDate.Date))
                //{
                //    ServiceCol.Add(new Models.ServiceViewModel { ServiceID = Guid.Empty, Name = item.Name, Total = item.Total });
                //}

                //foreach (var item in SalonDB.Data.DBProvider.GetTopProducts(TopCount, LoginInfo.StoreID, CurrentMonthStartDate.Date, CurrentMonthEndDate.Date))
                //{
                //    ProductCol.Add(new Models.ProductViewModel { ProductID = Guid.Empty, Name = item.Name, Total = item.Total });
                //}

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
                //var SalesByHourResult = SalonDB.Data.DBProvider.GetSalesByHour(LoginInfo.StoreID, StartingDateTime, EndingDateTime);

                //foreach (var item in SalesByHourResult)
                //{
                //    var SalesDate = (DateTime)item.Key;
                //    var Total = (Double)item.Value;
                //    ChartSalesByHour.Add(new ChartViewModel(SalesDate.Hour, $"{SalesDate.Hour}:00", Total, 0, 0, 0, 0));
                //}

                //oSW.Stop();
                //var ET = oSW.Elapsed.TotalMilliseconds;

                // Test comment for git
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

            //var PaymentTypeCol = DBProvider.GetPaymentTypes(LoginInfo.CompanyID);
            //UpdatePaymentType();

            var CategoryList = new Dictionary<string, string>();
            CategoryList.Add("Value1", "Goal");
            CategoryList.Add("Value2", "Actual");

            ViewBag.Category = CategoryList;

            return View(POSViewModelEnt);
            //return View();
        }

        private void UpdatePaymentType()
        {
            var PaymentTypeCol = DBProvider.GetPaymentTypes(LoginInfo.CompanyID);
            var NotFound = new List<PaymentType>();

            foreach (var PaymentTypeEnt in PaymentTypeCol)
            {
                var TransactionCol = unitOfWork.Transactions.FindAll(c => c.CompanyID == PaymentTypeEnt.CompanyID && c.PaymentType == PaymentTypeEnt.Name).ToList();

                if (TransactionCol.Count > 0)
                {
                    foreach (var TransactionEnt in TransactionCol)
                    {
                        TransactionEnt.PaymentTypeID = PaymentTypeEnt.PaymentTypeID;
                    }

                    unitOfWork.Commit();
                }
                else
                {
                    NotFound.Add(PaymentTypeEnt);
                }

            }

            if (NotFound.Count > 0)
            {
                foreach (var PaymentTypeEnt in NotFound)
                {
                    var Name = PaymentTypeEnt.Name;
                }
            }
        }

        [HttpPost]
        [AcceptActionNameParameter(Name = "action", Argument = "Save")]
        public ActionResult Save(POSViewModel POSViewModelEnt)
        {
            POSViewModelEnt.ActionName = "Save";
            POSViewModelEnt.ActionMessage = "Changes Saved...";

            return View(POSViewModelEnt);
        }

        [HttpPost]
        [AcceptActionNameParameter(Name = "action", Argument = "Cancel")]
        public ActionResult Cancel(POSViewModel POSViewModelEnt)
        {

            POSViewModelEnt.ActionName = "Cancel";
            POSViewModelEnt.ActionMessage = "Changes Cancelled...";

            return View(POSViewModelEnt);
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Salon Management - by GSM Tech.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Salon Management - by GSM Tech.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            ViewBag.Message = "Register New Company";

            var Data = new RegisterCompanyViewModel()
            {
                ID = Guid.NewGuid(),
                FirstName = "",
                LastName = "",
                CompanyName = "New Company",
                StoreName = "Main Store"
            };

            return View(Data);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(RegisterCompanyViewModel RegisterCompanyViewModelEnt)
        {
            var ErrorList = new List<string>();
            var DefaultRole = $"{eRoles.Admin.ToString()}; {eRoles.Owner.ToString()}; {eRoles.Staff.ToString()}";
            var TimeZone = "UTC -06:00";
            var CaptchaError = "Captcha is not valid";
            var CaptchaValid = false;
            var RegisteredOn = DateTime.Now;
            var RegistrationType = eRegistrationType.Trial.ToString();

            if (ModelState.IsValid)
            {

                CaptchaValid = this.IsCaptchaValid(CaptchaError);

                var StaffEnt = SalonDB.Data.DBProvider.RegisterCompany(RegisterCompanyViewModelEnt.FirstName, RegisterCompanyViewModelEnt.LastName, RegisterCompanyViewModelEnt.Phone, RegisterCompanyViewModelEnt.Email, RegisterCompanyViewModelEnt.Password, RegisterCompanyViewModelEnt.CompanyName, RegisterCompanyViewModelEnt.StoreName, RegisterCompanyViewModelEnt.StoreAddress, RegisterCompanyViewModelEnt.StoreCity, RegisterCompanyViewModelEnt.StorePostalCode, TimeZone, DefaultRole, RegisteredOn, RegistrationType, ref ErrorList, CaptchaValid, CaptchaError);

                if (ErrorList.Count > 0)
                {
                    // Code to add errors to the MmodelState.Errors
                    foreach (var item in ErrorList)
                    {
                        ModelState.AddModelError("", item);
                    }
                }

                if (StaffEnt != null)
                {
                    var CompanyEnt = unitOfWork.Companys.Get(StaffEnt.CompanyID);

                    LoginController controller = (LoginController)DependencyResolver.Current.GetService(typeof(LoginController));
                    LoginViewModel model = new LoginViewModel();
                    string returnUrl = null;

                    model.Email = StaffEnt.Email;
                    model.Password = StaffEnt.Password;
                    model.RememberMe = false;

                    if (controller.LogMein(model, returnUrl, this.HttpContext))
                    {
                        return RedirectToAction("Index", "Home"); // auth succeed 
                    }

                }

            }

            return View(RegisterCompanyViewModelEnt);
        }

        [AuthorizeRoles(eRoles.Admin, eRoles.POS, eRoles.FrontDesk, eRoles.User)]
        public ActionResult StaffProfile()
        {
            ViewBag.Message = "Here is the Staff's Profile Information.";

            var StaffViewModelEnt = new StaffViewModel();

            if (CurrentStaff != null)
            {
                var StoreEnt = unitOfWork.Stores.Get(LoginInfo.StoreID);
                var CompanyEnt = unitOfWork.Companys.Get(LoginInfo.CompanyID);

                StaffViewModelEnt.StaffID = (Guid)CurrentStaff.StaffID;
                StaffViewModelEnt.FirstName = CurrentStaff.FirstName;
                StaffViewModelEnt.LastName = CurrentStaff.LastName;
                StaffViewModelEnt.Password = CurrentStaff.Password;
                StaffViewModelEnt.Phone = CurrentStaff.Phone;
                StaffViewModelEnt.Email = CurrentStaff.Email;
                StaffViewModelEnt.Address = CurrentStaff.Address;
                StaffViewModelEnt.City = CurrentStaff.City;
                StaffViewModelEnt.PostalCode = CurrentStaff.PostalCode;
                StaffViewModelEnt.Role = CurrentStaff.Role;
                StaffViewModelEnt.Commission = (decimal)CurrentStaff.Commission;
                StaffViewModelEnt.Rate = (decimal)CurrentStaff.Rate;
                StaffViewModelEnt.ResourceColor = CurrentStaff.ResourceColor;
                StaffViewModelEnt.StoreName = StoreEnt.Name;
                StaffViewModelEnt.CompanyName = CompanyEnt.Name;
            }

            return View(StaffViewModelEnt);
        }

        private LoginViewModel GetRandomUser()
        {
            var ReturnValue = new LoginViewModel();
            //var CompanyEnt = SalonDB.Data.DBProviderES.GetCompanyFirst();
            var CompanyEnt = unitOfWork.Companys.GetCompanyFirst();
            var rand = new Random(DateTime.Now.Millisecond);
            var Counter = 0;
            var Random = false;

            ReturnValue.Email = "s.w@gsmtech.com";
            ReturnValue.Password = "12345";
            ReturnValue.RememberMe = false;

            if (Random && CompanyEnt != null)
            {
                //var UserCol = SalonDB.Data.DBProviderES.GetStaffs(CompanyEnt.CompanyID);
                var UserCol = unitOfWork.Staffs.FindAll(c => c.CompanyID == CompanyEnt.CompanyID).ToList();

                if (UserCol.Count > 0)
                {
                    Counter = rand.Next(0, UserCol.Count);

                    ReturnValue.Email = UserCol[Counter].Email;
                    ReturnValue.Password = UserCol[Counter].Password;
                    ReturnValue.RememberMe = false;

                }

            }

            return ReturnValue;
        }

    }
}