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
        IEnumerable<Order> GetAll();
        List<Order> GetOrderById(int orderId);
        List<Order> GetOrderByReceipt(string receipt);
        List<Order> GetOrderBySum(int sum);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        Order DeleteOrder(int orderId);
    }
}
