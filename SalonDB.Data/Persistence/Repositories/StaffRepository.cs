using SalonDB.Data.Core.Domain;
using SalonDB.Data.Core.Repositories;
using System.Data.Entity;
using System.Linq;
using System;

namespace SalonDB.Data.Persistence.Repositories
{
    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        public StaffRepository(SalonContext context) : base(context)
        {
        }

        public SalonContext SalonContext
        {
            get { return Context as SalonContext; }
        }

        public Staff GetStaffByAppointmentID(Guid appointmentID)
        {
            var ReturnValue = new Staff();
            var AppointmentEnt = SalonContext.Appointments.Where(c => c.AppointmentID == appointmentID).FirstOrDefault();

            if (AppointmentEnt != null)
            {
                ReturnValue = SalonContext.Staffs.Where(oRow => oRow.StaffID == AppointmentEnt.StaffID).FirstOrDefault();
            }

            return ReturnValue;
        }
    }
}
