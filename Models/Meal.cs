﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Models
{
    public class Meal
    {
        public int mealId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Weight { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
