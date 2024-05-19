using AutoMapper;
using ExamenTI.Business.DTOs;
using ExamenTI.Business.Interfaces;
using ExamenTI.Business.Util;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExamenTI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;
        protected ResponseApi _responseApi;
        private readonly IMapper _mapper;

        public UsersController(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            this._responseApi = new();
            _mapper = mapper;
        }

        //[Authorize(Roles = "admin")]
        [HttpGet]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUsers()
        {
            var lstUsers = _userServices.GetUsers();
            var lstUsersDto = new List<UsersDto>();

            foreach (var item in lstUsers)
            {
                lstUsersDto.Add(_mapper.Map<UsersDto>(item));
            }

            return Ok(lstUsersDto);
        }

        //[AllowAnonymous]
        [HttpPost("create")]
        [ProducesResponseType(201, Type = typeof(CreateUsersDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUsersDto createUsersDto)
        {
            bool validUserNameUnique = _userServices.IsUniqueUser(createUsersDto.Email);
            if (!validUserNameUnique)
            {
                _responseApi.StatusCode = HttpStatusCode.BadRequest;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add("This users already exists");
                return BadRequest(_responseApi);
            }

            var user = await _userServices.Create(createUsersDto);
            if (user == null)
            {
                _responseApi.StatusCode = HttpStatusCode.BadRequest;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add("Error al crear el registro");
                return BadRequest(_responseApi);
            }

            _responseApi.StatusCode = HttpStatusCode.OK;
            _responseApi.IsSuccess = true;
            return Ok(_responseApi);
        }
    }
}
