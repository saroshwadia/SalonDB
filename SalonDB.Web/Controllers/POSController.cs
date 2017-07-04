using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SalonDB.Web.Models;
using System.Web.Script.Serialization;
using SalonDB.Data.Persistence;
using SalonDB.Data;
using SalonDB.Data.Core.Domain;

namespace SalonDB.Web.Controllers
{
    public class POSController : Controller
    {

        UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
        LoginViewModel LoginInfo = new LoginViewModel();
        Staff CurrentStaff = null;
        POSViewModel POSViewModel = null;
        bool SaveInUTC = false;

        public POSController()
        {
            //LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);
        }

        [AuthorizeRoles(eRoles.Admin, eRoles.POS)]
        public ActionResult Index(string appointmentID = "", string controllerName = "", string transactionID = "")
        {
            var ID = appointmentID;
            var IsTransaction = false;
            unitOfWork.RollBack();

            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);

            if (LoginInfo.StaffID != null)
            {
                CurrentStaff = unitOfWork.Staffs.Get(LoginInfo.StaffID);
            }

            if (appointmentID == "")
            {
                appointmentID = null;
            }

            //if (!string.IsNullOrEmpty(controllerName))
            //{
            //    IsTransaction = controllerName.ToLower() != "Appointment".ToLower();
            //}

            if (!string.IsNullOrEmpty(transactionID))
            {
                IsTransaction = true;
                ID = transactionID;
            }

            this.LoadData(ID, IsTransaction);

            if (string.IsNullOrEmpty(controllerName))
            {
                controllerName = "Home";
            }

            POSViewModel.TargetController = controllerName;
            POSViewModel.TargetAction = "Index";

