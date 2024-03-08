using FoodAppDALLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodAppUILayer.Models
{
    public class OrderViewModel
    {
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
       
  
        [Required, DataType(DataType.Currency)]
        public decimal DeliveryCharge { get; set; }
        [Required]
        public DateTime EstimatedDeliveryTime { get; set; }
        [Required]
        public DateTime DateOfOrder { get; set; }

        public List<OrderDetailsViewModel> OrderDetails { get; set; }
        public List<AddressViewModel> Addresses { get; set; }
        public double destinationLatitude { get; set; }
        public double destinationLongitude { get; set; }
    }
}