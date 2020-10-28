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
        Task<IEnumerable<Meal>> GetAll();
        Task<Meal> GetMealById(int userId);
        Task<Meal> GetMealByName(string name);
        Task<List<Meal>> GetMealByType(string type);
        Task<List<Meal>> GetMealByWeight(decimal weight);
        Task<List<Meal>> GetMealByQuantity(int quantity);
        Task<List<Meal>> GetMealByPrice(int price);
        Task<List<Meal>> CheaperThanPrice(int price);
        Task<List<Meal>> ExpensiveThanPrice(int price);
        Task<List<Meal>> EmptyMeals();
        Task CreateMeal(Meal meal);
        Task UpdateMeal(Meal meal);
        Task<Meal> DeleteMeal(int mealId);


    }
}
