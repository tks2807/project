using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodOrder.Interfaces;
using FoodOrder.Models;
using FoodOrder.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.Controllers
{
    [Route("api/meal")]
    [ApiController]
    public class MealController : ControllerBase
    {
        IMealRepository MealRepository;
        public MealController(IMealRepository mealRepository)
        {
            MealRepository = mealRepository;
        }

        [HttpGet("getmeals")]
        public IEnumerable<Meal> GetAll()
        {
            return MealRepository.GetAll();
        }

        [HttpGet("mid/{mealId}")]
        public List<Meal> GetMealById(int mealId)
        {
            List<Meal> meal = MealRepository.GetMealById(mealId);
            return meal.ToList();
        }

        [HttpGet("name/{name}")]
        public List<Meal> GetMealByName(string name)
        {
            List<Meal> meal = MealRepository.GetMealByName(name);
            return meal.ToList();
        }

        [HttpGet("type/{type}")]
        public List<Meal> GetMealByType(string type)
        {
            List<Meal> meal = MealRepository.GetMealByType(type);
            return meal.ToList();
        }

        [HttpGet("weight/{weight}")]
        public List<Meal> GetMealByWeight(decimal weight)
        {
            List<Meal> meal = MealRepository.GetMealByWeight(weight);
            return meal.ToList();
        }

        [HttpGet("quantity/{quantity}")]
        public List<Meal> GetMealByQuantity(int quantity)
        {
            List<Meal> meal = MealRepository.GetMealByQuantity(quantity);
            return meal.ToList();
        }

        [HttpGet("price/{price}")]
        public List<Meal> GetMealByPrice(int price)
        {
            List<Meal> meal = MealRepository.GetMealByPrice(price);
            return meal.ToList();
        }

        [HttpGet("cprice/{price}")]
        public List<Meal> CheaperThanPrice(int price)
        {
            List<Meal> meal = MealRepository.CheaperThanPrice(price);
            return meal.ToList();
        }

        [HttpGet("eprice/{price}")]
        public List<Meal> ExpensiveThanPrice(int price)
        {
            List<Meal> meal = MealRepository.ExpensiveThanPrice(price);
            return meal.ToList();
        }

        [HttpGet("empty")]
        public List<Meal> EmptyMeals()
        {
            List<Meal> meal = MealRepository.EmptyMeals();
            return meal.ToList();
        }

        [HttpPost("createmeal")]
        public IActionResult CreateMeal(Meal meal)
        {
            if (meal == null)
            {
                return BadRequest();
            }
            MealRepository.CreateMeal(meal);
            return Accepted();
        }

        [HttpPut("updatemeal/{mealId}")]
        public IActionResult UpdateMeal(int mealId, Meal meal)
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

            MealRepository.UpdateMeal(meal);
            return Accepted();
        }

        [HttpDelete("deletemeal/{mealId}")]
        public IActionResult DeleteMeal(int mealId)
        {
            var meal = MealRepository.DeleteMeal(mealId);

            if (meal == null)
            {
                return BadRequest();
            }

            return Accepted();
        }
    }
}