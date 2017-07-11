using SalonDB.Data.Core;
using SalonDB.Data.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonDB.Web.Models
{

    public static class AppointmentRepositoryModel
    {
        private static bool SaveInUTC = false;
        private static string TimeZoneUTC = "UTC +00:00";

        public static SchedulerEntity Insert(SchedulerEntity app, LoginViewModel LoginInfo, string _CurrentTimeZone, bool applyTimeOffset)
        {
            var ReturnValue = new SchedulerEntity();
            decimal TotalAmount = 0;
            decimal TotalTaxPercent = 5;
            decimal TotalTaxAmount = 0;
            decimal TotalDiscountPercent = 0;
            decimal TotalDiscountAmount = 0;
            decimal GrandTotal = 0;
            int DecimalPlaces = 2;
            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            DateTime startTime = Convert.ToDateTime(app.StartTime);
            DateTime endTime = Convert.ToDateTime(app.EndTime);
            var UTCoffset = SalonDB.Data.DBProvider.GetUTCOffset();
            var currentTimeZone = TimeZone.CurrentTimeZone;
            var TransactionDate = DateTime.Now;

            if (SaveInUTC)
            {
                startTime = startTime.ToUniversalTime();
                endTime = endTime.ToUniversalTime();
                TransactionDate = endTime;
            }

            if (applyTimeOffset)
            {
                startTime = startTime.AddMinutes(UTCoffset.TotalMinutes);
                endTime = endTime.AddMinutes(UTCoffset.TotalMinutes);
                TransactionDate = endTime;
            }

            if (app.Subject == null)
            {
                app.Subject = $"New Appointment: {startTime} - {endTime}";
            }

            if (app.Categorize == null)
            {
                app.Categorize = SalonDB.Data.CategorizeSettings.GetScheduledID();
            }

            var NewAppointmentEnt = new SalonDB.Data.Core.Domain.Appointment()
            {
                AppointmentID = Guid.NewGuid(),
                CompanyID = LoginInfo.CompanyID,
                StoreID = (Guid)LoginInfo.StoreID,
                StaffID = Guid.Parse(app.StaffID),
                CustomerID = Guid.Parse(app.CustomerID),
                StartTime = startTime,
                EndTime = endTime,
                StartTimeZone = TimeZoneUTC, // _CurrentTimeZone,
                EndTimeZone = TimeZoneUTC, //_CurrentTimeZone,
                Subject = app.Subject,
                //Location = app.Location,
                Description = app.Description,
                //Priority = app.Priority,
                //Recurrence = app.Recurrence,
                //RecurrenceType = app.RecurrenceType,
                //Reminder = app.Reminder,
                //Categorize = app.Categorize,
                AllDay = app.AllDay,
                //RecurrenceEndDate = app.RecurrenceEndDate != null ? Convert.ToDateTime(app.RecurrenceEndDate).ToUniversalTime() : endTime.ToUniversalTime(),
                //RecurrenceStartDate = app.RecurrenceStartDate != null ? Convert.ToDateTime(app.RecurrenceStartDate).ToUniversalTime() : startTime.ToUniversalTime(),
                RecurrenceRule = app.RecurrenceRule,
                Status = int.Parse(app.Status)
            };

            NewAppointmentEnt.Subject = SalonDB.Data.DBProvider.FormatAppointmentSubject(NewAppointmentEnt, unitOfWork);
            NewAppointmentEnt.Description = SalonDB.Data.DBProvider.FormatAppointmentDescription(NewAppointmentEnt, unitOfWork);

            //Create a matching row in the Transaction table
            var NewTransactionEnt = new SalonDB.Data.Core.Domain.Transaction()
            {
                TransactionID = Guid.NewGuid(),
                AppointmentID = NewAppointmentEnt.AppointmentID,
                CompanyID = NewAppointmentEnt.CompanyID,
                StoreID = NewAppointmentEnt.StoreID,
                StaffID = NewAppointmentEnt.StaffID,
                CustomerID = NewAppointmentEnt.CustomerID,
                TransactionDate = TransactionDate,
                Amount = 0,
                DiscountPercent = 0,
                TaxPercent = 0,
                Total = 0,
                Status = SalonDB.Data.eTransactionStatus.Appointment.ToString(),
                PaymentType = SalonDB.Data.ePaymentType.NotPaid.ToString()
            };

            if (!string.IsNullOrEmpty(app.SelectedServices))
            {
                var ServiceList = app.SelectedServices.Split(',').ToList();
                var Sequence = 1;

                foreach (var item in ServiceList)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        var ServiceID = Guid.Parse(item);
                        var ServiceEnt = unitOfWork.Services.Get(ServiceID);

                        var NewTransactionDetailServiceEnt = new SalonDB.Data.Core.Domain.TransactionDetailService()
                        {
                            TransactionDetailServiceID = Guid.NewGuid(),
                            TransactionID = NewTransactionEnt.TransactionID,
                            ServiceID = ServiceEnt.ServiceID,
                            Name = ServiceEnt.Name,
                            Description = ServiceEnt.Description,
                            Quantity = 1,
                            UnitPrice = ServiceEnt.Price,
                            DiscountPercent = 0,
                            Duration = 0,
                            ShowOnline = true,
                            Sequence = Sequence++
                        };

                        TotalAmount = TotalAmount + SalonDB.Data.DBProvider.RecalTotal(NewTransactionDetailServiceEnt.UnitPrice, NewTransactionDetailServiceEnt.Quantity, NewTransactionDetailServiceEnt.DiscountPercent);

                        NewTransactionEnt.TransactionDetailServices.Add(NewTransactionDetailServiceEnt);
                    }
                }
            }

            // Refresh Summary columns
            TotalDiscountPercent = 0;
            TotalDiscountAmount = Math.Round((TotalDiscountPercent / 100) * TotalAmount, DecimalPlaces);
            TotalTaxAmount = Math.Round((TotalTaxPercent / 100) * (TotalAmount - TotalDiscountAmount), DecimalPlaces);
            GrandTotal = Math.Round((TotalAmount - TotalDiscountAmount) + TotalTaxAmount, DecimalPlaces);

            NewTransactionEnt.Amount = TotalAmount;
            NewTransactionEnt.DiscountPercent = TotalDiscountPercent;
            NewTransactionEnt.TaxPercent = TotalTaxPercent;
            NewTransactionEnt.Total = GrandTotal;

            unitOfWork.Appointments.Add(NewAppointmentEnt);
            unitOfWork.Transactions.Add(NewTransactionEnt);

            try
            {
                unitOfWork.Commit();
                ReturnValue = app;
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                ReturnValue = null;
                var EM = ex.Message;
                //throw new Exception(ex.Message);
            }

            return ReturnValue;
        }

        public static SchedulerEntity Remove(Guid appId)
        {
            var ReturnValue = new SchedulerEntity();
            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            var AppointmentEnt = unitOfWork.Appointments.Get(appId);
            var TransactionEnt = unitOfWork.Transactions.GetTransactionByAppointmentID(AppointmentEnt.AppointmentID);
            var IsPaid = false;

            DateTime startTime = Convert.ToDateTime(AppointmentEnt.StartTime);
            DateTime endTime = Convert.ToDateTime(AppointmentEnt.EndTime);

            if (AppointmentEnt != null)
            {
                if (TransactionEnt != null)
                {
                    IsPaid = IsAppointmentPaid(TransactionEnt);
                }
                if (!IsPaid)
                {
                    if (TransactionEnt != null)
                    {
                        unitOfWork.Transactions.DeleteDetails(TransactionEnt);
                        unitOfWork.Transactions.Remove(TransactionEnt);
                    }
                    unitOfWork.Appointments.Remove(AppointmentEnt);

                    try
                    {
                        unitOfWork.Commit();
                    }
                    catch (Exception ex)
                    {
                        unitOfWork.RollBack();
                        ReturnValue = null;
                        var EM = ex.Message;
                        //throw new Exception(ex.Message);
                    }
                }
            }

            return ReturnValue;
        }

        public static SchedulerEntity Update(SchedulerEntity app, LoginViewModel LoginInfo, string _CurrentTimeZone, bool applyTimeOffset)
        {
            var ReturnValue = new SchedulerEntity();
            ReturnValue = app;

            decimal TotalAmount = 0;
            decimal TotalTaxPercent = 5;
            decimal TotalTaxAmount = 0;
            decimal TotalDiscountPercent = 0;
            decimal TotalDiscountAmount = 0;
            decimal GrandTotal = 0;
            int DecimalPlaces = 2;
            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            DateTime startTime = Convert.ToDateTime(app.StartTime);
            DateTime endTime = Convert.ToDateTime(app.EndTime);
            DateTime TransactionDate = endTime;
            var UTCoffset = SalonDB.Data.DBProvider.GetUTCOffset();

            var ID = Guid.Parse(app.Id);
            //var filterData = unitOfWork.Appointments.FindAll(c => c.AppointmentID == ID);
            var AppointmentEnt = unitOfWork.Appointments.Get(ID);
            var TransactionEnt = unitOfWork.Transactions.GetTransactionByAppointmentID(AppointmentEnt.AppointmentID);
            var IsPaid = false;

            if (AppointmentEnt != null) //(filterData.Count() > 0)
            {
                if (TransactionEnt != null)
                {
                    IsPaid = IsAppointmentPaid(TransactionEnt);
                }
                if (!IsPaid)
                {
                    if (TransactionEnt != null)
                    {

                        startTime = Convert.ToDateTime(app.StartTime);
                        endTime = Convert.ToDateTime(app.EndTime);

                        if (SaveInUTC)
                        {
                            startTime = startTime.ToUniversalTime();
                            endTime = endTime.ToUniversalTime();
                        }

                        if (applyTimeOffset)
                        {
                            startTime = startTime.AddMinutes(UTCoffset.TotalMinutes);
                            endTime = endTime.AddMinutes(UTCoffset.TotalMinutes);
                            TransactionDate = endTime;
                        }

                        unitOfWork.Transactions.DeleteDetails(TransactionEnt);

                        if (!string.IsNullOrEmpty(app.SelectedServices))
                        {
                            var ServiceList = app.SelectedServices.Split(',').ToList();
                            var Sequence = 1;

                            foreach (var item in ServiceList)
                            {
                                if (!string.IsNullOrEmpty(item))
                                {
                                    var ServiceID = Guid.Parse(item);
                                    var ServiceEnt = unitOfWork.Services.Get(ServiceID);

                                    var NewTransactionDetailServiceEnt = new SalonDB.Data.Core.Domain.TransactionDetailService()
                                    {
                                        TransactionDetailServiceID = Guid.NewGuid(),
                                        TransactionID = TransactionEnt.TransactionID,
                                        ServiceID = ServiceEnt.ServiceID,
                                        Name = ServiceEnt.Name,
                                        Description = ServiceEnt.Description,
                                        Quantity = 1,
                                        UnitPrice = ServiceEnt.Price,
                                        DiscountPercent = 0,
                                        Duration = 0,
                                        ShowOnline = true,
                                        Sequence = Sequence++
                                    };

                                    TotalAmount = TotalAmount + SalonDB.Data.DBProvider.RecalTotal(NewTransactionDetailServiceEnt.UnitPrice, NewTransactionDetailServiceEnt.Quantity, NewTransactionDetailServiceEnt.DiscountPercent);

                                    TransactionEnt.TransactionDetailServices.Add(NewTransactionDetailServiceEnt);
                                }
                            }
                        }

                        // Refresh Summary columns
                        TotalDiscountPercent = TransactionEnt.DiscountPercent;
                        TotalDiscountAmount = Math.Round((TotalDiscountPercent / 100) * TotalAmount, DecimalPlaces);
                        TotalTaxAmount = Math.Round((TotalTaxPercent / 100) * (TotalAmount - TotalDiscountAmount), DecimalPlaces);
                        GrandTotal = Math.Round((TotalAmount - TotalDiscountAmount) + TotalTaxAmount, DecimalPlaces);

                        TransactionEnt.Amount = TotalAmount;
                        TransactionEnt.DiscountPercent = TotalDiscountPercent;
                        TransactionEnt.TaxPercent = TotalTaxPercent;
                        TransactionEnt.Total = GrandTotal;
                        TransactionEnt.TransactionDate = TransactionDate;

                    }

                    AppointmentEnt.StartTime = startTime;
                    AppointmentEnt.EndTime = endTime;
                    AppointmentEnt.StartTimeZone = TimeZoneUTC; //_CurrentTimeZone;
                    AppointmentEnt.EndTimeZone = TimeZoneUTC; //_CurrentTimeZone;
                    AppointmentEnt.Subject = app.Subject;
                    //appoint.Location = value.Location;
                    AppointmentEnt.Description = app.Description;
                    AppointmentEnt.StaffID = Guid.Parse(app.StaffID);
                    AppointmentEnt.CustomerID = Guid.Parse(app.CustomerID);
                    //appoint.Priority = Convert.ToByte(value.Priority);
                    AppointmentEnt.Recurrence = Convert.ToByte(app.Recurrence);
                    //appoint.RecurrenceType = value.RecurrenceType;
                    //appoint.RecurrenceTypeCount = Convert.ToInt16(value.RecurrenceTypeCount);
                    //appoint.Reminder = value.Reminder;
                    //appoint.Categorize = value.Categorize;
                    AppointmentEnt.AllDay = app.AllDay;
                    //appoint.RecurrenceEndDate = value.RecurrenceEndDate != null ? Convert.ToDateTime(value.RecurrenceEndDate).ToUniversalTime() : endTime.ToUniversalTime();
                    //appoint.RecurrenceStartDate = value.RecurrenceStartDate != null ? Convert.ToDateTime(value.RecurrenceStartDate).ToUniversalTime() : startTime.ToUniversalTime();
                    AppointmentEnt.RecurrenceRule = app.RecurrenceRule;
                    AppointmentEnt.Status = int.Parse(app.Categorize);
                    AppointmentEnt.Subject = SalonDB.Data.DBProvider.FormatAppointmentSubject(AppointmentEnt, unitOfWork);
                    AppointmentEnt.Description = SalonDB.Data.DBProvider.FormatAppointmentDescription(AppointmentEnt, unitOfWork);

                    try
                    {
                        unitOfWork.Commit();
                    }
                    catch (Exception ex)
                    {
                        unitOfWork.RollBack();
                        ReturnValue = null;
                        var EM = ex.Message;
                        //throw new Exception(ex.Message);
                    }

                }

            }

            return ReturnValue;

        }

        public static List<SchedulerEntity> FilterAppointment(DateTime CurrentDate, String CurrentAction, String CurrentView, Guid storeID)
        {

            var ReturnValue = new List<SchedulerEntity>();
            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            DateTime CurrDate = Convert.ToDateTime(CurrentDate.Date);
            DateTime DateFrom = FirstWeekDate(CurrDate.Date);
            DateTime DateTo = DateFrom;
            DateTime StartTime;
            DateTime EndTime;
            var SaveInUTC = false;

            switch (CurrentView)
            {
                case "day":
                    DateFrom = CurrentDate.Date;
                    DateTo = DateFrom.AddHours(24);
                    break;
                case "week":
                    DateTo = DateFrom.AddDays(7);
                    break;
                case "workweek":
                    DateTo = DateFrom.AddDays(5);
                    break;
                case "month":
                    DateFrom = CurrDate.Date.AddDays(-CurrDate.Day + 1);
                    DateTo = DateFrom.AddMonths(1);
                    break;
                case "agenda":
                    DateTo = DateTo.AddDays(7);
                    break;
            }

            DateTo = DateTo.AddTicks(-1); //Set the DateTo to the previous day's last tick as we use DateFrom >= and DateTo <= 

            var LoadAllRows = false;
            //var DefaultScheduleList = unitOfWork.Appointments.FindAll(app => app.CompanyID == companyID && app.StartTime >= StartDate && app.StartTime <= EndDate).ToList();// here particular date DefaultSchedule is filtered
            var AppointmentCol = unitOfWork.Appointments.GetAppointments(storeID, DateFrom, DateTo, LoadAllRows).ToList();

            foreach (var item in AppointmentCol)
            {
                TimeSpan oTimeSpan = item.EndTime.Value.Subtract(item.StartTime.Value);
                var SelectedServices = GetSelectedServices(item.AppointmentID);
                var AllowEdit = !IsAppointmentPaid(item.AppointmentID);
                var CustomerEnt = unitOfWork.Customers.Get(item.CustomerID);
                var StaffEnt = unitOfWork.Staffs.Get(item.StaffID);

                StartTime = item.StartTime.Value;
                EndTime = item.EndTime.Value;

                if (SaveInUTC)
                {
                    StartTime = item.StartTime.Value.ToLocalTime();
                    EndTime = item.EndTime.Value.ToLocalTime();
                }


                //AppointmentData.Add(new Models.SchedulerEntity { Id = item.AppointmentID.ToString(), CustomerID = item.CustomerID.ToString(), StaffId = item.StaffID.ToString(), Subject = item.Subject, StartTime = item.StartTime.Value, EndTime = item.EndTime.Value, Description = item.Description, Duration = oTimeSpan.Minutes, CustomerName = $"{item.Customer.FirstName} {item.Customer.LastName}", StaffName = $"{item.Staff.FirstName} {item.Staff.LastName}", AllDay = false, Recurrence = false, RecurrenceRule = "" });
                ReturnValue.Add(new Models.SchedulerEntity
                {
                    Id = item.AppointmentID.ToString(),
                    CustomerID = item.CustomerID.ToString(),
                    StaffID = item.StaffID.ToString(),
                    Subject = item.Subject,
                    StartTime = StartTime,
                    EndTime = EndTime,
                    Description = item.Description,
                    StartTimeZone = item.StartTimeZone,
                    EndTimeZone = item.EndTimeZone,
                    Duration = (int)oTimeSpan.TotalMinutes,
                    CustomerName = $"{CustomerEnt.FirstName} {CustomerEnt.LastName}",
                    StaffName = $"{StaffEnt.FullName}",
                    AllDay = false,
                    Recurrence = false,
                    RecurrenceRule = "",
                    Categorize = item.Status.ToString(),
                    Status = item.Status.ToString(),
                    SelectedServices = SelectedServices,
                    AllowEdit = AllowEdit
                });
            }

            return ReturnValue;
        }

        internal static DateTime FirstWeekDate(DateTime CurrentDate)
        {
            var ReturnValue = CurrentDate;

            try
            {
                DayOfWeek WeekDay = ReturnValue.DayOfWeek;

                switch (WeekDay)
                {
                    case DayOfWeek.Sunday:
                        break;
                    case DayOfWeek.Monday:
                        ReturnValue = ReturnValue.AddDays(-1);
                        break;
                    case DayOfWeek.Tuesday:
                        ReturnValue = ReturnValue.AddDays(-2);
                        break;
                    case DayOfWeek.Wednesday:
                        ReturnValue = ReturnValue.AddDays(-3);
                        break;
                    case DayOfWeek.Thursday:
                        ReturnValue = ReturnValue.AddDays(-4);
                        break;
                    case DayOfWeek.Friday:
                        ReturnValue = ReturnValue.AddDays(-5);
                        break;
                    case DayOfWeek.Saturday:
                        ReturnValue = ReturnValue.AddDays(-6);
                        break;
                }

            }
            catch
            {
                ReturnValue = DateTime.Now;
            }

            return ReturnValue;
        }

        private static bool IsAppointmentPaid(Guid appointmentID)
        {
            var ReturnValue = false;
            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            var TransactionEnt = unitOfWork.Transactions.GetTransactionByAppointmentID(appointmentID);
            ReturnValue = IsAppointmentPaid(TransactionEnt);

            return ReturnValue;
        }

        private static bool IsAppointmentPaid(SalonDB.Data.Core.Domain.Transaction transactionEnt)
        {
            var ReturnValue = false;
            ReturnValue = transactionEnt.Status == SalonDB.Data.eTransactionStatus.Paid.ToString();

            return ReturnValue;
        }

        private static string GetSelectedServices(Guid appointmentID)
        {
            var ReturnValue = string.Empty;
            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            var TransactionEnt = unitOfWork.Transactions.GetTransactionByAppointmentID(appointmentID);
            var Delimiter = ",";

            if (TransactionEnt != null)
            {
                var TransactionDetailServiceCol = unitOfWork.Transactions.GetTransactionDetailServiceByTransactionID(TransactionEnt.TransactionID);

                foreach (var item in TransactionDetailServiceCol)
                {
                    ReturnValue += $"{item.ServiceID.ToString()}{Delimiter}";
                }

                if (ReturnValue.Length > 0)
                {
                    ReturnValue = ReturnValue.Substring(0, ReturnValue.Length - Delimiter.Length);
                }

            }

            return ReturnValue;
        }
    }

}