            return View(POSViewModel);
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
        public JsonResult Save(string jsonData, string paymentType, string appointmentID, string customerID, string staffID, decimal discountPercent, decimal taxPercent, decimal amount, decimal total, decimal tipAmount)
        {
            string result = string.Empty;
            Guid? AppointmentID = null;
            var CustomerID = Guid.Empty;
            var StaffID = Guid.Empty;
            var PaymentTypeEnt = new PaymentType();
            var TransactionDate = DateTime.Now;
            decimal Amount = 0;
            decimal DiscountPercent = 0;
            decimal TaxPercent = 0;
            decimal Total = 0;
            decimal TipAmount = 0;
            int ServiceSequence = 0;
            int ProductSequence = 0;
            bool IsTransactionNew = false;
            SalonDB.Data.ePaymentType oPaymentType;
            var RetVal = new object[3];
            var DateFrom = DateTime.Now.Date;
            var DateTo = DateFrom.AddHours(23).AddMinutes(59).AddSeconds(59);
            var LoadAllAppointments = false;

            try
            {
                LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);

                try
                {
                    oPaymentType = (SalonDB.Data.ePaymentType)System.Enum.Parse(typeof(SalonDB.Data.ePaymentType), paymentType, true);
                }
                catch (Exception)
                {
                    oPaymentType = Data.ePaymentType.NotPaid;
                }

                PaymentTypeEnt = unitOfWork.PaymentTypes.Find(c => c.Name == paymentType);

                SalonDB.Data.Core.Domain.Appointment AppointmentEnt = null;
                SalonDB.Data.Core.Domain.Transaction TransactionEnt = null;
                SalonDB.Data.Core.Domain.Staff StaffEnt = null;

                if (SaveInUTC)
                {
                    TransactionDate = TransactionDate.ToUniversalTime();
                }

                //MvcApplication.POSViewModel.DataSaved = true;

                List<ServiceProductViewModel> ServiceProductViewModelCol;
                JavaScriptSerializer jss = new JavaScriptSerializer();
                ServiceProductViewModelCol = jss.Deserialize<List<ServiceProductViewModel>>(jsonData);

                if (appointmentID != "")
                {
                    AppointmentID = Guid.Parse(appointmentID);
                    AppointmentEnt = unitOfWork.Appointments.Get((Guid)AppointmentID);
                    TransactionEnt = unitOfWork.Transactions.GetTransactionByAppointmentID((Guid)AppointmentID);
                    AppointmentEnt.Status = int.Parse(SalonDB.Data.CategorizeSettings.GetCheckedOutID());
                }

                CustomerID = Guid.Parse(customerID);
                DiscountPercent = discountPercent;
                TaxPercent = taxPercent;
                Amount = amount;
                Total = total;
                TipAmount = tipAmount;

                if (!string.IsNullOrEmpty(staffID) && staffID != Guid.Empty.ToString())
                {
                    StaffID = Guid.Parse(staffID);
                    StaffEnt = unitOfWork.Staffs.Get((Guid)StaffID);
                }

                if (TransactionEnt == null)
                {
                    TransactionEnt = new Data.Core.Domain.Transaction();
                    TransactionEnt.TransactionID = Guid.NewGuid();
                    IsTransactionNew = true;
                }
                else
                {
                    if (TransactionEnt.TransactionDetailServices.Count > 0)
                    {
                        var SCount = unitOfWork.Transactions.DeleteServices(TransactionEnt);
                        //unitOfWork.Commit();
                    }

                    if (TransactionEnt.TransactionDetailProducts.Count > 0)
                    {
                        var PCount = unitOfWork.Transactions.DeleteProducts(TransactionEnt);
                        //unitOfWork.Commit();
                    }
                }

                if (StaffEnt == null)
                {
                    TransactionEnt.CompanyID = LoginInfo.CompanyID;
                    TransactionEnt.StoreID = LoginInfo.StoreID;
                    //TransactionEnt.StaffID = StaffEnt.StaffID;
                }
                else
                {
                    TransactionEnt.CompanyID = StaffEnt.CompanyID;
                    TransactionEnt.StoreID = StaffEnt.StoreID;
                    TransactionEnt.StaffID = StaffEnt.StaffID;
                }

                TransactionEnt.CustomerID = CustomerID;
                TransactionEnt.TransactionDate = TransactionDate;
                TransactionEnt.Amount = 0;
                TransactionEnt.DiscountPercent = 0;
                TransactionEnt.TaxPercent = 0;
                TransactionEnt.Total = 0;
                TransactionEnt.TipAmount = 0;
                TransactionEnt.Status = SalonDB.Data.eTransactionStatus.Paid.ToString();
                TransactionEnt.PaymentType = oPaymentType.ToString();
                if (PaymentTypeEnt != null)
                {
                    TransactionEnt.PaymentTypeID = PaymentTypeEnt.PaymentTypeID;
                }

                foreach (var item in ServiceProductViewModelCol)
                {
                    if (item.IsService)
                    {
                        ServiceSequence++;
                        var NewEnt = new Data.Core.Domain.TransactionDetailService();

                        NewEnt.TransactionDetailServiceID = Guid.NewGuid();
                        NewEnt.TransactionID = TransactionEnt.TransactionID;
                        NewEnt.ServiceID = item.ID;
                        NewEnt.Name = item.Name;
                        NewEnt.Description = item.Name;
                        NewEnt.Quantity = item.Quantity;
                        NewEnt.UnitPrice = item.Price;
                        NewEnt.DiscountPercent = item.DiscountPercentage;
                        NewEnt.Duration = 0;
                        NewEnt.ShowOnline = false;
                        NewEnt.Sequence = ServiceSequence;

                        TransactionEnt.TransactionDetailServices.Add(NewEnt);
                    }
                    else
                    {
                        ProductSequence++;
                        var NewEnt = new Data.Core.Domain.TransactionDetailProduct();

                        NewEnt.TransactionDetailProductID = Guid.NewGuid();
                        NewEnt.TransactionID = TransactionEnt.TransactionID;
                        NewEnt.ProductID = item.ID;
                        NewEnt.Name = item.Name;
                        NewEnt.Description = item.Name;
                        NewEnt.Quantity = item.Quantity;
                        NewEnt.UnitPrice = item.Price;
                        NewEnt.DiscountPercent = item.DiscountPercentage;
                        NewEnt.WholesalePrice = item.DiscountPercentage;
                        NewEnt.Commission = 0;
                        NewEnt.Sequence = ProductSequence;

                        TransactionEnt.TransactionDetailProducts.Add(NewEnt);
                    }
                }

                TransactionEnt.Amount = Amount;
                TransactionEnt.DiscountPercent = DiscountPercent;
                TransactionEnt.TaxPercent = TaxPercent;
                TransactionEnt.Total = Total;
                TransactionEnt.TipAmount = TipAmount;

                if (IsTransactionNew)
                {
                    unitOfWork.Transactions.Add(TransactionEnt);
                }

                unitOfWork.Commit();

                result = TransactionEnt.TransactionID.ToString();

                //return Content(result.ToString());
                //return RedirectToAction("Index", "Home");

                DateFrom = DateTime.Now.Date;
                DateTo = DateFrom.AddHours(23).AddMinutes(59).AddSeconds(59);

                RetVal[0] = result;
                RetVal[1] = GetAppointmentsNotPaid(LoginInfo.StoreID, DateFrom, DateTo, LoadAllAppointments);
                RetVal[2] = null;

            }
            catch (Exception ex)
            {
                RetVal[0] = null;
                RetVal[1] = GetAppointmentsNotPaid(LoginInfo.StoreID, DateFrom, DateTo, LoadAllAppointments);
                RetVal[2] = ex.Message;
            }

