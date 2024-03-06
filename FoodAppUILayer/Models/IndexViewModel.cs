using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodAppUILayer.Models
{
    public class IndexViewModel
    {
        public int OrderCount { get; set; }
        public int UserCount { get; set; }
        public int RestaurantCount { get; set; }
        public int FoodItemCount { get; set; }
    }
}