namespace SalonDB.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StaffHour")]
    public partial class StaffHour
    {
        public Guid StaffHourID { get; set; }

        public Guid CompanyID { get; set; }

        public Guid StaffID { get; set; }

        public Guid StoreID { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public virtual Company Company { get; set; }

        public virtual Staff Staff { get; set; }

        public virtual StaffHour StaffHour1 { get; set; }

        public virtual StaffHour StaffHour2 { get; set; }

        public virtual Store Store { get; set; }
    }
}
