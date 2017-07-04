namespace SalonDB.Data.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaction")]
    public partial class Transaction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transaction()
        {
            TransactionDetailProducts = new HashSet<TransactionDetailProduct>();
            TransactionDetailServices = new HashSet<TransactionDetailService>();
        }

        public Guid TransactionID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionNumber { get; set; }

        public Guid CompanyID { get; set; }

        public Guid? AppointmentID { get; set; }

        public Guid? StoreID { get; set; }

        public Guid? StaffID { get; set; }

        public Guid? CustomerID { get; set; }

        public Guid? PaymentTypeID { get; set; }

        public DateTime? TransactionDate { get; set; }

        public decimal Amount { get; set; }

        public decimal DiscountPercent { get; set; }

        public decimal TaxPercent { get; set; }

        public decimal Total { get; set; }

        public decimal TipAmount { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string PaymentType { get; set; }

        internal virtual Appointment Appointment { get; set; }

       internal virtual Company Company { get; set; }

       internal virtual Customer Customer { get; set; }

       internal virtual Staff Staff { get; set; }

       internal virtual Store Store { get; set; }

        internal virtual PaymentType PaymentTypeEnt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
       public virtual ICollection<TransactionDetailProduct> TransactionDetailProducts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
       public virtual ICollection<TransactionDetailService> TransactionDetailServices { get; set; }
    }

}
