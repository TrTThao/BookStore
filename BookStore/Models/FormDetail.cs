namespace BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FormDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupplierID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookID { get; set; }

        public double? Price { get; set; }

        public int? NumberOfBooks { get; set; }

        public DateTime? DateOfImport { get; set; }

        public virtual Book Book { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
