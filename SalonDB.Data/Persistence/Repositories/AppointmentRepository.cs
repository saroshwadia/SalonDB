using SalonDB.Data.Core.Domain;
using SalonDB.Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SalonDB.Data.Persistence.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(SalonContext context) : base(context)
        {
        }

        public SalonContext SalonContext
        {
            get { return Context as SalonContext; }
        }

        public IEnumerable<Appointment> GetAppointmentsNotPaid(Guid? storeID, DateTime? dateFrom, DateTime? dateTo, bool all, Guid? customerID = null)
        {
            var ReturnValue = new List<Appointment>();

            if (storeID != null)
            {
                if (all || dateFrom == null)
                {
                    dateFrom = System.Data.SqlTypes.SqlDateTime.MinValue.Value; //DateTime.MinValue;
                }

                if (all || dateTo == null)
                {
                    dateTo = System.Data.SqlTypes.SqlDateTime.MaxValue.Value; //DateTime.MaxValue
                }

                if (customerID == null)
                {
                    ReturnValue = (from a in SalonContext.Appointments
                                   join t in SalonContext.Transactions on a.AppointmentID equals t.AppointmentID
                                   where a.StoreID == storeID && a.StartTime >= dateFrom && a.StartTime <= dateTo && t.AppointmentID.HasValue && t.Status != eTransactionStatus.Paid.ToString()
                                   orderby a.StartTime, a.EndTime, a.StaffID
                                   select a).ToList();
                }
                else
                {
                    ReturnValue = (from a in SalonContext.Appointments
                                   join t in SalonContext.Transactions on a.AppointmentID equals t.AppointmentID
                                   where a.CustomerID == customerID && a.StoreID == storeID && a.StartTime >= dateFrom && a.StartTime <= dateTo && t.AppointmentID.HasValue && t.Status != eTransactionStatus.Paid.ToString()
                                   orderby a.StartTime, a.EndTime, a.StaffID
                                   select a).ToList();
                }

            }

            return ReturnValue;
        }

        public IEnumerable<Appointment> GetAppointments(Guid? storeID, DateTime? dateFrom, DateTime? dateTo, bool all, Guid? customerID = null)
        {
            var ReturnValue = new List<Appointment>();

            if (storeID != null)
            {
                if (all || dateFrom == null)
                {
                    dateFrom = System.Data.SqlTypes.SqlDateTime.MinValue.Value; //DateTime.MinValue;
                }

                if (all || dateTo == null)
                {
                    dateTo = System.Data.SqlTypes.SqlDateTime.MaxValue.Value; //DateTime.MaxValue
                }

                    if (customerID == null)
                {
                    ReturnValue = (from a in SalonContext.Appointments
                                   where a.StoreID == storeID && a.StartTime >= dateFrom && a.StartTime <= dateTo
                                   orderby a.StartTime, a.EndTime, a.StaffID
                                   select a).ToList();
                }
                    else
                {
                    ReturnValue = (from a in SalonContext.Appointments
                                   where a.CustomerID == customerID && a.StoreID == storeID && a.StartTime >= dateFrom && a.StartTime <= dateTo
                                   orderby a.StartTime, a.EndTime, a.StaffID
                                   select a).ToList();

                }
            }

            return ReturnValue;
        }

    }
}
