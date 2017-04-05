using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalonDB.Web;
using SalonDB.Web.Models;
using System.Diagnostics;
using System.Web.Script.Serialization;

namespace SalonDB.Web.Controllers
{
    public class POSController : Controller
    {

        [AuthorizeRoles(eRoles.Admin, eRoles.POS)]
        public ActionResult Index(string appointmentID = "")
        {

            //if (MvcApplication.POSViewModel == null)
            //{
            this.LoadData(appointmentID);
            //}

            return View(MvcApplication.POSViewModel);
        }


        [HttpPost]
        public ActionResult Print(POSViewModel POSViewModelEnt)
        {
            POSViewModelEnt.ActionName = "Print";
            POSViewModelEnt.ActionMessage = "Printed...";

            TempData["POSViewModelEnt"] = POSViewModelEnt;

            return RedirectToAction("Index");
        }


        [AuthorizeRoles(eRoles.Admin, eRoles.POS)]
        [HttpPost]
        public ActionResult Save(string jsonData, string paymentType)
        {
            bool result = true;
            MvcApplication.POSViewModel.DataSaved = true;

            List<ServiceProductViewModel> ServiceProductViewModelCol;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            ServiceProductViewModelCol = jss.Deserialize<List<ServiceProductViewModel>>(jsonData);

            return Content(result.ToString());
            //return RedirectToAction("Index", "Home");
        }

        [AuthorizeRoles(eRoles.Admin, eRoles.POS)]
        [HttpPost]
        public ActionResult Cancel(bool cancel)
        {
            bool result = true;

            MvcApplication.POSViewModel = null;
            return RedirectToAction("Index", "Home");
        }


        //[HttpPost]
        //[AcceptActionNameParameter(Name = "action", Argument = "Print")]
        //public ActionResult Print(POSViewModel POSViewModelEnt)
        //{
        //    POSViewModelEnt.ActionName = "Print";
        //    POSViewModelEnt.ActionMessage = "Printed...";

        //    TempData["POSViewModelEnt"] = POSViewModelEnt;

        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //[AcceptActionNameParameter(Name = "action", Argument = "Save")]
        //public ActionResult Save(POSViewModel POSViewModelEnt)
        //{
        //    POSViewModelEnt.ActionName = "Save";
        //    POSViewModelEnt.ActionMessage = "Changes Saved...";
        //    POSViewModelEnt.DataSaved = true;

        //    TempData["POSViewModelEnt"] = POSViewModelEnt;

        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //[AcceptActionNameParameter(Name = "action", Argument = "Cancel")]
        //public ActionResult Cancel(POSViewModel POSViewModelEnt)
        //{

        //    POSViewModelEnt.ActionName = "Cancel";
        //    POSViewModelEnt.ActionMessage = "Changes Cancelled...";
        //    POSViewModelEnt.DataSaved = false;
        //    ResetPOSViewModelData();

        //    TempData["POSViewModelEnt"] = POSViewModelEnt;

        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //[AcceptActionNameParameter(Name = "action", Argument = "Delete")]
        //public ActionResult Delete(POSViewModel POSViewModelEnt)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        MvcApplication.POSViewModel.ActionName = "Delete";
        //        MvcApplication.POSViewModel.ActionMessage = "Deleted...";

        //        var RowCount = MvcApplication.POSViewModel.ServiceProductViewModelCol.Count;

        //        if (RowCount > 0)
        //        {
        //            MvcApplication.POSViewModel.ServiceProductViewModelCol.RemoveAt(RowCount - 1);
        //        }
        //    }
        //    return View("Index", MvcApplication.POSViewModel);
        //}

        //[HttpPost]
        //[AcceptActionNameParameter(Name = "action", Argument = "AddService")]
        //public ActionResult AddService(POSViewModel POSViewModelEnt)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        MvcApplication.POSViewModel.ActionName = "AddService";
        //        MvcApplication.POSViewModel.ActionMessage = "Service Added...";

