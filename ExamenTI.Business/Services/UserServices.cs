using AutoMapper;
using ExamenTI.Business.DTOs;
using ExamenTI.Business.Interfaces;
using ExamenTI.Business.Util;
using ExamenTI.DataAccess.Repository.IRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace ExamenTI.Business.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        protected EncripUtil encripUtil = new EncripUtil();
        private string keySecret;

        public UserServices(IUserRepository userRepository, IMapper mapper, IConfiguration configuration) { 
            _userRepository = userRepository;
            _mapper = mapper;
            keySecret = configuration.GetValue<string>("ApiSettings:KeySecret");
        }

        public async Task<UsersDto> Create(CreateUsersDto createUsersDto)
        {
            var user = _mapper.Map<DataAccess.Entities.User>(createUsersDto);
            user.Password = encripUtil.GetMd5(user.Password);

            var createdUser = await _userRepository.Create(user);
            var usersDto = _mapper.Map<UsersDto>(createdUser);

            return usersDto;
        }


        public UsersDto GetUser(int UserId)
        {
            return _mapper.Map<UsersDto>(_userRepository.GetUserById(UserId));
        }

        public ICollection<UsersDto> GetUsers()
        {
            return _mapper.Map<ICollection<UsersDto>>(_userRepository.GetUsers());
        }

        public bool IsUniqueUser(string Email) { 
            return _userRepository.IsUniqueUser(Email);
        }


        public async Task<UserResponseDto> UserLogin(UserLoginDto userLoginDto)
        {
            var passDescrip = encripUtil.GetMd5(userLoginDto.Password);
            var user = _userRepository.GetUserByAuth(userLoginDto.Email,passDescrip);
            if (user == null)
            {
                return new UserResponseDto()
                {
                    Token = "",
                    UserToken = new DataAccess.Entities.User(),
                };
            }

            var managementToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(keySecret);

            var tokenDescri = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.Email.ToString()),
                    new Claim(ClaimTypes.Role, user.Role),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = managementToken.CreateToken(tokenDescri);

            UserResponseDto userResponseDto = new UserResponseDto()
            {
                Token = managementToken.WriteToken(token),
                UserToken = user
            };

            return userResponseDto;
        }
    }
}