            return Json(RetVal, JsonRequestBehavior.AllowGet);

        }

        [AuthorizeRoles(eRoles.Admin, eRoles.POS)]
        [HttpPost]
        public ActionResult Cancel(bool cancel)
        {
            //bool result = true;

            POSViewModel = null;
            return RedirectToAction("Index", "Home");
        }
                       
        private void LoadData(string ID, bool isTransaction = false)
        {
            var DateFrom = DateTime.Now.Date;
            var DateTo = DateFrom.AddHours(23).AddMinutes(59).AddSeconds(59);
            var AppointmentCol = new List<AppointmentViewModel>();
            var TransactionCol = new List<TransactionViewModel>();
            var CustomerCol = new List<CustomerViewModel>();
            var ServiceCol = new List<ServiceViewModel>();
            var ProductCol = new List<ProductViewModel>();
            var StaffCol = new List<StaffViewModel>();
            var PaymentTypeCol = new List<PaymentTypeViewModel>();
            var LoadAllAppointments = false;
            Guid? EntityID = Guid.Empty;

            POSViewModel = new Models.POSViewModel();

            //SalonDB.Data.DBProviderEF.EFReloadAll();
            if (ID == null || ID == "")
            {
                EntityID = null;
            }

            if (ID != null && ID != "") 
            {
                var TempID = ID.Replace("\"", "");
                EntityID = Guid.Parse(TempID);
            }

            if (EntityID == null || EntityID == Guid.Empty)
            {
                foreach (var item in unitOfWork.Appointments.GetAppointmentsNotPaid(LoginInfo.StoreID, DateFrom, DateTo, LoadAllAppointments))
                {
                    TimeSpan oTimeSpan = item.EndTime.Value.Subtract(item.StartTime.Value);
                    var CustomerEnt = unitOfWork.Customers.Get(item.CustomerID);
                    var StaffEnt = unitOfWork.Staffs.Get(item.StaffID);
                    AppointmentCol.Add(new Models.AppointmentViewModel { AppointmentID = (Guid)item.AppointmentID, StaffID = (Guid)item.StaffID, CustomerID = (Guid)item.CustomerID, Subject = $"{CustomerEnt.FirstName} {CustomerEnt.LastName} - {item.StartTime.Value.ToString("hh:mm tt")}", AppointmentStart = item.StartTime.Value, AppointmentEnd = item.EndTime.Value, Duration = oTimeSpan.Minutes, CustomerName = $"{CustomerEnt.FirstName} {CustomerEnt.LastName}", StaffName = $"{StaffEnt.FirstName} {StaffEnt.LastName}" });
                }
            }
            else
            {
                if (isTransaction)
                {
                    foreach (var item in unitOfWork.Transactions.FindAll(c => c.TransactionID == EntityID))
                    {
                        var CustomerEnt = unitOfWork.Customers.Get((Guid)item.CustomerID);
                        var StaffEnt = unitOfWork.Staffs.Get((Guid)item.StaffID);
                        POSViewModel.CustomerID = (Guid)item.CustomerID;
                        POSViewModel.StaffID = (Guid)item.StaffID;
                        TransactionCol.Add(new Models.TransactionViewModel { TransactionID = (Guid)item.TransactionID, StaffID = (Guid)item.StaffID, CustomerID = (Guid)item.CustomerID, CustomerName = $"{CustomerEnt.FirstName} {CustomerEnt.LastName}", StaffName = $"{StaffEnt.FirstName} {StaffEnt.LastName}" });
                    }
                }
                else
                {
                    foreach (var item in unitOfWork.Appointments.FindAll(c => c.AppointmentID == EntityID))
                    {
                        TimeSpan oTimeSpan = item.EndTime.Value.Subtract(item.StartTime.Value);
                        var CustomerEnt = unitOfWork.Customers.Get((Guid)item.CustomerID);
                        var StaffEnt = unitOfWork.Staffs.Get((Guid)item.StaffID);
                        POSViewModel.CustomerID = (Guid)item.CustomerID;
                        POSViewModel.StaffID = (Guid)item.StaffID;
                        //AppointmentCol.Add(new Models.AppointmentViewModel { AppointmentID = (Guid)item.AppointmentID, StaffID = (Guid)item.StaffID, CustomerID = (Guid)item.CustomerID, Subject = item.Subject, AppointmentStart = item.StartTime.Value, AppointmentEnd = item.EndTime.Value, Duration = oTimeSpan.Minutes, CustomerName = $"", StaffName = $"" });
                        AppointmentCol.Add(new Models.AppointmentViewModel { AppointmentID = (Guid)item.AppointmentID, StaffID = (Guid)item.StaffID, CustomerID = (Guid)item.CustomerID, Subject = $"{CustomerEnt.FirstName} {CustomerEnt.LastName} - {item.StartTime.Value.ToString("hh:mm tt")}", AppointmentStart = item.StartTime.Value, AppointmentEnd = item.EndTime.Value, Duration = oTimeSpan.Minutes, CustomerName = $"{CustomerEnt.FirstName} {CustomerEnt.LastName}", StaffName = $"{StaffEnt.FirstName} {StaffEnt.LastName}" });
                    }
                }
            }

            foreach (var item in unitOfWork.Customers.FindAll(c => c.CompanyID == LoginInfo.CompanyID).OrderBy(c => c.FirstName).ThenBy(c => c.LastName))
            {
                CustomerCol.Add(new Models.CustomerViewModel { CustomerID = (Guid)item.CustomerID, Name = $"{item.FirstName} {item.LastName}" });
            }

            foreach (var item in unitOfWork.Services.FindAll(c => c.CompanyID == LoginInfo.CompanyID).OrderBy(c => c.Name))
            {
                ServiceCol.Add(new Models.ServiceViewModel { ServiceID = (Guid)item.ServiceID, Name = item.Name, Price = item.Price });
            }

            foreach (var item in unitOfWork.Products.FindAll(c => c.CompanyID == LoginInfo.CompanyID).OrderBy(c => c.Name))
            {
                ProductCol.Add(new Models.ProductViewModel { ProductID = (Guid)item.ProductID, Name = item.Name, Price = item.Price });
            }

            // Add an extra blank row as the user may not select a Staff.
            var FName = " ";
            var LName = " ";
            StaffCol.Add(new Models.StaffViewModel { StaffID = Guid.Empty, Name = $"{FName} {LName}", FirstName = FName, LastName = LName });

            foreach (var item in unitOfWork.Staffs.FindAll(c => c.StoreID == LoginInfo.StoreID).OrderBy(c => c.FirstName).ThenBy(c => c.LastName))
            {
                StaffCol.Add(new Models.StaffViewModel { StaffID = (Guid)item.StaffID, Name = $"{item.FirstName} {item.LastName}", FirstName = item.FirstName, LastName = item.LastName });
            }

            foreach (var item in unitOfWork.PaymentTypes.FindAll(c => c.CompanyID == LoginInfo.CompanyID).OrderBy(c => c.Sequence))
            {
                PaymentTypeCol.Add(new Models.PaymentTypeViewModel { PaymentTypeID = (Guid)item.PaymentTypeID, Name = $"{item.Name}", Sequence = item.Sequence, Other = item.Other });
            }

            var WalkInCustomerEnt = unitOfWork.Customers.GetCustomerWalkIn(LoginInfo.CompanyID);

            POSViewModel.WalkInCustomerID = WalkInCustomerEnt.CustomerID;
            POSViewModel.StaffEnt = CurrentStaff;
            POSViewModel.StaffID = CurrentStaff.StaffID;
            POSViewModel.AppointmentCol = AppointmentCol;
            POSViewModel.TransactionCol = TransactionCol;
            POSViewModel.CustomerCol = CustomerCol;
            POSViewModel.ServiceCol = ServiceCol;
            POSViewModel.ProductCol = ProductCol;
            POSViewModel.StaffCol = StaffCol;
            POSViewModel.ServiceProductViewModelCol = new List<ServiceProductViewModel>();
            POSViewModel.PaymentTypeCol = PaymentTypeCol;

            //MvcApplication.POSViewModel.ServiceProductViewModelCol.Add(new ServiceProductViewModel(Guid.NewGuid(), "Service One", 10, 1, 0, true));
            //MvcApplication.POSViewModel.ServiceProductViewModelCol.Add(new ServiceProductViewModel(Guid.NewGuid(), "Service Two", 10, 1, 0, true));
            //MvcApplication.POSViewModel.ServiceProductViewModelCol.Add(new ServiceProductViewModel(Guid.NewGuid(), "Product One", 10, 1, 5, false));
            //MvcApplication.POSViewModel.ServiceProductViewModelCol.Add(new ServiceProductViewModel(Guid.NewGuid(), "Product Two", 20, 2, 0, false));
            //MvcApplication.POSViewModel.ServiceProductViewModelCol.Add(new ServiceProductViewModel(Guid.NewGuid(), "Product Three", 30, 3, 0, false));

            if (EntityID == null || EntityID == Guid.Empty)
            {
                POSViewModel.StaffEnt = null;
                POSViewModel.StaffID = null;
            }

            if (EntityID != null)
            {
                POSViewModel.StaffEnt = unitOfWork.Staffs.GetStaffByAppointmentID((Guid)EntityID);
                if (isTransaction)
                {
                    POSViewModel.TransactionID = (Guid)EntityID;
                    POSViewModel.DataSaved = true;
                    POSViewModel.FromInvoice = true;
                    POSViewModel.ServiceProductViewModelCol = GetServiceProductViewModelColByTransactionID((Guid)EntityID);
                }
                else
                {
                    POSViewModel.AppointmentID = (Guid)EntityID;
                    POSViewModel.ServiceProductViewModelCol = GetServiceProductViewModelColByAppointmentID((Guid)EntityID);
                }
                //MvcApplication.POSViewModel.StaffEnt = SalonDB.Data.DBProviderEF.GetStaffByAppointmentID((Guid)AppointmentID);
            }

        }

