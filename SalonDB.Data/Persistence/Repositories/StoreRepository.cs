using SalonDB.Data.Core.Domain;
using SalonDB.Data.Core.Repositories;
using System.Data.Entity;
using System.Linq;

namespace SalonDB.Data.Persistence.Repositories
{
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        public StoreRepository(SalonContext context) : base(context)
        {
        }

        public SalonContext SalonContext
        {
            get { return Context as SalonContext; }
        }
    }
}
