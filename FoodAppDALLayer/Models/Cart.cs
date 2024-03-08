using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Models
{
    public class Cart
    {
        [Key,Required]
        public int CartId { get; set; }

        [Required]
        public int FoodId { get; set; }
        [ForeignKey("FoodId")]
        public virtual FoodItem FoodItem { get; set; }

        [Required ]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public int RestId { get; set; }
        [ForeignKey("RestId")]
        public virtual Restaurant Restaurant { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public double destinationLatitude { get; set; }
        public double destinationLongitude { get; set; }

    }
}
