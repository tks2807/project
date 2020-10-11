using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodOrder.Interfaces;
using FoodOrder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository UserRepository;
        public UserController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        [HttpGet("getusers")]
        public IEnumerable<User> GetAll()
        {
            return UserRepository.GetAll();
        }

        [HttpGet("uid/{userId}")]
        public List<User> GetUserById(int userId)
        {
            List<User> user = UserRepository.GetUserById(userId);
            return user.ToList();
        }

        [HttpGet("username/{username}")]
        public List<User> GetUserByUsername(string username)
        {
            List<User> user = UserRepository.GetUserByUsername(username);
            return user.ToList();
        }

        [HttpGet("fname/{fname}")]
        public List<User> GetUserByFname(string fname)
        {
            List<User> user = UserRepository.GetUserByFname(fname);
            return user.ToList();
        }

        [HttpGet("lname/{lname}")]
        public List<User> GetUserByLname(string lname)
        {
            List<User> user = UserRepository.GetUserByLname(lname);
            return user.ToList();
        }

        [HttpGet("email/{email}")]
        public List<User> GetUserByEmail(string email)
        {
            List<User> user = UserRepository.GetUserByEmail(email);
            return user.ToList();
        }

        [HttpPost("createuser")]
        public IActionResult CreateUser(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            UserRepository.CreateUser(user);
            return Accepted();
        }

        [HttpPut("updateuser/{userId}")]
        public IActionResult UpdateUser(int userId, User user)
        {
            if (user == null || user.userId != userId)
            {
                return BadRequest();
            }

            var tmpuser = UserRepository.Get(userId);
            if (tmpuser == null)
            {
                return NotFound();
            }

            UserRepository.UpdateUser(user);
            return Accepted();
        }

        [HttpDelete("deleteuser/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            var user = UserRepository.DeleteUser(userId);

            if (user == null)
            {
                return BadRequest();
            }
            return Accepted();
        }
    }
}
