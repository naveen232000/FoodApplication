﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string CategoryName { get; set; }

        public ICollection<FoodItem> FoodItems { get; set; }
    }
}
