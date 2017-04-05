using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalonDB.Web;
using System.Diagnostics;
using SalonDB.Web.Models;
using System.Drawing;

namespace SalonDB.Web.Controllers
{
    public class AppointmentController : Controller
    {

        SalonDB.Data.Model.DBModel _db = SalonDB.Data.DBProviderEF.GetDBContext();

        [AuthorizeRoles(eRoles.Admin, eRoles.FrontDesk)]
        public ActionResult Index()
        {
            var DataSource = new SchedulerViewModel();
            DataSource.CurrentDate = DateTime.Now;

            //For Testing
            SalonDB.Data.DBProviderEF.EFReloadAll();

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
            AppContextMenu.Add(new Syncfusion.JavaScript.Models.Appointment { Id = "open", Text = "Open Appointment" });
            AppContextMenu.Add(new Syncfusion.JavaScript.Models.Appointment { Id = "delete", Text = "Delete Appointment" });
            AppContextMenu.Add(new Syncfusion.JavaScript.Models.Appointment { Id = "checkout", Text = "CheckOut" });

            DataSource.GroupCol = Group;
            DataSource.AppContextMenu = AppContextMenu;

            return View(DataSource);
        }

        [AuthorizeRoles(eRoles.Admin, eRoles.FrontDesk)]
        public JsonResult GetResData()
        {
            List<ResourceFields> Resources = new List<ResourceFields>();
            foreach (var item in SalonDB.Data.DBProviderEF.GetStaffs(MvcApplication.CurrentCompany.CompanyID))
            {
                Resources.Add(new ResourceFields { Id = item.StaffID.ToString(), Text = $"{item.FirstName} {item.LastName}", Color = item.ResourceColor });
            }
            return Json(Resources, JsonRequestBehavior.AllowGet);
        }

        [AuthorizeRoles(eRoles.Admin, eRoles.FrontDesk)]
        public JsonResult GetData()
        {
            var DateFrom = DateTime.Now.Date;
            var DateTo = DateFrom.AddHours(23).AddMinutes(59).AddSeconds(59);
            var DataSource = new SchedulerViewModel();
            List<SchedulerEntity> AppointmentData = new List<SchedulerEntity>();
            DataSource.CurrentDate = DateTime.Now;

            SalonDB.Data.DBProviderEF.EFReloadAll();

            foreach (var item in SalonDB.Data.DBProviderEF.GetAppointmentsNotPaid(MvcApplication.CurrentCompany.CompanyID, DateFrom, DateTo, true))
            {
                TimeSpan oTimeSpan = item.EndTime.Value.Subtract(item.StartTime.Value);
                AppointmentData.Add(new Models.SchedulerEntity { Id = item.AppointmentID.ToString(), CustomerID = item.CustomerID.ToString(), StaffId = item.StaffID.ToString(), Subject = item.Subject, StartTime = item.StartTime.Value, EndTime = item.EndTime.Value, Description = item.Description, Duration = oTimeSpan.Minutes, CustomerName = $"{item.Customer.FirstName} {item.Customer.LastName}", StaffName = $"{item.Staff.FirstName} {item.Staff.LastName}", AllDay = false, Recurrence = false, RecurrenceRule = "" });
            }

            return Json(AppointmentData, JsonRequestBehavior.AllowGet);

        }

        [AuthorizeRoles(eRoles.Admin, eRoles.FrontDesk)]
        public JsonResult Batch(EditParams param)
        {
            if (param.action == "insert" || (param.action == "batch" && param.added != null))          // this block of code will execute while inserting the appointments
            {
                var value = param.action == "insert" ? param.value : param.added[0];
                DateTime startTime = Convert.ToDateTime(value.StartTime);
                DateTime endTime = Convert.ToDateTime(value.EndTime);
                var currentTimeZone = TimeZone.CurrentTimeZone;
            
                SalonDB.Data.Model.Appointment appoint = new SalonDB.Data.Model.Appointment()
                {
                    AppointmentID = Guid.NewGuid(),   
                    StartTime = startTime.ToUniversalTime(),
                    EndTime = endTime.ToUniversalTime(),
                    Subject = value.Subject,
                    //Location = value.Location,
                    Description = value.Description,
                    StaffID = Guid.Parse(value.StaffId),
                    //Priority = value.Priority,
                    //Recurrence = value.Recurrence,
                    //RecurrenceType = value.RecurrenceType,
                    //Reminder = value.Reminder,
                    //Categorize = value.Categorize,
                    AllDay = value.AllDay,
                    //RecurrenceEndDate = value.RecurrenceEndDate != null ? Convert.ToDateTime(value.RecurrenceEndDate).ToUniversalTime() : endTime.ToUniversalTime(),
                    //RecurrenceStartDate = value.RecurrenceStartDate != null ? Convert.ToDateTime(value.RecurrenceStartDate).ToUniversalTime() : startTime.ToUniversalTime(),
                    RecurrenceRule = value.RecurrenceRule
                };
                _db.SaveChanges();
            }
            else if (param.action == "remove")                                        // this block of code will execute while removing the appointment
            {
                var ID = Guid.Parse(param.key);
                SalonDB.Data.Model.Appointment app = _db.Appointments.Where(c => c.AppointmentID == ID).FirstOrDefault();

                if (app != null)
                {
                    _db.Appointments.Remove(app);
                }
                _db.SaveChanges();
            }
            else if ((param.action == "batch" && param.changed != null) || param.action == "update")   // this block of code will execute while updating the appointment
            {
                var value = param.action == "update" ? param.value : param.changed[0];
                var ID = Guid.Parse(value.Id);
                var filterData = _db.Appointments.Where(c => c.AppointmentID == ID);

                if (filterData.Count() > 0)
                {
                    DateTime startTime = Convert.ToDateTime(value.StartTime);
                    DateTime endTime = Convert.ToDateTime(value.EndTime);
                    SalonDB.Data.Model.Appointment appoint = _db.Appointments.Single(A => A.AppointmentID == ID);
                    appoint.StartTime = startTime.ToUniversalTime();
                    appoint.EndTime = endTime.ToUniversalTime();
                    appoint.Subject = value.Subject;
                    //appoint.Location = value.Location;
                    appoint.Description = value.Description;
                    appoint.StaffID = Guid.Parse(value.StaffId);
                    //appoint.Priority = Convert.ToByte(value.Priority);
                    appoint.Recurrence = Convert.ToByte(value.Recurrence);
                    //appoint.RecurrenceType = value.RecurrenceType;
                    //appoint.RecurrenceTypeCount = Convert.ToInt16(value.RecurrenceTypeCount);
                    //appoint.Reminder = value.Reminder;
                    //appoint.Categorize = value.Categorize;
                    appoint.AllDay = value.AllDay;
                    //appoint.RecurrenceEndDate = value.RecurrenceEndDate != null ? Convert.ToDateTime(value.RecurrenceEndDate).ToUniversalTime() : endTime.ToUniversalTime();
                    //appoint.RecurrenceStartDate = value.RecurrenceStartDate != null ? Convert.ToDateTime(value.RecurrenceStartDate).ToUniversalTime() : startTime.ToUniversalTime();
                    appoint.RecurrenceRule = value.RecurrenceRule;
                }
                _db.SaveChanges();
            }

            return GetData();
        }
    }
}