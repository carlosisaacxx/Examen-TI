using ExamenTI.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTI.Business.Interfaces
{
    public interface IUserServices
    {
        ICollection<UsersDto> GetUsers();
        UsersDto GetUser(int UserId);
        Task<UserResponseDto> UserLogin(UserLoginDto userLoginDto);
        Task<UsersDto> Create(CreateUsersDto createUsersDto);
        bool IsUniqueUser(string Email);
    }
}
