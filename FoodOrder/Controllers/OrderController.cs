using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrder.DTOs;
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
        private readonly IOrderRepository OrderRepository;
        private readonly IMapper Mapper;
        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            OrderRepository = orderRepository;
            Mapper = mapper;
        }

        [HttpGet("getorders")]
        public async Task<IActionResult> GetAll()
        {
            var orders = await OrderRepository.GetAll();
            var ordersToReturn = Mapper.Map<IEnumerable<OrderDTO>>(orders);
            return orders != null ? (IActionResult)Ok(ordersToReturn) : NoContent();
        }

        [HttpGet("oid/{orderId}")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var order = await OrderRepository.GetOrderById(orderId);
            var orderToSend = Mapper.Map<IEnumerable<OrderDTO>>(order);
            return order != null ? (IActionResult)Ok(orderToSend) : NoContent();
        }

        [HttpGet("receipt/{receipt}")]
        public async Task<IActionResult> GetOrderByReceipt(string receipt)
        {
            var order = await OrderRepository.GetOrderByReceipt(receipt);
            var orderToSend = Mapper.Map<IEnumerable<OrderDTO>>(order);
            return order != null ? (IActionResult)Ok(orderToSend) : NoContent();
        }

        [HttpGet("receipt/{receipt}")]
        public async Task<IActionResult> GetOrderBySum(int sum)
        {
            var order = await OrderRepository.GetOrderBySum(sum);
            var orderToSend = Mapper.Map<IEnumerable<OrderDTO>>(order);
            return order != null ? (IActionResult)Ok(orderToSend) : NoContent();
        }

        [HttpPost("createorder")]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            await OrderRepository.CreateOrder(order);
            return Accepted();
        }

        [HttpPut("updateorder/{orderId}")]
        public async Task<IActionResult> UpdateOrder(int orderId, Order order)
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

            await OrderRepository.UpdateOrder(order);
            return Accepted();
        }

        [HttpDelete("deleteorder/{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            var order = await OrderRepository.DeleteOrder(orderId);

            if (order == null)
            {
                return BadRequest();
            }
            return Accepted();
        }
    }
}
