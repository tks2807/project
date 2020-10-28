using FoodOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Get(int orderId);
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetOrderById(int orderId);
        Task<List<Order>> GetOrderByReceipt(string receipt);
        Task<List<Order>> GetOrderBySum(int sum);
        Task CreateOrder(Order order);
        Task UpdateOrder(Order order);
        Task<Order> DeleteOrder(int orderId);
    }
}