        private void ResetPOSViewModelData()
        {
            POSViewModel = new Models.POSViewModel();
            POSViewModel.ServiceProductViewModelCol = new List<ServiceProductViewModel>();
        }

        //private void DeleteObjectAndChildren(Object parent)
        //{
        //    // Deletes One-to-Many Children
        //    if (parent.Things != null && parent.Things.Count > 0)
        //    {
        //        this.db.Things.RemoveRange(parent.Things);
        //    }

        //    // Deletes Self Referenced Children
        //    if (parent.Children != null && parent.Children.Count > 0)
        //    {
        //        foreach (var child in parent.Children)
        //        {
        //            this.DeleteObjectAndChildren(child);
        //        }

        //        this.db.Objects.RemoveRange(parent.Children);
        //    }
        //}


        private List<ServiceProductViewModel> GetServiceProductViewModelColByAppointmentID(Guid appointmentID)
        {
            var ReturnValue = new List<ServiceProductViewModel>();
            var TransactionEnt = unitOfWork.Transactions.GetTransactionByAppointmentID((Guid)appointmentID);

            if (TransactionEnt != null)
            {
                foreach (var item in unitOfWork.Transactions.GetTransactionDetailServiceByTransactionID(TransactionEnt.TransactionID))
                {
                    ReturnValue.Add(new ServiceProductViewModel((Guid)item.ServiceID, item.Name, item.UnitPrice, item.Quantity, item.DiscountPercent, true, item.Sequence));
                }
            }

            return ReturnValue;
        }

