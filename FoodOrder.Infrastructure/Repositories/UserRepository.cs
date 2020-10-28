using FoodOrder.Interfaces;
using FoodOrder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FoodContext context;
        public UserRepository(FoodContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await context.User.OrderBy(x=>x.userId).ToListAsync();
            return users;
        }

        public async Task<User> GetUserById(int userId)
        {
            var user = await context.User.FindAsync(userId);
            return user;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var user = await context.User.FindAsync(username);
            return user;
        }

        public async Task<List<User>> GetUserByFname(string fname)
        {
            var users = await context.User.Where(user => user.Fname == fname).ToListAsync();
            return users;
        }

        public async Task<List<User>> GetUserByLname(string lname)
        {
            var users = await context.User.Where(user => user.Lname == lname).ToListAsync();
            return users;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await context.User.FindAsync(email);
            return user;
        }

        public IEnumerable<User> Get(int userId)
        {
            return context.User;
        }

        public async Task CreateUser(User item)
        {
            await context.User.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task UpdateUser(User item)
        {
            context.User.Update(item);
            await context.SaveChangesAsync();
        }

        public async Task<User> DeleteUser(int userId)
        {
            var item = await context.User.FindAsync(userId);

            if (item != null)
            {
                context.User.Remove(item);
                await context.SaveChangesAsync();
            }
            return item;
        }
    }
}
