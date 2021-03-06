namespace SalonDB.Data.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Service")]
    public partial class Service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service()
        {
            TransactionDetailServices = new HashSet<TransactionDetailService>();
        }

        public Guid ServiceID { get; set; }
        public Guid CompanyID { get; set; }
        public Guid StoreID { get; set; }
        public Guid CategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Duration { get; set; }

        public bool ShowOnline { get; set; }

       internal virtual Category Category { get; set; }

       internal virtual Company Company { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
       internal virtual ICollection<TransactionDetailService> TransactionDetailServices { get; set; }
    }
}