        //        var RowCount = MvcApplication.POSViewModel.ServiceProductViewModelCol.Count + 1;
        //        MvcApplication.POSViewModel.ServiceProductViewModelCol.Add(new ServiceProductViewModel() { Name = $"Service {RowCount}", Price = RowCount, Quantity = 1, DiscountPercentage = 0 });
        //    }

        //    return View("Index", MvcApplication.POSViewModel);
        //}


        //[HttpPost]
        //[AcceptActionNameParameter(Name = "action", Argument = "AddProduct")]
        //public ActionResult AddProduct(POSViewModel POSViewModelEnt)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        MvcApplication.POSViewModel.ActionName = "AddProduct";
        //        MvcApplication.POSViewModel.ActionMessage = "Product Added...";

        //        var RowCount = MvcApplication.POSViewModel.ServiceProductViewModelCol.Count + 1;
        //        MvcApplication.POSViewModel.ServiceProductViewModelCol.Add(new ServiceProductViewModel() { Name = $"Product {RowCount}", Price = RowCount, Quantity = RowCount, DiscountPercentage = 0 });
        //    }

        //    return View("Index", MvcApplication.POSViewModel);
        //}

        private void LoadData(string appointmentID)
        {
            var DateFrom = DateTime.Now.Date;
            var DateTo = DateFrom.AddHours(23).AddMinutes(59).AddSeconds(59);
            var AppointmentCol = new List<AppointmentViewModel>();
            var CustomerCol = new List<CustomerViewModel>();
            var ServiceCol = new List<ServiceViewModel>();
            var ProductCol = new List<ProductViewModel>();
            var StaffCol = new List<StaffViewModel>();
            Guid? AppointmentID = Guid.Empty;

            SalonDB.Data.DBProviderEF.EFReloadAll();

            if (appointmentID != null || appointmentID != "")
            {
                AppointmentID = Guid.Parse(appointmentID);
            }

            if (AppointmentID == null || AppointmentID == Guid.Empty)
            {
                foreach (var item in SalonDB.Data.DBProviderEF.GetAppointmentsNotPaid(MvcApplication.CurrentCompany.CompanyID, DateFrom, DateTo, true))
                {
                    TimeSpan oTimeSpan = item.EndTime.Value.Subtract(item.StartTime.Value);
                    AppointmentCol.Add(new Models.AppointmentViewModel { AppointmentID = (Guid)item.AppointmentID, CustomerID = (Guid)item.CustomerID, Subject = item.Subject, AppointmentStart = item.StartTime.Value, AppointmentEnd = item.EndTime.Value, Duration = oTimeSpan.Minutes, CustomerName = $"{item.Customer.FirstName} {item.Customer.LastName}", StaffName = $"{item.Staff.FirstName} {item.Staff.LastName}" });
                    //AppointmentCol.Add(new Models.AppointmentViewModel { AppointmentID = (Guid)item.AppointmentID, CustomerID = (Guid)item.CustomerID, Subject = item.StartTime.Value.ToString("yyyy-MM-dd h:mm:ss tt") });
                }
            }
            else
            {
                foreach (var item in SalonDB.Data.DBProviderEF.GetAppointments(AppointmentID))
                {
                    TimeSpan oTimeSpan = item.EndTime.Value.Subtract(item.StartTime.Value);
                    AppointmentCol.Add(new Models.AppointmentViewModel { AppointmentID = (Guid)item.AppointmentID, CustomerID = (Guid)item.CustomerID, Subject = item.Subject, AppointmentStart = item.StartTime.Value, AppointmentEnd = item.EndTime.Value, Duration = oTimeSpan.Minutes, CustomerName = $"{item.Customer.FirstName} {item.Customer.LastName}", StaffName = $"{item.Staff.FirstName} {item.Staff.LastName}" });
                    //AppointmentCol.Add(new Models.AppointmentViewModel { AppointmentID = (Guid)item.AppointmentID, CustomerID = (Guid)item.CustomerID, Subject = item.StartTime.Value.ToString("yyyy-MM-dd h:mm:ss tt") });
                }

            }

            foreach (var item in SalonDB.Data.DBProviderEF.GetCustomers(MvcApplication.CurrentCompany.CompanyID))
            {
                CustomerCol.Add(new Models.CustomerViewModel { CustomerID = (Guid)item.CustomerID, Name = $"{item.FirstName} {item.LastName}" });
            }

            foreach (var item in SalonDB.Data.DBProviderEF.GetServices(MvcApplication.CurrentCompany.CompanyID))
            {
                ServiceCol.Add(new Models.ServiceViewModel { ServiceID = (Guid)item.ServiceID, Name = item.Name, Price = item.Price });
            }

            foreach (var item in SalonDB.Data.DBProviderEF.GetProducts(MvcApplication.CurrentCompany.CompanyID))
            {
                ProductCol.Add(new Models.ProductViewModel { ProductID = (Guid)item.ProductID, Name = item.Name, Price = item.Price });
            }

            foreach (var item in SalonDB.Data.DBProviderEF.GetStaffs(MvcApplication.CurrentCompany.CompanyID))
            {
                StaffCol.Add(new Models.StaffViewModel { StaffID = (Guid)item.StaffID, Name = $"{item.FirstName} {item.LastName}", FirstName = item.FirstName, LastName = item.LastName });
            }

            MvcApplication.POSViewModel = new Models.POSViewModel();
            MvcApplication.POSViewModel.StaffEnt = MvcApplication.CurrentStaff;
            MvcApplication.POSViewModel.AppointmentCol = AppointmentCol;
            MvcApplication.POSViewModel.CustomerCol = CustomerCol;
            MvcApplication.POSViewModel.ServiceCol = ServiceCol;
            MvcApplication.POSViewModel.ProductCol = ProductCol;
            MvcApplication.POSViewModel.StaffCol = StaffCol;
            MvcApplication.POSViewModel.ServiceProductViewModelCol = new List<ServiceProductViewModel>();

            //MvcApplication.POSViewModel.ServiceProductViewModelCol.Add(new ServiceProductViewModel(Guid.NewGuid(), "Service One", 10, 1, 0, true));
            //MvcApplication.POSViewModel.ServiceProductViewModelCol.Add(new ServiceProductViewModel(Guid.NewGuid(), "Service Two", 10, 1, 0, true));
            //MvcApplication.POSViewModel.ServiceProductViewModelCol.Add(new ServiceProductViewModel(Guid.NewGuid(), "Product One", 10, 1, 5, false));
            //MvcApplication.POSViewModel.ServiceProductViewModelCol.Add(new ServiceProductViewModel(Guid.NewGuid(), "Product Two", 20, 2, 0, false));
            //MvcApplication.POSViewModel.ServiceProductViewModelCol.Add(new ServiceProductViewModel(Guid.NewGuid(), "Product Three", 30, 3, 0, false));

            if (AppointmentID != null)
            {
                MvcApplication.POSViewModel.AppointmentID = (Guid)AppointmentID;
                MvcApplication.POSViewModel.StaffEnt = SalonDB.Data.DBProviderEF.GetStaffByAppointmentID((Guid)AppointmentID);
                var TransactionEnt = SalonDB.Data.DBProviderEF.GetTransactionByAppointmentID((Guid)AppointmentID);

                if (TransactionEnt != null)
                {
                    foreach (var item in SalonDB.Data.DBProviderEF.GetTransactionDetailServiceByTransactionID(TransactionEnt.TransactionID))
                    {
                        MvcApplication.POSViewModel.ServiceProductViewModelCol.Add(new ServiceProductViewModel((Guid)item.ServiceID, item.Name, item.UnitPrice, item.Quantity, item.DiscountPercent, true));
                    }
                }
            }

        }

        private void ResetPOSViewModelData()
        {
            MvcApplication.POSViewModel = new Models.POSViewModel();
            MvcApplication.POSViewModel.ServiceProductViewModelCol = new List<ServiceProductViewModel>();
        }

    }
}