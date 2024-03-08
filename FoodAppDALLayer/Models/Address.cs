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
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        public string State { get; set; }
        [Required]
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
