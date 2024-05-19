using ExamenTI.Business.DTOs;
using ExamenTI.Business.Interfaces;
using ExamenTI.Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenTI.Controllers
{
    [Route("api/store")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreServices _storeServices;
        public StoreController(IStoreServices storeServices)
        {
            _storeServices = storeServices;
        }

        //[AllowAnonymous]
        //[ResponseCache(Duration = 20)]
        //[ResponseCache(CacheProfileName = "Default20seconds")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetAllStores/")]
        public IActionResult GetAllStores()
        {
            var response = _storeServices.GetAllStores();
            return Ok(response);
        }

        //[AllowAnonymous]
        [HttpGet("GetStoreById/{storeId:int}", Name = "GetStoreById")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetStoreById(int storeId)
        {
            var response = _storeServices.GetStoreById(storeId);
            return Ok(response);
        }

        //[Authorize(Roles = "admin")]
        [HttpPost("AddStore/")]
        [ProducesResponseType(201, Type = typeof(StoreDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddStore([FromBody] CreateStoreDto CreateStoreDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (CreateStoreDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_storeServices.ExistStoreByBranch(CreateStoreDto.Branch))
            {
                ModelState.AddModelError("", "Ya existe esta sucursal");
                return StatusCode(404, ModelState);
            }

            var store = _storeServices.AddStore(CreateStoreDto);
            if (store == null)
            {
                ModelState.AddModelError("", $"Ocurrio un problema al guardar la sucursal{CreateStoreDto.Branch}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetStoreById", new { storeId = store.Id }, store);
        }

        //[Authorize(Roles = "admin")]
        [HttpPatch("UpdatePatchStore/{storeId:int}", Name = "UpdatePatchStore")]
        [ProducesResponseType(201, Type = typeof(StoreDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePatchStore(int storeId, [FromBody] StoreDto StoreDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (StoreDto == null || storeId != StoreDto.Id)
            {
                return BadRequest(ModelState);
            }

            var store = _storeServices.UpdateStore(StoreDto);
            if (store == null)
            {
                ModelState.AddModelError("", $"Ocurrio un problema en actualizar la sucursal{StoreDto.Branch}");
            }

            return NoContent();
        }

        //[Authorize(Roles = "admin")]
        [HttpDelete("DeleteStore/{storeId:int}", Name = "DeleteStore")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteStore(int storeId)
        {
            if (!_storeServices.ExistStoreById(storeId))
            {
                return NotFound();
            }

            var store = _storeServices.GetStoreById(storeId);
            if (store != null && !_storeServices.DeleteStore(store))
            {
                ModelState.AddModelError("", $"Ocurrio un problema al borrar la sucursal{store.Branch}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
