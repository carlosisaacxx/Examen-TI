using ExamenTI.Business.DTOs;
using ExamenTI.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamenTI.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices _clientServices;
        public ClientController(IClientServices clientServices)
        {
            _clientServices = clientServices;
        }

        [AllowAnonymous]
        //[ResponseCache(Duration = 20)]
        //[ResponseCache(CacheProfileName = "Default20seconds")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetAllClient/")]
        public IActionResult GetAllClient() { 
            var response = _clientServices.GetAllClients();
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("GetClientById/{clientId:int}", Name = "GetClientById")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetClientById(int clientId) {
            var response = _clientServices.GetClientById(clientId);
            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("AddClient/")]
        [ProducesResponseType(201, Type = typeof(ClientDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddClient([FromBody] CreateClientDto createClientDto) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (createClientDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_clientServices.ExistClientByName(createClientDto.Firstname, createClientDto.Surname)) {
                ModelState.AddModelError("", "Exist already Client's Name same");
                return StatusCode(404, ModelState);
            }

            var client = _clientServices.AddClient(createClientDto);
            if (client == null) {
                ModelState.AddModelError("", $"Ocurrio un problema al guardar el cliente{client.Firstname + " " + client.Surname}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetClientById", new { clientId = client.Id }, client);
        }

        [Authorize(Roles = "admin")]
        [HttpPatch("UpdatePatchClient/{clientId:int}", Name = "UpdatePatchClient")]
        [ProducesResponseType(201, Type = typeof(ClientDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePatchClient(int clientId, [FromBody] ClientDto clientDto) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (clientDto == null || clientId != clientDto.Id)
            {
                return BadRequest(ModelState);
            }

            var client = _clientServices.UpdateClient(clientDto);
            if (client == null)
            {
                ModelState.AddModelError("", $"Ocurrio un problema en actualizar el cliente{clientDto.Firstname + " " + clientDto.Surname}");
            }

            return NoContent();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("DeleteClient/{clientId:int}", Name = "DeleteClient")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteClient(int clientId) {
            if (!_clientServices.ExistClientById(clientId)) {
                return NotFound();
            }

           var client = _clientServices.GetClientById(clientId);
            if (client != null && !_clientServices.DeleteClient(client))
            {
                ModelState.AddModelError("", $"Ocurrio un problema al borrar el cliente{client.Firstname + " " + client.Surname}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
