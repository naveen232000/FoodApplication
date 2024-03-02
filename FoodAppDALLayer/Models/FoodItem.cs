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

        public byte[] Image { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Required, ForeignKey("Restaurant")]
        public int RestId { get; set; }
        [Required, DataType(DataType.Currency)]

        public decimal Price { get; set; }
        public bool Availability { get; set; }
    }
}
