using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("PRODUCT_TB")]
    public partial class ProductTb
    {

        [Key]
        [Column("PRODUCT_ID")]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(255)]
        public string ProductDescription { get; set; } = null;

        [Column(TypeName = "decimal(10,2)")]
        public decimal? ProductPrice { get; set; }


        // Navigaation Propeerty
        public virtual ICollection<OrderDetailTb> OrderDetailTbs { get; set; }

    }
}
