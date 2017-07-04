using SalonDB.Data.Core.Domain;
using SalonDB.Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonDB.Data.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(SalonContext context) : base(context)
        {
        }

        public SalonContext SalonContext
        {
            get { return Context as SalonContext; }
        }

        public  IEnumerable<Product> GetTopProducts(int top, Guid? companyID, DateTime? fromDate, DateTime? toDate)
        {
            var ReturnValue = new List<Product>();

            if (companyID != null)
            {
                ReturnValue = SalonContext.Products.Where(oRow => oRow.CompanyID == companyID).OrderBy(x => Guid.NewGuid()).Take(top).ToList();
            }

            return ReturnValue;
        }
    }
}
