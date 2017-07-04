using SalonDB.Data.Core.Domain;
using SalonDB.Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonDB.Data.Persistence.Repositories
{
    public class CompanyRepository :Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(SalonContext context) : base(context)
        {
        }

        public SalonContext SalonContext
        {
            get { return Context as SalonContext; }
        }

        public Company GetCompanyFirst()
        {
            var ReturnValue = SalonContext.Companies.First();

            return ReturnValue;
        }
    }
}
