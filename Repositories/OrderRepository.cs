using FoodOrder.Interfaces;
using FoodOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private FoodContext context;
        public OrderRepository(FoodContext context)
        {
            this.context = context;
        }
        public IEnumerable<Order> GetAll()
        {
            return context.Order;
        }

        public List<Order> GetOrderById(int orderId)
        {
            var meal = context.Order.Where(meal => meal.orderId == orderId);
            return meal.ToList();
        }

        public List<Order> GetOrderByReceipt(string receipt)
        {
            var meal = context.Order.Where(meal => meal.Receipt == receipt);
            return meal.ToList();
        }

        public List<Order> GetOrderBySum(int sum)
        {
            var meal = context.Order.Where(meal => meal.Sum == sum);
            return meal.ToList();
        }

        public IEnumerable<Order> Get(int orderId)
        {
            return context.Order;
        }

        public void CreateOrder(Order item)
        {
            context.Order.Add(item);
            context.SaveChanges();
        }

        public void UpdateOrder(Order item)
        {
            context.Order.Update(item);
            context.SaveChanges();
        }

        public Order DeleteOrder(int orderId)
        {
            var item = context.Order.Find(orderId);

            if (item != null)
            {
                context.Order.Remove(item);
                context.SaveChanges();
            }
            return item;
        }
    }
}
