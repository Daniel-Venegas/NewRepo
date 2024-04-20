using Microsoft.AspNetCore.Mvc;
using BlueLearnAPI.Model;
using BlueLearnAPI.Services;
using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Globalization;

namespace BlueLearnAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EstadoCultivoController : ControllerBase
    {

       

        private readonly IEstadoCultivoService _estadoCultivoService;

        public EstadoCultivoController(IEstadoCultivoService estadoCultivoService)
        {
            _estadoCultivoService = estadoCultivoService;
        }
        [HttpGet]
        public async Task<ActionResult<List<EstadoCultivo>>> GetAll()
        {
            return Ok(await _estadoCultivoService.GetAll());    
        }


        [HttpGet("{IdEstadoCultivo}")]
        public async Task<ActionResult<EstadoCultivo>> GetEstadoCultivo(int IdEstadoCultivo)
        {
            var EstadoCultivo = await _estadoCultivoService.GetEstadoCultivo(IdEstadoCultivo);
            if(EstadoCultivo == null)
            {
                return BadRequest("User not found");
            }
            return Ok(EstadoCultivo);
        }

        [HttpPost]
        public async Task<ActionResult<EstadoCultivo>> CreateEstadoCultivo([FromBody] EstadoCultivo estadoCultivo)
        {
            if(estadoCultivo == null)
            {
                return BadRequest("El objeto es nulo");

            }
            var newEstadoCultivo = await _estadoCultivoService.CreateEstadoCultivo(estadoCultivo.Descripcion);
            return Ok(newEstadoCultivo);
        }

        [HttpPut("{IdEstadoCultivo}")]
        public async Task<ActionResult<EstadoCultivo>> UpdateEstadoCultivo(int IdEstadoCultivo, [FromBody] EstadoCultivo UpdateEstadoCultivo)
        {
            if(UpdateEstadoCultivo == null || IdEstadoCultivo <= 0)
            {
                return BadRequest("Datos de entrada invlaidos para actualizar");
            }
            var updateEstadoCultivo = await _estadoCultivoService.UpdateEstadoCultivo(IdEstadoCultivo, UpdateEstadoCultivo.Descripcion);
            return Ok(updateEstadoCultivo);
        }


        [HttpDelete("{IdEstadoCultivo}")]
        public async Task<ActionResult<EstadoCultivo>> DeleteEstadoCultivo(int IdEstadoCultivo)
        {
            if(IdEstadoCultivo <= 0)
            {
                return BadRequest("Id invalido para eliminar");
            }
            var DeletedEstadoCultivo = await _estadoCultivoService.DeleteEstadoCultivo(IdEstadoCultivo);
            return Ok(DeletedEstadoCultivo);
        }
    }
}
