using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Models
{
    public class Admin
    {
        [Key, Required]
        public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(255)]
        [Required, EmailAddress, Index(IsUnique = true)]
        public string Email { get; set; }

        [Required, Phone, RegularExpression(@"^(+\d{1, 3}
    [- ]?)?\d{10}$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

    }
}
