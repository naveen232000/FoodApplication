using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Models
{
    public class FoodItem
    {
        [Key]
        [Required]
        public int FoodId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        public string Image { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
    
        [Required]
        public int RestId { get; set; }
        [ForeignKey("RestId")]
        public virtual Restaurant Restaurant { get; set; }

        [Required, DataType(DataType.Currency)]

        public decimal Price { get; set; }
        public bool Availability { get; set; }

        public int CategoryId { get; set; }


        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public object Select(Func<FoodItem, FoodItem> mapToViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
