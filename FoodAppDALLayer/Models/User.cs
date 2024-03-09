using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAppDALLayer.Models
{
    public class User
    {
        [Key]
        [Required(ErrorMessage = "User ID is required.")]
        public int UserId { get; set; }

        [MaxLength(50)]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z]{1,50}$", ErrorMessage = "Enter only letters")]
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z]{1,50}$", ErrorMessage = "Enter only letters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(100, ErrorMessage = "Username cannot exceed 100 characters.")]
        [Index(IsUnique = true)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Not a valid phone number.")]
        public string Mobile { get; set; }

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
