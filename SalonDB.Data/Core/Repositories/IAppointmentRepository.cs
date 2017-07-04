using SalonDB.Data.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonDB.Data.Core.Repositories
{
      public interface IAppointmentRepository : IRepository<Appointment>
    {
        IEnumerable<Appointment> GetAppointmentsNotPaid(Guid? storeID, DateTime? dateFrom, DateTime? dateTo, bool all, Guid? customerID = null);

        IEnumerable<Appointment> GetAppointments(Guid? storeID, DateTime? dateFrom, DateTime? dateTo, bool all, Guid? customerID = null);
    }
}
