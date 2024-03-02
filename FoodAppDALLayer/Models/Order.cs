using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required]
        public int Qty { get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal TotalAmount{ get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal DeliveryCharge { get; set; }
        [Required]
        public string OrderStatus { get; set; }
        [Required]
        public int PaymentId { get; set; }
        [ForeignKey("PaymentId")]
        public virtual Payment Payment { get; set; }
        [Required]
        public DateTime EstimatedDeliveryTime { get; set; }
        [Required]
        public DateTime DateOfOrder { get; set; }
    }
}
