using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAppDALLayer.Models
{
    public class Rating
    {
        [Key, Required]
        public int RatingId { get; set; }

        [Required(ErrorMessage = "order ID is required.")]
        public int OrderId { get; set; }


        [Required(ErrorMessage = "User ID is required.")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }


        [Required(ErrorMessage = "Comments are required.")]
        [MaxLength(250)]
        public string Comments { get; set; }
        
        public int RatingCount { get; set; }
    }
}
