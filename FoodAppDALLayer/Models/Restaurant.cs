using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Models
{
    public class Restaurant
    {
        [Key]
        [Required]
        public int RestId { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        
       
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone, RegularExpression(@"^(\+\d{1,3}[- ]?)?\d{10}$", ErrorMessage = "Not a valid phone number")]
        public string Mobile { get; set; }
        //[Required]
        //public string Qty { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }

        public string City { get; set; }

        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
