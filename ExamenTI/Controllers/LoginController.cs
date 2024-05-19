using ExamenTI.Business.DTOs;
using ExamenTI.Business.Interfaces;
using ExamenTI.Business.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExamenTI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserServices _userServices;
        protected ResponseApi _responseApi;

        public LoginController(IUserServices userServices)
        {
            _userServices = userServices;
            this._responseApi = new();
        }
        //[AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(201, Type = typeof(UsersDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var responseLogin = await _userServices.UserLogin(userLoginDto);

            if (responseLogin.UserToken == null || string.IsNullOrEmpty(responseLogin.Token))
            {
                _responseApi.StatusCode = HttpStatusCode.BadRequest;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(_responseApi);
            }

            _responseApi.StatusCode = HttpStatusCode.OK;
            _responseApi.IsSuccess = true;
            _responseApi.Result = responseLogin;
            return Ok(_responseApi);
        }
    }
}
