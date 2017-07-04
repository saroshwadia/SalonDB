﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using SalonDB.Web.Models;
using SalonDB.Data;
using SalonDB.Data.Persistence;

namespace SalonDB.Web.Controllers
{
    public class AppointmentController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
        LoginViewModel LoginInfo = new LoginViewModel();
        string _CurrentTimeZone = "UTC -06:00";

        public AppointmentController()
        {
            _CurrentTimeZone = SalonDB.Data.DBProvider.GetCurrentTimeZone();
            _CurrentTimeZone = SalonDB.Data.DBProvider.GetTimeZoneByStoreID();
        }

        [AuthorizeRoles(eRoles.Admin, eRoles.FrontDesk, eRoles.POS)]
        public ActionResult Index(string errorMessage = "")
        {
            var DataSource = GetDataSource(DateTime.Now);
            DataSource.ServerTimeZone = SalonDB.Data.DBProvider.GetCurrentTimeZone();

            if (!string.IsNullOrEmpty(errorMessage))
            {
                ModelState.AddModelError("", errorMessage);
            }

            return View(DataSource);
        }

        [AuthorizeRoles(eRoles.Admin, eRoles.FrontDesk, eRoles.POS)]
        public JsonResult GetResData()
        {
            List<ResourceFields> Resources = new List<ResourceFields>();

            //var Col = SalonDB.Data.DBProviderEF.GetStaffs(LoginInfo.CompanyID);
            //var Col = unitOfWork.Staffs.FindAll(c => c.CompanyID == LoginInfo.CompanyID);

            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);

