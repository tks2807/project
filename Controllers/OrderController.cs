using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodOrder.Interfaces;
using FoodOrder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderRepository OrderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            OrderRepository = orderRepository;
        }

        [HttpGet("getorders")]
        public IEnumerable<Order> GetAll()
        {
            return OrderRepository.GetAll();
        }

        [HttpGet("oid/{orderId}")]
        public List<Order> GetOrderById(int orderId)
        {
            List<Order> order = OrderRepository.GetOrderById(orderId);
            return order.ToList();
        }

        [HttpGet("receipt/{receipt}")]
        public List<Order> GetOrderByReceipt(string receipt)
        {
            List<Order> order = OrderRepository.GetOrderByReceipt(receipt);
            return order.ToList();
        }

        [HttpGet("receipt/{receipt}")]
        public List<Order> GetOrderBySum(int sum)
        {
            List<Order> order = OrderRepository.GetOrderBySum(sum);
            return order.ToList();
        }

        [HttpPost("createorder")]
        public IActionResult CreateOrder(Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            OrderRepository.CreateOrder(order);
            return Accepted();
        }

        [HttpPut("updateorder/{orderId}")]
        public IActionResult UpdateOrder(int orderId, Order order)
        {
            if (order == null || order.orderId != orderId)
            {
                return BadRequest();
            }

            var tmporder = OrderRepository.Get(orderId);
            if (tmporder == null)
            {
                return NotFound();
            }

            OrderRepository.UpdateOrder(order);
            return Accepted();
        }

        [HttpDelete("deleteorder/{orderId}")]
        public IActionResult DeleteOrder(int orderId)
        {
            var order = OrderRepository.DeleteOrder(orderId);

            if (order == null)
            {
                return BadRequest();
            }
            return Accepted();
        }
    }
}
