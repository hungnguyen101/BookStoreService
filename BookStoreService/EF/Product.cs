namespace BookstoreService.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Xml.Linq;

    [Table("Product")]
    public partial class Product
    {
        public long id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public int? Category { get; set; }

        [Column(TypeName = "xml")]
        public string Description { get; set; }


        [StringLength(250)]
        public string Thumbnail { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedAt { get; set; }

        [StringLength(250)]
        public string ModifiedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifiedAt { get; set; }

        public bool? Status { get; set; }

        public int? Promotion { get; set; }

        public bool? ShowOnHome { get; set; }
    }
}
