using SalonDB.Data.Core.Domain;
using SalonDB.Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonDB.Data.Persistence.Repositories
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(SalonContext context) : base(context)
        {
        }

        public SalonContext SalonContext
        {
            get { return Context as SalonContext; }
        }

        public IEnumerable<Service> GetTopServices(int top, Guid? companyID, DateTime? fromDate, DateTime? toDate)
        {
            var ReturnValue = new List<Service>();

            if (companyID != null)
            {
                ReturnValue = SalonContext.Services.Where(oRow => oRow.CompanyID == companyID).OrderBy(x => Guid.NewGuid()).Take(top).ToList();
                //ReturnValue = DBProvider.GetTopServices(top, companyID.Value, fromDate.Value.Date, toDate.Value.Date);
            }

            return ReturnValue;
        }
    }
}
