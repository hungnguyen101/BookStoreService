namespace BookstoreService.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public long id { get; set; }

        public int? Account { get; set; }

        [Column(TypeName = "xml")]
        public string Information { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedAt { get; set; }

        [StringLength(250)]
        public string ModifiedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifiedAt { get; set; }

        public bool? Status { get; set; }

        public decimal? Total { get; set; }

        [StringLength(250)]
        public string PaymentMethod { get; set; }
    }
}
