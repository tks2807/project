using FoodOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> Get(int userId);
        IEnumerable<User> GetAll();
        List<User> GetUserById(int userId);
        List<User> GetUserByUsername(string username);
        List<User> GetUserByFname(string fname);
        List<User> GetUserByLname(string lname);
        List<User> GetUserByEmail(string email);
        void CreateUser(User user);
        void UpdateUser(User user);
        User DeleteUser(int userId);

    }
}
