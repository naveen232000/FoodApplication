using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Models
{
    public class Rating
    {
        [Key, Required]
        public int RatingId { get; set; }
        [Required, ForeignKey("FoodItem")
]
        public int FoodId { get; set; }
        [Required, ForeignKey("User")
]
        public int UserId { get; set; }
        
        public bool Like { get; set; }
        [Required]
        public string Comments { get; set; }
      
        public int RatingCount { get; set; }


    }
}
