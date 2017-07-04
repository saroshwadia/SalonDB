namespace SalonDB.Data.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Staff")]
    public partial class Staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Staff()
        {
            Appointments = new HashSet<Appointment>();
            StaffHours = new HashSet<StaffHour>();
            Transactions = new HashSet<Transaction>();
        }

        public Guid StaffID { get; set; }

        public Guid CompanyID { get; set; }

        public Guid? StoreID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(250)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string PostalCode { get; set; }

        [StringLength(50)]
        public string Role { get; set; }

        public decimal Commission { get; set; }

        public decimal Rate { get; set; }

        [Required]
        [StringLength(50)]
        public string ResourceColor { get; set; }

        public DateTime? LastLogin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
       internal virtual ICollection<Appointment> Appointments { get; set; }

       internal virtual Company Company { get; set; }

       internal virtual Store Store { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
       internal virtual ICollection<StaffHour> StaffHours { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
       internal virtual ICollection<Transaction> Transactions { get; set; }
    }
}
