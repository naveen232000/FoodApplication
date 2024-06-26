﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodAppUILayer.Models
{

    public class OrderDetailsViewModel
    {
        public DateTime OrderDate { get; set; }
        public string FoodItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Subtotal { get; set; }
        public int FoodItemId { get; set; }
        public int OrderStatus { get; set; }
    }
}