        private List<ServiceProductViewModel> GetServiceProductViewModelColByTransactionID(Guid transactionID)
        {
            var ReturnValue = new List<ServiceProductViewModel>();
            var TransactionEnt = unitOfWork.Transactions.Get((Guid)transactionID);

            if (TransactionEnt != null)
            {
                foreach (var item in unitOfWork.Transactions.GetTransactionDetailServiceByTransactionID(TransactionEnt.TransactionID))
                {
                    ReturnValue.Add(new ServiceProductViewModel((Guid)item.ServiceID, item.Name, item.UnitPrice, item.Quantity, item.DiscountPercent, true, item.Sequence));
                }
                foreach (var item in unitOfWork.Transactions.GetTransactionDetailProductByTransactionID(TransactionEnt.TransactionID))
                {
                    ReturnValue.Add(new ServiceProductViewModel((Guid)item.ProductID, item.Name, item.UnitPrice, item.Quantity, item.DiscountPercent, false, item.Sequence));
                }
                
                if (ReturnValue.Count > 0)
                {
                    ReturnValue = ReturnValue.OrderBy(c => c.Sequence).ToList();
                }
            }

            return ReturnValue;
        }

        private List<AppointmentViewModel> GetAppointmentsNotPaid(Guid storeID, DateTime DateFrom, DateTime DateTo, bool LoadAllAppointments)
        {
            var ReturnValue = new List<AppointmentViewModel>();

            foreach (var item in unitOfWork.Appointments.GetAppointmentsNotPaid(storeID, DateFrom, DateTo, LoadAllAppointments))
            {
                TimeSpan oTimeSpan = item.EndTime.Value.Subtract(item.StartTime.Value);
                var CustomerEnt = unitOfWork.Customers.Get(item.CustomerID);
                var StaffEnt = unitOfWork.Staffs.Get(item.StaffID);
                ReturnValue.Add(new Models.AppointmentViewModel { AppointmentID = (Guid)item.AppointmentID, CustomerID = (Guid)item.CustomerID, Subject = item.Subject, AppointmentStart = item.StartTime.Value, AppointmentEnd = item.EndTime.Value, Duration = oTimeSpan.Minutes, CustomerName = $"{CustomerEnt.FirstName} {CustomerEnt.LastName}", StaffName = $"{StaffEnt.FirstName} {StaffEnt.LastName}" });
            }

            return ReturnValue;
        }

