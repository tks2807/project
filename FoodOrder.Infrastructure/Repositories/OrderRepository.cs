using FoodOrder.Interfaces;
using FoodOrder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FoodContext context;
        public OrderRepository(FoodContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Order>> GetAll()
        {
            return await context.Order.OrderBy(x=>x.orderId).ToListAsync();
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            var order = await context.Order.FindAsync(orderId);
            return order;
        }

        public async Task<List<Order>> GetOrderByReceipt(string receipt)
        {
            var orders = await context.Order.Where(order => order.Receipt == receipt).ToListAsync();
            return orders;
        }

        public async Task<List<Order>> GetOrderBySum(int sum)
        {
            var order = await context.Order.Where(order => order.Sum == sum).ToListAsync();
            return order;
        }

        public IEnumerable<Order> Get(int orderId)
        {
            return context.Order;
        }

        public async Task CreateOrder(Order item)
        {
            await context.Order.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task UpdateOrder(Order item)
        {
            context.Order.Update(item);
            await context.SaveChangesAsync();
        }

        public async Task<Order> DeleteOrder(int orderId)
        {
            var item = await context.Order.FindAsync(orderId);

            if (item != null)
            {
                context.Order.Remove(item);
                await context.SaveChangesAsync();
            }
            return item;
        }
    }
}
