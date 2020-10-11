using FoodOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Interfaces
{
    public interface IAuthRepository
    {
        User Register(User user, string password);
        User Login(string username, string password);
        bool UserExists(string username);

    }
}
