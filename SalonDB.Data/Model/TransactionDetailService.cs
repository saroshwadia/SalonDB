namespace SalonDB.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TransactionDetailService")]
    public partial class TransactionDetailService
    {
        public Guid TransactionDetailServiceID { get; set; }

        public Guid TransactionID { get; set; }

        public Guid? ServiceID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal DiscountPercent { get; set; }

        public int Duration { get; set; }

        public bool ShowOnline { get; set; }

        public int Sequence { get; set; }

        public virtual Service Service { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}
