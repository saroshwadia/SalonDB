using SalonDB.Data.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonDB.Data.Core.Repositories
{
    public interface IServiceRepository : IRepository<Service>
    {
        IEnumerable<Service> GetTopServices(int top, Guid? companyID, DateTime? fromDate, DateTime? toDate);
    }
}
