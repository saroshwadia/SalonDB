using SalonDB.Data.Core.Domain;
using SalonDB.Data.Core.Repositories;
using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace SalonDB.Data.Persistence.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(SalonContext context) : base(context)
        {
        }

        public SalonContext SalonContext
        {
            get { return Context as SalonContext; }
        }

        public Transaction GetTransactionByAppointmentID(Guid appointmentID)
        {
            //var ReturnValue = SalonContext.Transactions.Include("TransactionDetailServices").Include("TransactionDetailProducts").Where(oRow => oRow.AppointmentID == appointmentID && oRow.Status == eTransactionStatus.Appointment.ToString()).FirstOrDefault();
            var ReturnValue = SalonContext.Transactions.Include("TransactionDetailServices").Include("TransactionDetailProducts").Where(oRow => oRow.AppointmentID == appointmentID).FirstOrDefault();

            return ReturnValue;
        }

        public List<TransactionDetailService> GetTransactionDetailServiceByTransactionID(Guid? transactionID)
        {
            var ReturnValue = new List<TransactionDetailService>();

            if (transactionID != null)
            {
                ReturnValue = SalonContext.TransactionDetailServices.Where(oRow => oRow.TransactionID == transactionID).ToList();
            }

            return ReturnValue;
        }

        public List<TransactionDetailProduct> GetTransactionDetailProductByTransactionID(Guid? transactionID)
        {
            var ReturnValue = new List<TransactionDetailProduct>();

            if (transactionID != null)
            {
                ReturnValue = SalonContext.TransactionDetailProducts.Where(oRow => oRow.TransactionID == transactionID).ToList();
            }

            return ReturnValue;
        }

        public int DeleteServices(Transaction transactionEnt)
        {
            var ReturnValue = 0;
            if (transactionEnt != null)
            {
                foreach (var childEnt in transactionEnt.TransactionDetailServices.ToList())
                {
                    ReturnValue++;
                    SalonContext.TransactionDetailServices.Remove(childEnt);
                }
            }

            return ReturnValue;
        }

        public int DeleteProducts(Transaction transactionEnt)
        {
            var ReturnValue = 0;
            if (transactionEnt != null)
            {
                foreach (var childEnt in transactionEnt.TransactionDetailProducts.ToList())
                {
                    ReturnValue++;
                    SalonContext.TransactionDetailProducts.Remove(childEnt);
                }
            }

            return ReturnValue;
        }
               
        public int DeleteDetails(Transaction transactionEnt)
        {
            var ReturnValue = 0;

            ReturnValue = DeleteServices(transactionEnt);
            ReturnValue += DeleteProducts(transactionEnt);

            return ReturnValue;
        }
      
    }
}
