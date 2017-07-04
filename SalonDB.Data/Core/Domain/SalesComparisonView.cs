namespace SalonDB.Data.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SalesComparisonView")]
    public partial class SalesComparisonView
    {
        public decimal? Revenue { get; set; }

        [StringLength(30)]
        public string MonthName { get; set; }

        public int? Month { get; set; }

        public decimal? CurrentYear { get; set; }

        public decimal? PreviousYear { get; set; }

        [Key]
        public Guid CompanyID { get; set; }
    }
}
