using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAppDALLayer.Models
{
    public class Rating
    {
        [Key, Required]
        public int RatingId { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public int FoodId { get; set; }

        [ForeignKey("FoodId")]
        public virtual FoodItem FoodItem { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }


        [Required(ErrorMessage = "Comments are required.")]
        public string Comments { get; set; }

        public int RatingCount { get; set; }
    }
}
