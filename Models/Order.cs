using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Models
{
    public class Order
    {
        public int orderId { get; set; }
        public virtual User User { get; set; }
        public virtual Meal Meal { get; set; }
        public string Receipt { get; set; }
        public int Sum { get; set; }

    }
}
