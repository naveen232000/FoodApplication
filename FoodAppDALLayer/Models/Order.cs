using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAppDALLayer.Models
{
    public class Order
    {
        [Key, Required]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Food ID is required.")]
        public int FoodId { get; set; }

        [ForeignKey("FoodId")]
        public virtual FoodItem FoodItem { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive value.")]
        public int Qty { get; set; }

        [Required(ErrorMessage = "Total amount is required.")]
        [DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Delivery address is required.")]
        public string DeliveryAddress { get; set; }

        [Required(ErrorMessage = "Delivery charge is required.")]
        [DataType(DataType.Currency)]
        public decimal DeliveryCharge { get; set; }

        [Required(ErrorMessage = "Order status is required.")]
        public string OrderStatus { get; set; }

        [Required(ErrorMessage = "Estimated delivery time is required.")]
        public DateTime EstimatedDeliveryTime { get; set; }

        [Required(ErrorMessage = "Date of order is required.")]
        public DateTime DateOfOrder { get; set; }

        [Required(ErrorMessage = "Payment type is required.")]
        public string PaymentType { get; set; }

        [Required(ErrorMessage = "Payment status is required.")]
        [MaxLength(255)]
        public string PaymentStatus { get; set; }

        public decimal Discount { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
