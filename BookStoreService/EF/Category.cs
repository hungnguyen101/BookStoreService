namespace BookstoreService.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public int id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public int? ParentID { get; set; }

        public bool? Status { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedAt { get; set; }

        [StringLength(250)]
        public string ModifiedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifiedAt { get; set; }
    }
}