        [HttpPost]
        public ContentResult GetServicesByAppointmentID1(string appointmentID)
        {
            string ReturnValue = string.Empty;

            return Content(ReturnValue, "text/plain", System.Text.Encoding.UTF8);
        }

        [HttpPost]
        public JsonResult GetServicesByAppointmentID(string appointmentID)
        {
            object[] ReturnValue = new object[3];
            var ID = Guid.Parse(appointmentID);
            var AppointmentEnt = unitOfWork.Appointments.Get(ID);
            var Result = GetServiceProductViewModelColByAppointmentID(ID);

            if (AppointmentEnt != null && Result != null && Result.Count > 0)
            {
                POSViewModel = new Models.POSViewModel();
                POSViewModel.StaffID = AppointmentEnt.StaffID;
                POSViewModel.CustomerID = AppointmentEnt.CustomerID;

                ReturnValue[0] = POSViewModel.CustomerID.ToString();
                ReturnValue[1] = POSViewModel.StaffID.ToString();
                ReturnValue[2] = Result;

                //ReturnValue = new JavaScriptSerializer().Serialize(POSViewModel);
            }

            return Json(ReturnValue, JsonRequestBehavior.AllowGet);
        }

        private List<AppointmentViewModel> GetAppointments(Guid? AppointmentID, Guid storeID, DateTime DateFrom, DateTime DateTo, bool LoadAllAppointments)
        {
            var ReturnValue = new List<AppointmentViewModel>();
            var Result = new List<Data.Core.Domain.Appointment>();

            if (AppointmentID == null || AppointmentID == Guid.Empty)
            {
                Result = unitOfWork.Appointments.GetAppointmentsNotPaid(storeID, DateFrom, DateTo, LoadAllAppointments).ToList();
            }
            else
            {
                Result = unitOfWork.Appointments.FindAll(c => c.AppointmentID == AppointmentID).ToList();
            }

            foreach (var item in Result)
            {
                TimeSpan oTimeSpan = item.EndTime.Value.Subtract(item.StartTime.Value);
                var CustomerEnt = unitOfWork.Customers.Get(item.CustomerID);
                var StaffEnt = unitOfWork.Staffs.Get(item.StaffID);
                POSViewModel.CustomerID = item.CustomerID;
                POSViewModel.StaffID = item.StaffID;
                ReturnValue.Add(new Models.AppointmentViewModel { AppointmentID = (Guid)item.AppointmentID, StaffID = (Guid)item.StaffID, CustomerID = (Guid)item.CustomerID, Subject = $"{CustomerEnt.FirstName} {CustomerEnt.LastName} - {item.StartTime.Value.ToString("hh:mm tt")}", AppointmentStart = item.StartTime.Value, AppointmentEnd = item.EndTime.Value, Duration = oTimeSpan.Minutes, CustomerName = $"{CustomerEnt.FirstName} {CustomerEnt.LastName}", StaffName = $"{StaffEnt.FirstName} {StaffEnt.LastName}" });
            }

            return ReturnValue;
        }

        [AuthorizeRoles(eRoles.Admin, eRoles.POS)]
        public JsonResult AddCustomer(string customerName, string customerPhone, string customerEmail)
        {
            object[] ReturnValue = new object[2];

            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);
            ReturnValue = MvcApplication.AddCustomer(customerName, customerPhone, customerEmail, LoginInfo, unitOfWork);

            return Json(ReturnValue, JsonRequestBehavior.AllowGet);
        }

    }
}