using ExamenTI.DataAccess.Entities;
using ExamenTI.DataAccess.Repository.IRepository;

namespace ExamenTI.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<User> Create(User createUsersDto)
        {
            var userdb = new User()
            {
                Email = createUsersDto.Email,
                Password = createUsersDto.Password,                
                Role = createUsersDto.Role,
                CreateUser = DateTime.UtcNow,
            };

            _db.tblUser.Add(userdb);
            await _db.SaveChangesAsync();

            return userdb;
        }

        public User? GetUserById(int UserId)
        {
            return _db.tblUser.FirstOrDefault(u => u.Id == UserId);
        }

        public ICollection<User> GetUsers()
        {
            return _db.tblUser.OrderBy(u => u.Email).ToList();
        }

        public bool IsUniqueUser(string Email)
        {
            var userdb = _db.tblUser.FirstOrDefault(u => u.Email == Email);
            if (userdb == null)
            {
                return true;
            }
            return false;
        }

        public User GetUserByAuth(string Email, string Password)
        {
            var user = _db.tblUser.FirstOrDefault(
                u => u.Email.ToLower() == Email.ToLower() &&
                u.Password == Password);
            return user == null ? new User() : user;
        }
    }
}
