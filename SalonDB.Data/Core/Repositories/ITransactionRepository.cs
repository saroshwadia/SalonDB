using SalonDB.Data.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonDB.Data.Core.Repositories
{
      public interface ITransactionRepository : IRepository<Transaction>
    {
        Transaction GetTransactionByAppointmentID(Guid appointmentID);

        List<TransactionDetailService> GetTransactionDetailServiceByTransactionID(Guid? transactionID);
        List<TransactionDetailProduct> GetTransactionDetailProductByTransactionID(Guid? transactionID);

        int DeleteServices(Transaction transactionEnt);

        int DeleteProducts(Transaction transactionEnt);

        int DeleteDetails(Transaction transactionEnt);
    }
}
