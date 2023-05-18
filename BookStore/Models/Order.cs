namespace BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ID { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(200)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Receiver { get; set; }

        public bool? Status { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        public int? UserID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual User User { get; set; }
    }
}
