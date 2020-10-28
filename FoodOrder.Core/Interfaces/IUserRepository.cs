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
        Task<IEnumerable<User>> GetAll();
        Task<User> GetUserById(int userId);
        Task<User> GetUserByUsername(string username);
        Task<List<User>> GetUserByFname(string fname);
        Task<List<User>> GetUserByLname(string lname);
        Task<User> GetUserByEmail(string email);
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task<User> DeleteUser(int userId);

    }
}
