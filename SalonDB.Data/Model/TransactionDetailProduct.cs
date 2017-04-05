namespace SalonDB.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TransactionDetailProduct")]
    public partial class TransactionDetailProduct
    {
        public Guid TransactionDetailProductID { get; set; }

        public Guid TransactionID { get; set; }

        public Guid? ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal DiscountPercent { get; set; }

        public decimal WholesalePrice { get; set; }

        public decimal Commission { get; set; }

        [StringLength(128)]
        public string BarCode { get; set; }

        public int Sequence { get; set; }

        public virtual Product Product { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}
