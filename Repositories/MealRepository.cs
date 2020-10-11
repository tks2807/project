using FoodOrder.Interfaces;
using FoodOrder.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Repositories
{
    public class MealRepository : IMealRepository
    {
        private FoodContext context;
        public MealRepository(FoodContext context)
        {
            this.context = context;
        }
        public IEnumerable<Meal> GetAll()
        {
            return context.Meal;
        }

        public List<Meal> GetMealById(int mealId)
        {
            var meal = context.Meal.Where(meal => meal.mealId == mealId);
            return meal.ToList();
        }

        public List<Meal> GetMealByName(string name)
        {
            var meal = context.Meal.Where(meal => meal.Name == name);
            return meal.ToList();
        }

        public List<Meal> GetMealByType(string type)
        {
            var meal = context.Meal.Where(meal => meal.Type == type);
            return meal.ToList();
        }

        public List<Meal> GetMealByWeight(decimal weight)
        {
            var meal = context.Meal.Where(meal => meal.Weight == weight);
            return meal.ToList();
        }

        public List<Meal> GetMealByQuantity(int quantity)
        {
            var meal = context.Meal.Where(meal => meal.Quantity == quantity);
            return meal.ToList();
        }

        public List<Meal> GetMealByPrice(int price)
        {
            var meal = context.Meal.Where(meal => meal.Price == price);
            return meal.ToList();
        }

        public List<Meal> CheaperThanPrice(int price)
        {
            var meal = context.Meal.Where(meal => meal.Price < price);
            return meal.ToList();
        }

        public List<Meal> ExpensiveThanPrice(int price)
        {
            var meal = context.Meal.Where(meal => meal.Price > price);
            return meal.ToList();
        }

        public List<Meal> EmptyMeals()
        {
            var meal = context.Meal.Where(meal => meal.Quantity == 0);
            return meal.ToList();
        }

        public IEnumerable<Meal> Get(int mealId)
        {
            return context.Meal;
        }

        public void CreateMeal(Meal item)
        {
            context.Meal.Add(item);
            context.SaveChanges();
        }

        public void UpdateMeal(Meal item)
        {
            context.Meal.Update(item);
            context.SaveChanges();
        }

        public Meal DeleteMeal(int mealId)
        {
            var item = context.Meal.Find(mealId);

            if (item != null)
            {
                context.Meal.Remove(item);
                context.SaveChanges();
            }

            return item;
        }
    }
}
