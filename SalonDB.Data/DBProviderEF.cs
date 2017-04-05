using SalonDB.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SalonDB.Data
{
    public static class DBProviderEF
    {

        private static DBModel _context = new DBModel();
        public static DBModel Context { get { return _context; } }

        public static void EFReloadEntity<TEntity>(TEntity entity)
            where TEntity : class
        {
            if (entity != null)
            {
                try
                {
                    _context.Entry(entity).Reload();
                }
                catch (Exception)
                {
                }
            }
        }

        public static DBModel GetDBContext()
        {
            return _context;
        }

        public static void EFReloadNavigationProperty<TEntity, TElement>(TEntity entity, Expression<Func<TEntity, ICollection<TElement>>> navigationProperty)
            where TEntity : class
            where TElement : class
        {
            _context.Entry(entity).Collection<TElement>(navigationProperty).Query();
        }

        public static void EFReloadAll()
        {
            foreach (var entity in _context.ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }

        public static List<Company> GetCompanys()
        {
            var ReturnValue = _context.Companies.ToList();

            return ReturnValue;
        }

        public static Company GetCompany(Guid companyID)
        {
            var ReturnValue = _context.Companies.Find(companyID);

            return ReturnValue;
        }

        public static Company GetCompanyFirst()
        {
            var ReturnValue = _context.Companies.First();

            return ReturnValue;
        }

        public static List<Appointment> GetAppointmentsNotPaid(Guid? companyID, DateTime? dateFrom, DateTime? dateTo, bool all)
        {
            var ReturnValue = new List<Appointment>();

            if (companyID != null)
            {
                if (all || dateFrom == null)
                {
                    dateFrom = System.Data.SqlTypes.SqlDateTime.MinValue.Value; //DateTime.MinValue;
                }

                if (all || dateTo == null)
                {
                    dateTo = System.Data.SqlTypes.SqlDateTime.MaxValue.Value; //DateTime.MaxValue
                }

                ReturnValue = (from a in _context.Appointments
                              join t in _context.Transactions on a.AppointmentID equals t.AppointmentID
                              where a.CompanyID == companyID && a.StartTime >= dateFrom && a.StartTime <= dateTo && t.AppointmentID.HasValue && t.Status != eTransactionStatus.Paid.ToString()
                              orderby a.StartTime, a.EndTime, a.StaffID 
                               select a).ToList();
            }

            return ReturnValue;
        }

        public static List<Appointment> GetAppointments(Guid? appointmentID)
        {
            var ReturnValue = new List<Appointment>();

            if (appointmentID != null)
            {
                ReturnValue = _context.Appointments.Where(oRow=> oRow.AppointmentID == appointmentID).ToList();
            }

            return ReturnValue;
        }

        public static List<Staff> GetStaffs(Guid? companyID)
        {
            var ReturnValue = new List<Staff>();

            if (companyID != null)
            {
                ReturnValue = _context.Staffs.Where(oRow => oRow.CompanyID == companyID).ToList();
            }

            return ReturnValue;
        }

        public static List<Customer> GetCustomers(Guid? companyID)
        {
            var ReturnValue = new List<Customer>();

            if (companyID != null)
            {
                ReturnValue = _context.Customers.Where(oRow => oRow.CompanyID == companyID).ToList();
            }

            return ReturnValue;
        }


        public static List<Service> GetServices(Guid? companyID)
        {
            var ReturnValue = new List<Service>();

            if (companyID != null)
            {
                ReturnValue = _context.Services.Where(oRow => oRow.CompanyID == companyID).ToList();
            }

            return ReturnValue;
        }

        public static List<TransactionDetailService> GetTransactionDetailServiceByTransactionID(Guid? transactionID)
        {
            var ReturnValue = new List<TransactionDetailService>();

            if (transactionID != null)
            {
                ReturnValue = _context.TransactionDetailServices.Where(oRow => oRow.TransactionID == transactionID).ToList();
            }

            return ReturnValue;
        }

        public static List<Product> GetProducts(Guid? companyID)
        {
            var ReturnValue = new List<Product>();

            if (companyID != null)
            {
                ReturnValue = _context.Products.Where(oRow => oRow.CompanyID == companyID).ToList();
            }

            return ReturnValue;
        }

        public static List<Service> GetTopServices(Guid? companyID, int count)
        {
            var ReturnValue = new List<Service>();

            if (companyID != null)
            {
                ReturnValue = _context.Services.Where(oRow => oRow.CompanyID == companyID).OrderBy(x => Guid.NewGuid()).Take(count).ToList();
            }

            return ReturnValue;
        }

        public static List<Product> GetTopProducts(Guid? companyID, int count)
        {
            var ReturnValue = new List<Product>();

            if (companyID != null)
            {
                ReturnValue = _context.Products.Where(oRow => oRow.CompanyID == companyID).OrderBy(x => Guid.NewGuid()).Take(count).ToList();
            }

            return ReturnValue;
        }

        public static Transaction GetTransactionByAppointmentID(Guid appointmentID)
        {
            var ReturnValue = _context.Transactions.Where(oRow => oRow.AppointmentID == appointmentID && oRow.Status == eTransactionStatus.Appointment.ToString()).FirstOrDefault();

            return ReturnValue;
        }

        public static Appointment GetAppointment(Guid appointmentID)
        {
            var ReturnValue = _context.Appointments.Where(oRow => oRow.AppointmentID == appointmentID).FirstOrDefault();

            return ReturnValue;
        }

        public static Staff GetStaff(Guid staffID)
        {
            var ReturnValue = _context.Staffs.Where(oRow => oRow.StaffID == staffID).FirstOrDefault();

            return ReturnValue;
        }

        public static Staff GetStaffByAppointmentID(Guid appointmentID)
        {
            var ReturnValue = new Staff();
            var AppointmentEnt = GetAppointment(appointmentID);
            
            if (AppointmentEnt != null)
            {
                ReturnValue = _context.Staffs.Where(oRow => oRow.StaffID == AppointmentEnt.StaffID).FirstOrDefault();
            }

            return ReturnValue;
        }

        public static Staff GetStaffByEmailAndPassword(string email, string password)
        {
            var ReturnValue = new Staff();

            if (email == null || password == null)
            {
                ReturnValue = null;
            }
            else
            {
                ReturnValue = _context.Staffs.Where(oRow => oRow.Email == email && oRow.Password == password).FirstOrDefault();
            }

            return ReturnValue;
        }

    }
}
