using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Models
{
    public class Order
    {
        [Key, Required]
        public int OrderId { get; set; }
        [Required]
        public int FoodId { get; set; }
        [ForeignKey("FoodId")]
        public virtual FoodItem FoodItem { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal DeliveryCharge { get; set; }
        [Required]
        public string OrderStatus { get; set; }
     
        [Required]
        public DateTime EstimatedDeliveryTime { get; set; }
        [Required]
        public DateTime DateOfOrder { get; set; }

        [Required]
        public string PaymentType { get; set; }

        [Required]
        [MaxLength(255)]
        public string PaymentStatus { get; set; }
        public decimal Discount { get; set; }
    }
}
