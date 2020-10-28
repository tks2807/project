using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrder.DTOs;
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
        private readonly IUserRepository UserRepository;
        private readonly IMapper Mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            UserRepository = userRepository;
            Mapper = mapper;
        }

        [HttpGet("getusers")]
        public async Task<IActionResult> GetAll()
        {
            var users = await UserRepository.GetAll();
            var usersToReturn = Mapper.Map<IEnumerable<UserRegisterDTO>>(users);
            return users != null ? (IActionResult)Ok(usersToReturn) : NoContent();
        }

        [HttpGet("uid/{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var users = await UserRepository.GetUserById(userId);
            var usersToReturn = Mapper.Map<IEnumerable<UserRegisterDTO>>(users);
            return users != null ? (IActionResult)Ok(usersToReturn) : NoContent();
        }

        [HttpGet("username/{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var users = await UserRepository.GetUserByUsername(username);
            var usersToReturn = Mapper.Map<IEnumerable<UserRegisterDTO>>(users);
            return users != null ? (IActionResult)Ok(usersToReturn) : NoContent();
        }

        [HttpGet("fname/{fname}")]
        public async Task<IActionResult> GetUserByFname(string fname)
        {
            var users = await UserRepository.GetUserByFname(fname);
            var usersToReturn = Mapper.Map<IEnumerable<UserRegisterDTO>>(users);
            return users != null ? (IActionResult)Ok(usersToReturn) : NoContent();
        }

        [HttpGet("lname/{lname}")]
        public async Task<IActionResult> GetUserByLname(string lname)
        {
            var users = await UserRepository.GetUserByLname(lname);
            var usersToReturn = Mapper.Map<IEnumerable<UserRegisterDTO>>(users);
            return users != null ? (IActionResult)Ok(usersToReturn) : NoContent();
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var users = await UserRepository.GetUserByEmail(email);
            var usersToReturn = Mapper.Map<IEnumerable<UserRegisterDTO>>(users);
            return users != null ? (IActionResult)Ok(usersToReturn) : NoContent();
        }

        [HttpPost("createuser")]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            await UserRepository.CreateUser(user);
            return Accepted();
        }

        [HttpPut("updateuser/{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, User user)
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

            await UserRepository.UpdateUser(user);
            return Accepted();
        }

        [HttpDelete("deleteuser/{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var user = await UserRepository.DeleteUser(userId);

            if (user == null)
            {
                return BadRequest();
            }
            return Accepted();
        }
    }
}
