using FoodOrder.Interfaces;
using FoodOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Repositories
{
    public class UserRepository : IUserRepository
    {
        private FoodContext context;
        public UserRepository(FoodContext context)
        {
            this.context = context;
        }
        public IEnumerable<User> GetAll()
        {
            return context.User;
        }

        public List<User> GetUserById(int userId)
        {
            var meal = context.User.Where(meal => meal.userId == userId);
            return meal.ToList();
        }

        public List<User> GetUserByUsername(string username)
        {
            var meal = context.User.Where(meal => meal.Username == username);
            return meal.ToList();
        }

        public List<User> GetUserByFname(string fname)
        {
            var meal = context.User.Where(meal => meal.Fname == fname);
            return meal.ToList();
        }

        public List<User> GetUserByLname(string lname)
        {
            var meal = context.User.Where(meal => meal.Lname == lname);
            return meal.ToList();
        }

        public List<User> GetUserByEmail(string email)
        {
            var meal = context.User.Where(meal => meal.Email == email);
            return meal.ToList();
        }

        public IEnumerable<User> Get(int userId)
        {
            return context.User;
        }

        public void CreateUser(User item)
        {
            context.User.Add(item);
            context.SaveChanges();
        }

        public void UpdateUser(User item)
        {
            context.User.Update(item);
            context.SaveChanges();
        }

        public User DeleteUser(int userId)
        {
            var item = context.User.Find(userId);

            if (item != null)
            {
                context.User.Remove(item);
                context.SaveChanges();
            }
            return item;
        }
    }
}
