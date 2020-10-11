using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.DTOs
{
    public class UserRegisterDTO
    {

        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(32, MinimumLength = 8, ErrorMessage ="Password length must be between 8 and 32")]
        public string Password { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }

    }
}
