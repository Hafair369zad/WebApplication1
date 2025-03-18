using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("CUSTOMER_TB")]
    public partial class CustomerTb
    {

        [Key]
        [Column("CUSTOMER_ID")]
        public int CustomerId { get; set; }

        [Required]
        [Column("CUSTOMER_NAME")]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Column("CUSTOMER_ADDRESS")]
        [StringLength(500)]
        public string Address { get; set; }


        // Navigation Property 

        [InverseProperty("Customer")]
        public ICollection<OrderTb> OrderTbs { get; set; } = new List<OrderTb>();
    }
}
