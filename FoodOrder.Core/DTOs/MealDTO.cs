using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.DTOs
{
    public class MealDTO
    {
        public int MealId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public decimal Weight { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
