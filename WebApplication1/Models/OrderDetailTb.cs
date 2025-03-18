using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("ORDERDETAIL_TB")]
    public partial class OrderDetailTb
    {
        [Column("ORDER_ID")]
        public int OrderId { get; set; }

        [Column("PRODUCT_ID")]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }


        [ForeignKey("OrderId")]
        [InverseProperty("OrderDetailTbs")]
        public OrderTb Order_OrderDetail { get; set; } = null;

        [ForeignKey("ProductId")]
        [InverseProperty("OrderDetailTbs")]
        public ProductTb Product_OrderDetail { get; set; } = null;


    }
}
