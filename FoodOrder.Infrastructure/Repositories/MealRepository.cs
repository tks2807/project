using FoodOrder.Interfaces;
using FoodOrder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Repositories
{
    public class MealRepository : IMealRepository
    {
        private readonly FoodContext context;
        public MealRepository(FoodContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Meal>> GetAll()
        {
            return await context.Meal.OrderBy(x=>x.mealId).ToListAsync();
        }

        public async Task<Meal> GetMealById(int mealId)
        {
            var meal = await context.Meal.FindAsync(mealId);
            return meal;
        }

        public async Task<Meal> GetMealByName(string name)
        {
            var meal = await context.Meal.FindAsync(name);
            return meal;
        }

        public async Task<List<Meal>> GetMealByType(string type)
        {
            var meals = await context.Meal.Where(meal => meal.Type == type).ToListAsync();
            return meals;
        }

        public async Task<List<Meal>> GetMealByWeight(decimal weight)
        {
            var meals = await context.Meal.Where(meal => meal.Weight == weight).ToListAsync();
            return meals;
        }

        public async Task<List<Meal>> GetMealByQuantity(int quantity)
        {
            var meals = await context.Meal.Where(meal => meal.Quantity == quantity).ToListAsync();
            return meals;
        }

        public async Task<List<Meal>> GetMealByPrice(int price)
        {
            var meals = await context.Meal.Where(meal => meal.Price == price).ToListAsync();
            return meals;
        }

        public async Task<List<Meal>> CheaperThanPrice(int price)
        {
            var meals = await context.Meal.Where(meal => meal.Price < price).ToListAsync();
            return meals;
        }

        public async Task<List<Meal>> ExpensiveThanPrice(int price)
        {
            var meals = await context.Meal.Where(meal => meal.Price > price).ToListAsync();
            return meals;
        }

        public async Task<List<Meal>> EmptyMeals()
        {
            var meals = await context.Meal.Where(meal => meal.Quantity == 0).ToListAsync();
            return meals;
        }

        public IEnumerable<Meal> Get(int mealId)
        {
            return context.Meal;
        }

        public async Task CreateMeal(Meal item)
        {
            await context.Meal.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMeal(Meal item)
        {
            context.Meal.Update(item);
            await context.SaveChangesAsync();
        }

        public async Task<Meal> DeleteMeal(int mealId)
        {
            var item = await context.Meal.FindAsync(mealId);

            if (item != null)
            {
                context.Meal.Remove(item);
                await context.SaveChangesAsync();
            }

            return item;
        }
    }
}
