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
        [Required]
        public int CartId { get; set; }
        [Required, ForeignKey("FoodItem")]
        public int FoodId { get; set; }
        [Required, ForeignKey("User")]
        public int UserId { get; set; }
        [Required, ForeignKey("Restaurant")]
        public int RestId { get; set; }
 
    }
}
