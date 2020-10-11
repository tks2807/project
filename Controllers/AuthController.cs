using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.AspNetCore.Mvc;
using FoodOrder.Repositories;
using FoodOrder.DTOs;
using FoodOrder.Models;
using FoodOrder.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _config;
        // GET: api/<AuthController>
        public AuthController(IAuthRepository authRepository, IConfiguration config)
        {
            _authRepository = authRepository;
            _config = config;
        }
        [HttpPost("register")]
        public IActionResult Register(UserRegisterDTO userRegisterDTO)
        {
            userRegisterDTO.Username = userRegisterDTO.Username.ToLower();
            if (_authRepository.UserExists(userRegisterDTO.Username)) return BadRequest("User already exists");
            var userToCreate = new User
            {
                Username = userRegisterDTO.Username,
                Lname = userRegisterDTO.Lname,
                Fname = userRegisterDTO.Fname,
                Email = userRegisterDTO.Email
            };
            var createdUser = _authRepository.Register(userToCreate, userRegisterDTO.Password);
            return StatusCode(201);
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDTO userLoginDTO)
        {
            var user = _authRepository.Login(userLoginDTO.Username, userLoginDTO.Password);

            if (user == null) return Unauthorized();
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.userId.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(3),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
       
    }
}
