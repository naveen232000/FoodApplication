using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Street name is required.")]
        [MaxLength(150)]
        public string Street { get; set; }

        [Required(ErrorMessage = "City name is required.")]
        [MaxLength(75)]
        public string City { get; set; }

        [Required(ErrorMessage = "state name is required.")]
        [MaxLength(75)]
        public string State { get; set; }

        [Required(ErrorMessage = "Postal code is required.")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Invalid postal code format. Please enter a 6-digit code.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Country Name is required.")]
        public string Country { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required(ErrorMessage = "Latitude is required.")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "Longitude is required.")]
        public double Longitude { get; set; }
    }
}
