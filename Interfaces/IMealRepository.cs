using FoodOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Interfaces
{
    public interface IMealRepository
    {
        IEnumerable<Meal> Get(int mealId);
        IEnumerable<Meal> GetAll();
        List<Meal> GetMealById(int userId);
        List<Meal> GetMealByName(string name);
        List<Meal> GetMealByType(string type);
        List<Meal> GetMealByWeight(decimal weight);
        List<Meal> GetMealByQuantity(int quantity);
        List<Meal> GetMealByPrice(int price);
        List<Meal> CheaperThanPrice(int price);
        List<Meal> ExpensiveThanPrice(int price);
        List<Meal> EmptyMeals();
        void CreateMeal(Meal meal);
        void UpdateMeal(Meal meal);
        Meal DeleteMeal(int mealId);


    }
}
