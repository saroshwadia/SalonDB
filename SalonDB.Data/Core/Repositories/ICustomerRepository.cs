using SalonDB.Data.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonDB.Data.Core.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetCustomerWalkIn(Guid? companyID);
    }
}
