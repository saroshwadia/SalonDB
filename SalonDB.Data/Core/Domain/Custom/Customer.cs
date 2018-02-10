using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonDB.Data.Core.Domain
{
    public partial class Customer
    {
        public string FullName => $"{this.FirstName} {this.LastName}";
    }
}
