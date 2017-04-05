namespace SalonDB.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            TransactionDetailProducts = new HashSet<TransactionDetailProduct>();
        }

        public Guid ProductID { get; set; }

        public Guid CompanyID { get; set; }

        public Guid CategoryID { get; set; }

        public Guid SupplierID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal WholesalePrice { get; set; }

        public decimal Commission { get; set; }

        [StringLength(128)]
        public string BarCode { get; set; }

        public int? UnitsInStock { get; set; }

        public int? UnitsOnOrder { get; set; }

        public int? MinimumStockLevel { get; set; }

        public virtual Category Category { get; set; }

        public virtual Company Company { get; set; }

        public virtual Supplier Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionDetailProduct> TransactionDetailProducts { get; set; }
    }
}
