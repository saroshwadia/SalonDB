namespace SalonDB.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Appointment")]
    public partial class Appointment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Appointment()
        {
            Transactions = new HashSet<Transaction>();
        }

        public Guid AppointmentID { get; set; }

        public Guid CompanyID { get; set; }

        public Guid StoreID { get; set; }

        public Guid StaffID { get; set; }

        public Guid CustomerID { get; set; }

        [StringLength(50)]
        public string Notes { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(250)]
        public string Subject { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public bool? AllDay { get; set; }

        public string ReminderInfo { get; set; }

        public string RecurrenceInfo { get; set; }

        public int? Recurrence { get; set; }

        [StringLength(50)]
        public string RecurrenceRule { get; set; }

        [StringLength(50)]
        public string StartTimeZone { get; set; }

        [StringLength(50)]
        public string EndTimeZone { get; set; }

        public int Status { get; set; }

        public int Label { get; set; }

        public virtual Company Company { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Staff Staff { get; set; }

        public virtual Store Store { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
