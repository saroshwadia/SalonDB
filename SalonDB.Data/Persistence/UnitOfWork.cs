using SalonDB.Data.Core;
using SalonDB.Data.Core.Repositories;
using SalonDB.Data.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonDB.Data.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SalonContext _context;

        public UnitOfWork(SalonContext context)
        {
            _context = context;
            Appointments = new AppointmentRepository(_context);
            Transactions = new TransactionRepository(_context);
            Staffs = new StaffRepository(_context);
            Customers = new CustomerRepository(_context);
            Companys = new CompanyRepository(_context);
            Services = new ServiceRepository(_context);
            Products = new ProductRepository(_context);
            Stores = new StoreRepository(_context);
            Categorys = new CategoryRepository(_context);
            Suppliers = new SupplierRepository(_context);
            PaymentTypes = new PaymentTypeRepository(_context);
        }

        public IAppointmentRepository Appointments { get; private set; }
        public ITransactionRepository Transactions { get; private set; }
        public IStaffRepository Staffs { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public ICompanyRepository Companys { get; private set; }
        public IServiceRepository Services { get; private set; }
        public IProductRepository Products { get; private set; }
        public IStoreRepository Stores { get; private set; }
        public ICategoryRepository Categorys { get; private set; }
        public ISupplierRepository Suppliers { get; private set; }
        public IPaymentTypeRepository PaymentTypes { get; private set; }

        public int Commit()
        {
            var ReturnValue = 0;

            //using (var transaction = _context.Database.BeginTransaction())
            //{
            //    try
            //    {
            //        ReturnValue = _context.SaveChanges();
            //        transaction.Commit();
            //    }
            //    catch (Exception ex)
            //    {
            //        ReturnValue = -1;
            //        transaction.Rollback();
            //        throw;
            //    }

            //}

            ReturnValue = _context.SaveChanges();

            return ReturnValue;
        }

        public int RollBack()
        {
            var ReturnValue = 0;

            //_context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            var Result = _context.ChangeTracker.Entries().ToList();
            foreach (var item in Result)
            {
                try
                {
                    item.Reload();
                }
                catch (Exception)
                {
                    //throw;
                }
            }

            return ReturnValue;
        }

        public DbRawSqlQuery<T> SQLQuery<T>(string sql, params object[] parameters)
        {
            var ReturnValue  = _context.Database.SqlQuery<T>(sql, parameters);

            return ReturnValue;
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

    }
}
