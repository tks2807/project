using FoodOrder.Interfaces;
using FoodOrder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FoodOrder.Repositories
{
    public class AuthRepository : IAuthRepository
        
    {
        private readonly FoodContext _context;

        public AuthRepository(FoodContext foodContext)
        {
            _context = foodContext;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Username == username);
            if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)) return null;
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

        public async Task<User> Register(User user, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        public async Task<bool> UserExists(string username)
        {
            return await _context.User.AnyAsync(x => x.Username == username);
        }
    }
}
