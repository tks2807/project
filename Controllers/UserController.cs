using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodOrdering;

namespace FoodOrdering.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private OrderContext list;

        public UserController(OrderContext list)
        {
            this.list = list;
        }

        [HttpGet("getusers")]
        public List<User> GetAll()
        {
            var user = list.User.OrderBy(user => user.Id);
            return user.ToList();
        }

        [HttpGet("uid/{Id}")]
        public List<User> GetMealById(int id)
        {
            var user = list.User.Where(user => user.Id == id);
            return user.ToList();
        }

        [HttpGet("username/{Username}")]
        public List<User> GetUserByUsername(string username)
        {
            var user = list.User.Where(user => user.Username == username);
            return user.ToList();
        }

        [HttpGet("email/{Email}")]
        public List<User> GetUserByEmail(string email)
        {
            var user = list.User.Where(user => user.Email == email);
            return user.ToList();

        }

        [HttpPut("putusers/{Id}")]
        public ActionResult PutUsers(int id, User users)
        {
            if (id != users.Id)
            {
                return BadRequest();
            }
            list.Entry(users).State = EntityState.Modified;
            list.SaveChanges();
            return Accepted();
        }

        [HttpPost("postusers")]
        public ActionResult PostUsers(User users)
        {
            list.User.Add(users);
            list.SaveChanges();
            return Accepted();
        }

        [HttpDelete("deleteusers/{Id}")]
        public ActionResult DeleteUsers(int id)
        {
            var users = list.User.Find(id);
            if (id != users.Id)
            {
                return BadRequest();
            }

            list.User.Remove(users);
            list.SaveChanges();
            return Accepted();
        }
    }
}
