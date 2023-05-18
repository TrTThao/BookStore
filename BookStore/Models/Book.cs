namespace BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            FormDetails = new HashSet<FormDetail>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public double? Price { get; set; }

        public string Decription { get; set; }

        public int? NumberOfInventory { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }

        public string Note { get; set; }

        [StringLength(100)]
        public string ImagePath { get; set; }

        public int? BookTypeID { get; set; }

        public int? AuthorID { get; set; }

        public int? PublisherID { get; set; }

        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }

        public virtual Publisher Publisher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormDetail> FormDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
