using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;

namespace SalonDB.Data.Persistence
{
    public class SalonDBConfiguration : DbConfiguration
    {
        public SalonDBConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy(1, TimeSpan.FromSeconds(30)));
        }
    }
}
