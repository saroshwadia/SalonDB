using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonDB.Web.Models
{
    public class ServiceSalesMonthlyViewModel
    {

        public IEnumerable<string> Year { get; set; }
        public IEnumerable<string> Month { get; set; }
        public int SelectedMonth { get; set; }
    }

    public class IDNameViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}