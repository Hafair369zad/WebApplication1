using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{

    [Table("USER_TB")]
    public partial class UserTb
    {
        [Key]
        public int UserId { get; set; }


        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string EmailConfirmed { get; set; }

    }
}
