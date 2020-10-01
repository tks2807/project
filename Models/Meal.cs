using System;
using System.Collections.Generic;

namespace FoodOrdering
{
    public partial class Meal
    {
        public int Id { get; set; }
        public int? Price { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal? Kcal { get; set; }
    }
}
