using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodOrdering;

namespace FoodOrdering.Controllers
{
    [Route("api/meals")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private OrderContext list;

        public MealController(OrderContext list)
        {
            this.list = list;
        }

        [HttpGet("getmeals")]
        public List<Meal> GetAll()
        {
            var meal = list.Meal.OrderBy(meal => meal.Id);
            return meal.ToList();
        }

        [HttpGet("mid/{Id}")]
        public List<Meal> GetMealById(int id)
        {
            var meal = list.Meal.Where(meal => meal.Id == id);
            return meal.ToList();
        }

        [HttpGet("price/{Price}")]
        public List<Meal> GetMealByPrice(int price)
        {
            var meal = list.Meal.Where(meal => meal.Price == price);
            return meal.ToList();
        }

        [HttpGet("name/{Name}")]
        public List<Meal> GetFoodByName(string name)
        {
            var meal = list.Meal.Where(meal => meal.Name == name);
            return meal.ToList();
        }

        [HttpGet("type/{Type}")]
        public List<Meal> GetFoodByType(string type)
        {
            var meal = list.Meal.Where(meal => meal.Type == type);
            return meal.ToList();
        }

        [HttpGet("kcal/{Kcal}")]
        public List<Meal> GetFoodByKcal(decimal kcal)
        {
            var meal = list.Meal.Where(meal => meal.Kcal == kcal);
            return meal.ToList();
        }

        [HttpPut("putmeals/{Id}")]
        public ActionResult PutMeals(int id, Meal meals)
        {
            if (id != meals.Id)
            {
                return BadRequest();
            }
            list.Entry(meals).State = EntityState.Modified;
            list.SaveChanges();
            return Accepted();
        }

        [HttpPost("postmeals")]
        public ActionResult PostMeals(Meal meals)
        {
            list.Meal.Add(meals);
            list.SaveChanges();
            return Accepted();
        }

        [HttpDelete("deletemeals/{Id}")]
        public ActionResult DeleteMeals(int id)
        {
            var meals = list.Meal.Find(id);
            if (id != meals.Id)
            {
                return BadRequest();
            }
            list.Meal.Remove(meals);
            list.SaveChanges();
            return Accepted();
        }
    }
}
