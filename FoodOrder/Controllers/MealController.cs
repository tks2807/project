using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrder.DTOs;
using FoodOrder.Interfaces;
using FoodOrder.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.Controllers
{
    [Route("api/meal")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealRepository MealRepository;
        private readonly IMapper Mapper;
        public MealController(IMealRepository mealRepository, IMapper mapper)
        {
            MealRepository = mealRepository;
            Mapper = mapper;
        }

        [HttpGet("getmeals")]
        public async Task<IActionResult> GetAllAsync()
        {
            var meals = await MealRepository.GetAll();
            var mealsToReturn = Mapper.Map<IEnumerable<MealDTO>>(meals);
            return meals != null ? (IActionResult)Ok(mealsToReturn) : NoContent();
        }

        [HttpGet("mid/{mealId}")]
        public async Task<IActionResult> GetMealByIdAsync(int mealId)
        {
            var meal = await MealRepository.GetMealById(mealId);
            var mealToSend = Mapper.Map<IEnumerable<MealDTO>>(meal);
            return meal != null ? (IActionResult)Ok(mealToSend) : NoContent();
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetMealByName(string name)
        {
            var meals = await MealRepository.GetMealByName(name);
            var mealToSend = Mapper.Map<IEnumerable<MealDTO>>(meals);
            return meals != null ? (IActionResult)Ok(mealToSend) : NoContent();
        }

        [HttpGet("type/{type}")]
        public async Task<IActionResult> GetMealByType(string type)
        {
            var meals = await MealRepository.GetMealByType(type);
            var mealToSend = Mapper.Map<IEnumerable<MealDTO>>(meals);
            return meals != null ? (IActionResult)Ok(mealToSend) : NoContent();
        }

        [HttpGet("weight/{weight}")]
        public async Task<IActionResult> GetMealByWeight(decimal weight)
        {
            var meals = await MealRepository.GetMealByWeight(weight);
            var mealToSend = Mapper.Map<IEnumerable<MealDTO>>(meals);
            return meals != null ? (IActionResult)Ok(mealToSend) : NoContent();
        }

        [HttpGet("quantity/{quantity}")]
        public async Task<IActionResult> GetMealByQuantity(int quantity)
        {
            var meals = await MealRepository.GetMealByQuantity(quantity);
            var mealToSend = Mapper.Map<IEnumerable<MealDTO>>(meals);
            return meals != null ? (IActionResult)Ok(mealToSend) : NoContent();
        }

        [HttpGet("price/{price}")]
        public async Task<IActionResult> GetMealByPrice(int price)
        {
            var meals = await MealRepository.GetMealByPrice(price);
            var mealToSend = Mapper.Map<IEnumerable<MealDTO>>(meals);
            return meals != null ? (IActionResult)Ok(mealToSend) : NoContent();
        }

        [HttpGet("cprice/{price}")]
        public IActionResult CheaperThanPrice(int price)
        {
            var meals = MealRepository.CheaperThanPrice(price);
            var mealToSend = Mapper.Map<IEnumerable<MealDTO>>(meals);
            return meals != null ? (IActionResult)Ok(mealToSend) : NoContent();
        }

        [HttpGet("eprice/{price}")]
        public async Task<IActionResult> ExpensiveThanPrice(int price)
        {
            var meals = await MealRepository.ExpensiveThanPrice(price);
            var mealToSend = Mapper.Map<IEnumerable<MealDTO>>(meals);
            return meals != null ? (IActionResult)Ok(mealToSend) : NoContent();
        }

        [HttpGet("empty")]
        public async Task<IActionResult> EmptyMeals()
        {
            var meals = await MealRepository.EmptyMeals();
            var mealToSend = Mapper.Map<IEnumerable<MealDTO>>(meals);
            return meals != null ? (IActionResult)Ok(mealToSend) : NoContent();
        }

        [HttpPost("createmeal")]
        public async Task<IActionResult> CreateMeal(Meal meal)
        {
            if (meal == null)
            {
                return BadRequest();
            }
            await MealRepository.CreateMeal(meal);
            return Accepted();
        }

        [HttpPut("updatemeal/{mealId}")]
        public async Task<IActionResult> UpdateMeal(int mealId, Meal meal)
        {
            if (meal == null || meal.mealId != mealId)
            {
                return BadRequest();
            }

            var tmpmeal = MealRepository.Get(mealId);
            if (tmpmeal == null)
            {
                return NotFound();
            }

            await MealRepository.UpdateMeal(meal);
            return Accepted();
        }

        [HttpDelete("deletemeal/{mealId}")]
        public async Task<IActionResult> DeleteMeal(int mealId)
        {
            var meal = await MealRepository.DeleteMeal(mealId);

            if (meal == null)
            {
                return BadRequest();
            }

            return Accepted();
        }
    }
}