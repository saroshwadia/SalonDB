#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using BusinessObjects;
using SalonDB.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonDB.Web.Controllers
{

    public class HomeController : Controller
    {

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

        [AuthorizeRoles(eRoles.Admin, eRoles.POS, eRoles.FrontDesk, eRoles.User)]
        public ActionResult StaffProfile()
        {
            ViewBag.Message = "Here is the Staff's Profile Information.";

            var StaffViewModelEnt = new StaffViewModel();

            if (MvcApplication.CurrentStaff != null)
            {
                StaffViewModelEnt.StaffID = (Guid)MvcApplication.CurrentStaff.StaffID;
                StaffViewModelEnt.FirstName = MvcApplication.CurrentStaff.FirstName;
                StaffViewModelEnt.LastName = MvcApplication.CurrentStaff.LastName;
                StaffViewModelEnt.Password = MvcApplication.CurrentStaff.Password;
                StaffViewModelEnt.Phone = MvcApplication.CurrentStaff.Phone;
                StaffViewModelEnt.Email = MvcApplication.CurrentStaff.Email;
                StaffViewModelEnt.Address = MvcApplication.CurrentStaff.Address;
                StaffViewModelEnt.City = MvcApplication.CurrentStaff.City;
                StaffViewModelEnt.PostalCode = MvcApplication.CurrentStaff.PostalCode;
                StaffViewModelEnt.Role = MvcApplication.CurrentStaff.Role;
                StaffViewModelEnt.Commission = (decimal)MvcApplication.CurrentStaff.Commission;
                StaffViewModelEnt.Rate = (decimal)MvcApplication.CurrentStaff.Rate;
                StaffViewModelEnt.ResourceColor = MvcApplication.CurrentStaff.ResourceColor;
                StaffViewModelEnt.StoreName = MvcApplication.CurrentStaff.Store.Name;
                StaffViewModelEnt.CompanyName = MvcApplication.CurrentStaff.Company.Name;
            }

            return View(StaffViewModelEnt);
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var DateFrom = DateTime.Now;
            var DateTo = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            var AppointmentCol = new List<AppointmentViewModel>();
            var CustomerCol = new List<CustomerViewModel>();
            var ServiceCol = new List<ServiceViewModel>();
            var ProductCol = new List<ProductViewModel>();
            var TopCount = 5;

            if (System.Diagnostics.Debugger.IsAttached && MvcApplication.CurrentStaff == null && MvcApplication.FirstTime)
            {
                LoginController controller = (LoginController)DependencyResolver.Current.GetService(typeof(LoginController));
                LoginViewModel model = this.GetRandomUser();
                string returnUrl = null;

                if (controller.LogMein(model, returnUrl, this.HttpContext))
                {
                    MvcApplication.FirstTime = false;
                    return RedirectToAction("Index", "Home"); // auth succeed 
                }
            }

            SalonDB.Data.DBProviderEF.EFReloadAll();
            //SalonDB.Data.DBProviderEF.EFReloadEntity(SalonDB.Data.DBProviderEF.Context.Appointments);
            //SalonDB.Data.DBProviderEF.EFReloadEntity(SalonDB.Data.DBProviderEF.Context.Services);
            //SalonDB.Data.DBProviderEF.EFReloadEntity(SalonDB.Data.DBProviderEF.Context.Products);

            if (MvcApplication.CurrentCompany != null)
            {
                foreach (var item in SalonDB.Data.DBProviderEF.GetAppointmentsNotPaid(MvcApplication.CurrentCompany.CompanyID, DateFrom, DateTo, true))
                {
                    TimeSpan oTimeSpan = item.EndTime.Value.Subtract(item.StartTime.Value);
                    AppointmentCol.Add(new Models.AppointmentViewModel { AppointmentID = (Guid)item.AppointmentID, CustomerID = (Guid)item.CustomerID, Subject = item.Subject, AppointmentStart = item.StartTime.Value, AppointmentEnd = item.EndTime.Value, Duration = oTimeSpan.Minutes, CustomerName = $"{item.Customer.FirstName} {item.Customer.LastName}", StaffName = $"{item.Staff.FirstName} {item.Staff.LastName}" });
                }
                foreach (var item in SalonDB.Data.DBProviderEF.GetTopServices(MvcApplication.CurrentCompany.CompanyID, TopCount))
                {
                    ServiceCol.Add(new Models.ServiceViewModel { ServiceID = (Guid)item.ServiceID, Name = item.Name });
                }
                foreach (var item in SalonDB.Data.DBProviderEF.GetTopProducts(MvcApplication.CurrentCompany.CompanyID, TopCount))
                {
                    ProductCol.Add(new Models.ProductViewModel { ProductID = (Guid)item.ProductID, Name = item.Name });
                }
            }

            var POSViewModelEnt = new POSViewModel();

            POSViewModelEnt.StaffEnt = MvcApplication.CurrentStaff;
            POSViewModelEnt.ActionName = "None";
            POSViewModelEnt.ActionMessage = "...";
            POSViewModelEnt.AppointmentCol = AppointmentCol;
            //POSViewModelEnt.CustomerCol = CustomerCol;
            POSViewModelEnt.ServiceCol = ServiceCol;
            POSViewModelEnt.ProductCol = ProductCol;

            return View(POSViewModelEnt);
            //return View();
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

        //[ActionName("Index")]
        //[AcceptVerbs(HttpVerbs.Post)]
        //[AcceptParameter(Name = "Command", Value = "Invoke Event1")]
        //public ActionResult Event1()
        //{
        //    ViewBag.EventNumber = "This is event 1";

        //    return View();
        //}

        //[ActionName("Index")]
        //[AcceptVerbs(HttpVerbs.Post)]
        //[AcceptParameter(Name = "Command", Value = "Invoke Event2")]
        //public ActionResult Event2()
        //{
        //    ViewBag.EventNumber = "This is event 2";

        //    return View();
        //}

        private LoginViewModel GetRandomUser()
        {
            var ReturnValue = new LoginViewModel();
            //var CompanyEnt = SalonDB.Data.DBProviderES.GetCompanyFirst();
            var CompanyEnt = SalonDB.Data.DBProviderEF.GetCompanyFirst();
            var rand = new Random(DateTime.Now.Millisecond);
            var Counter = 0;
            var Random = false;

            ReturnValue.Email = "s.w@gsmtech.com";
            ReturnValue.Password = "12345";
            ReturnValue.RememberMe = false;

            if (Random && CompanyEnt != null)
            {
                //var UserCol = SalonDB.Data.DBProviderES.GetStaffs(CompanyEnt.CompanyID);
                var UserCol = SalonDB.Data.DBProviderEF.GetStaffs(CompanyEnt.CompanyID);

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