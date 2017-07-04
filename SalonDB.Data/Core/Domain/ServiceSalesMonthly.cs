namespace SalonDB.Data.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceSalesMonthly")]
    public partial class ServiceSalesMonthly
    {
        public DateTime? TransactionDate { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal? Amount { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid StoreID { get; set; }

        [StringLength(30)]
        public string Month { get; set; }

        [StringLength(255)]
        public string Year { get; set; }
    }
}
