using SalonDB.Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonDB.Data.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAppointmentRepository Appointments { get; }
        ITransactionRepository Transactions { get; }
        IStaffRepository Staffs { get; }
        ICustomerRepository Customers { get; }
        ICompanyRepository Companys { get; }
        IServiceRepository Services { get; }
        IProductRepository Products { get; }
        IStoreRepository Stores { get; }
        ICategoryRepository Categorys { get; }
        ISupplierRepository Suppliers { get; }
        IPaymentTypeRepository PaymentTypes { get; }

        int Commit();

        int RollBack();

        DbRawSqlQuery<T> SQLQuery<T>(string sql, params object[] parameters);

    }
}
