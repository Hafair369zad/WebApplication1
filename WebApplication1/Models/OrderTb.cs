using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace WebApplication1.Models
{

    [Table("ORDER_TB")]
    public partial class OrderTb
    {
        [Key]
        [Column("ORDER_ID")]
        public int OrderId { get; set; }

        [Column("CUSTOMER_ID")]
        public int CustomerId { get; set; }

        [Column("ORDER_DATETIME", TypeName = "datetime")]
        public DateTime CreatedDateTime { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("OrderTbs")]
        public CustomerTb Customer { get; set; } = null;


        // Navigation Property
        public virtual ICollection<OrderDetailTb> OrderDetailTbs { get; set; }

    }
}