            foreach (var item in unitOfWork.Staffs.FindAll(c => c.StoreID == LoginInfo.StoreID && c.Role.ToLower().Contains(eRoles.Staff.ToString().ToLower())).OrderBy(c => c.FirstName).ThenBy(c => c.LastName))
            {
                Resources.Add(new ResourceFields { ID = item.StaffID.ToString(), Text = $"{item.FirstName} {item.LastName}", Color = item.ResourceColor });
            }
            return Json(Resources, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AuthorizeRoles(eRoles.Admin, eRoles.FrontDesk, eRoles.POS)]
        public JsonResult GetData(string CurrentView, DateTime CurrentDate, string CurrentAction)
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);

            var data = AppointmentRepositoryModel.FilterAppointment(CurrentDate, CurrentAction, CurrentView, LoginInfo.StoreID);
            BatchDataResult result = new BatchDataResult();
            result.result = data;
            result.count = 1; //db.ScheduleDatas.ToList().Count > 0 ? db.ScheduleDatas.ToList().Max(p => p.Id) : 1;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AuthorizeRoles(eRoles.Admin, eRoles.FrontDesk, eRoles.POS)]
        public JsonResult Batch(EditParams param)
        {

            try
            {
                LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);
                SchedulerEntity result = new SchedulerEntity();

                if (param.action == "insert" || (param.action == "batch" && param.added != null))          // this block of code will execute while inserting the appointments
                {
                    var value = param.action == "insert" ? param.value : param.added[0];
                    result = AppointmentRepositoryModel.Insert(value, LoginInfo, _CurrentTimeZone);
                }
                if (param.action == "remove" || param.deleted != null)                                        // this block of code will execute while removing the appointment
                {
                    if (param.action == "remove")
                        result = AppointmentRepositoryModel.Remove(Guid.Parse(param.key));
                    else
                    {
                        foreach (var dele in param.deleted)
                        {
                            result = AppointmentRepositoryModel.Remove(Guid.Parse(dele.Id));
                        }
                    }
                }
                if ((param.action == "batch" && param.changed != null) || param.action == "update")   // this block of code will execute while updating the appointment
                {
                    var value = param.action == "update" ? param.value : param.changed[0];
                    result = AppointmentRepositoryModel.Update(value, LoginInfo, _CurrentTimeZone);
                }

            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                throw new HttpException(404, $"Error for Action: {param.action} Message: {ex.Message}");
                //ViewBag.ErrorMessage = ex.Message;
                //RedirectToAction("Index", new { errorMessage = ex.Message });
            }

            IEnumerable data = new List<SchedulerEntity>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [AuthorizeRoles(eRoles.Admin, eRoles.FrontDesk, eRoles.POS)]
        public ActionResult Error()
        {
            var DataSource = GetDataSource(DateTime.Now);
            DataSource.ServerTimeZone = SalonDB.Data.DBProvider.GetCurrentTimeZone();

            return View(DataSource);
        }

        private SchedulerViewModel GetDataSource(DateTime? dateStart = null)
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);
            _CurrentTimeZone = SalonDB.Data.DBProvider.GetTimeZoneByStoreID(LoginInfo.StoreID);

            var CustomerEnt = unitOfWork.Customers.GetCustomerWalkIn(LoginInfo.CompanyID);
            var DataSource = new SchedulerViewModel()
            {
                CurrentDate = dateStart == null ? DateTime.Now.Date : (DateTime)dateStart,
                CurrentTimeZone = _CurrentTimeZone,
                CustomerCol = new List<CustomerViewModel>(),
                StaffCol = new List<StaffViewModel>(),
                ResourceCol = new List<ResourceFields>(),
                ServiceCol = new List<ServiceViewModel>()
            };

            //For Testing
            //SalonDB.Data.DBProviderEF.EFReloadAll();

            //Datasource for Grouping Resources
            List<String> Group = new List<String>();
            Group.Add("Owners");

            //int intValue = 16294808;
            //// Convert integer 182 as a hex in a string variable
            //string hexValue = intValue.ToString("X");
            //// Convert the hex string back to the number
            //int intAgain = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);

            //Context Menu for Appointments-- >
            List<Syncfusion.JavaScript.Models.Appointment> AppContextMenu = new List<Syncfusion.JavaScript.Models.Appointment>();
            AppContextMenu.Add(new Syncfusion.JavaScript.Models.Appointment { Id = "checkout", Text = "CheckOut" });
            AppContextMenu.Add(new Syncfusion.JavaScript.Models.Appointment { Id = "open", Text = "Open Appointment" });
            AppContextMenu.Add(new Syncfusion.JavaScript.Models.Appointment { Id = "delete", Text = "Delete Appointment" });

            var CategorizeSettings = SalonDB.Data.CategorizeSettings.GetData();

            foreach (var item in unitOfWork.Customers.FindAll(c => c.CompanyID == LoginInfo.CompanyID).OrderBy(c => c.FirstName).ThenBy(c => c.LastName).ToList())
            {
                DataSource.CustomerCol.Add(new CustomerViewModel { CustomerID = item.CustomerID, Name = $"{item.FirstName} {item.LastName}" });
            }

            foreach (var item in unitOfWork.Staffs.FindAll(c => c.StoreID == LoginInfo.StoreID).OrderBy(c => c.FirstName).ThenBy(c => c.LastName).ToList())
            {
                DataSource.ResourceCol.Add(new ResourceFields { ID = item.StaffID.ToString(), Text = item.FullName, Color = item.ResourceColor });
                DataSource.StaffCol.Add(new StaffViewModel { StaffID = item.StaffID, Name = item.FullName, ResourceColor = item.ResourceColor });
            }

            foreach (var item in unitOfWork.Services.FindAll(c => c.CompanyID == LoginInfo.CompanyID).OrderBy(c => c.Name).ToList())
            {
                DataSource.ServiceCol.Add(new ServiceViewModel { ServiceID = item.ServiceID, Name = item.Name, Price = item.Price, Duration = item.Duration });
            }

            DataSource.CurrentCustomerID = CustomerEnt.CustomerID;
            DataSource.CurrentStaffID = LoginInfo.StaffID;
            DataSource.CurrentStatus = SalonDB.Data.CategorizeSettings.GetScheduledID();
            DataSource.GroupCol = Group;
            DataSource.AppContextMenu = AppContextMenu;
            DataSource.CategorizeSettings = CategorizeSettings;

            return DataSource;
        }

        public class BatchDataResult
        {
            public IEnumerable result { get; set; }
            public int count { get; set; }
        }

        [AuthorizeRoles(eRoles.Admin, eRoles.FrontDesk, eRoles.POS)]
        public JsonResult AddCustomer(string customerName, string customerPhone, string customerEmail)
        {
            object[] ReturnValue = new object[2];

            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);
            ReturnValue = MvcApplication.AddCustomer(customerName, customerPhone, customerEmail, LoginInfo, unitOfWork);

            return Json(ReturnValue, JsonRequestBehavior.AllowGet);
        }

    }
}