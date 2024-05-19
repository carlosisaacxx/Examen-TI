using ExamenTI.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTI.Business.DTOs
{
    public class UsersDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        //public string Password { get; set; }

        public string Role { get; set; }
        public DateTime CreateUser { get; set; }
    }

    public class CreateUsersDto
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string Role { get; set; }
    }

    public class UserLoginDto
    {
        [Required(ErrorMessage = "UserName is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }

    public class UserResponseDto
    {
        public User UserToken { get; set; }
        public string Token { get; set; }
    }
}
