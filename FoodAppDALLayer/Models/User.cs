using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Models
{
    public class User
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        [Required, StringLength(100), Index(IsUnique = true)]
        public string UserName { get; set; }
        [Required, EmailAddress, StringLength(100),Index(IsUnique = true)]
        public string Email { get; set; }
        [Required, Phone, RegularExpression(@"^(+\d{1, 3}
    [- ]?)?\d{10}$", ErrorMessage = "Not a valid phone number")]
        public string Mobile { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}

