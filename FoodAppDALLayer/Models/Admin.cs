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
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z]{1,50}$", ErrorMessage = "Enter only letters")]
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z]{1,50}$", ErrorMessage = "Enter only letters")]
        public string LastName { get; set; }

        [MaxLength(255)]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Not a valid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "*Password is required.")]
        [DataType(DataType.Password)]
        [MaxLength(255)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "Password must have at least 8 characters, one uppercase letter, one lowercase letter, and one digit.")]
        public string Password { get; set; }

        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }

}
