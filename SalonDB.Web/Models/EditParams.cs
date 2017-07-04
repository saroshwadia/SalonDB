using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonDB.Web.Models
{
    public class EditParams
    {
        public string key { get; set; }
        public string action { get; set; }
        public List<SchedulerEntity> added { get; set; }
        public List<SchedulerEntity> changed { get; set; }
        public List<SchedulerEntity> deleted { get; set; }
        public SchedulerEntity value { get; set; }
    }
}