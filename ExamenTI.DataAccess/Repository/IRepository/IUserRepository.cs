using ExamenTI.DataAccess.Entities;

namespace ExamenTI.DataAccess.Repository.IRepository
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User? GetUserById(int UserId);
        bool IsUniqueUser(string Username);
        Task<User> Create(User createUsersDto);
        User GetUserByAuth(string Email, string Password);
    }
}
