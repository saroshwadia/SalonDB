using SalonDB.Data.Core.Domain;
using SalonDB.Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonDB.Data.Persistence.Repositories
{
   public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {

        public CustomerRepository(SalonContext context) : base(context)
        {
        }

        public SalonContext SalonContext
        {
            get { return Context as SalonContext; }
        }

        public Customer GetCustomerWalkIn(Guid? companyID)
        {
            var ReturnValue = new Customer();
            var WalkInFirstName = "Walk";
            var WalkInLastName = "In";

            if (companyID != null)
            {
                ReturnValue = SalonContext.Customers.Where(oRow => oRow.CompanyID == companyID && oRow.FirstName == WalkInFirstName && oRow.LastName == WalkInLastName).FirstOrDefault();
            }

            return ReturnValue;
        }

      
    }
}
