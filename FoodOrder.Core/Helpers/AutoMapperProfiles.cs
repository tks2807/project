using AutoMapper;
using FoodOrder.DTOs;
using FoodOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Meal, MealDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<User, UserRegisterDTO>();
        }
    }
}
