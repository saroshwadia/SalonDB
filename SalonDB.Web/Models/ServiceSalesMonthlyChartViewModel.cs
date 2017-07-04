using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SalonDB.Data.Core.Domain;

namespace SalonDB.Web.Models
{
    public class ServiceSalesMonthlyChartViewModel
    {

        public String Label { get; set; }
        public List<ServiceSalesMonthly> Chart { get; set; }
    }

    
}