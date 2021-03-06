namespace SalonDB.Data.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceTransactionsView")]
    public partial class ServiceTransactionsView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TransactionNumber { get; set; }

        public DateTime? TransactionDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Quantity { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal UnitPrice { get; set; }

        public decimal? Amount { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal TaxPercent { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(7)]
        public string TType { get; set; }

        [Key]
        [Column(Order = 6)]
        public Guid TransactionID { get; set; }

        [Key]
        [Column(Order = 7)]
        public Guid CompanyID { get; set; }

        public int? Month { get; set; }
    }
}
