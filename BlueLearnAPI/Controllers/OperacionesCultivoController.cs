using Microsoft.AspNetCore.Mvc;
using BlueLearnAPI.Model;
using BlueLearnAPI.Services;
using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BlueLearnAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OperacionesCultivoController : ControllerBase
    {
        private readonly IOperacionesCultivoService _operacionesCultivoService;

        public OperacionesCultivoController(IOperacionesCultivoService operacionesCultivoService)
        {
            _operacionesCultivoService = operacionesCultivoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OperacionesCultivo>>> GetAll()
        {
            return Ok(await _operacionesCultivoService.GetAll());
        }

        [HttpGet("{IdOperacion}")] 
        public async Task<ActionResult<OperacionesCultivo>> GetOperacionesCultivo(int IdOperacion)
        {
            var OperacionesCultivo = await _operacionesCultivoService.GetOperacionesCultivo(IdOperacion);
            if(OperacionesCultivo == null)
            {
                return BadRequest("User not found");
            }
            return Ok(OperacionesCultivo);

        }

        [HttpPost]
        public async Task<ActionResult<OperacionesCultivo>> CreateOperacionesCultivo([FromBody] OperacionesCultivo operacionesCultivo)
        {
            if(operacionesCultivo == null)
            {
                return BadRequest("El objeto es nulo");
            }
            var newOperacionesCultivo = await _operacionesCultivoService.CreateOperacionesCultivo(operacionesCultivo.IdEstadoOperacion, operacionesCultivo.FechaOperacion, operacionesCultivo.Descripcion, operacionesCultivo.IdCultivo, operacionesCultivo.IdAgricultor);
            return Ok(newOperacionesCultivo);
        }

        [HttpPut("{IdOperacion}")]
        public async Task<ActionResult<OperacionesCultivo>> UpdateOperacionesCultivo(int IdOperacion, [FromBody] OperacionesCultivo UpdateOperacionesCultivo)
        {
            if(UpdateOperacionesCultivo == null || IdOperacion <= 0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar");
            }
            var updateOperacionesCultivo = await _operacionesCultivoService.UpdateOperacionesCultivo(IdOperacion, UpdateOperacionesCultivo.IdEstadoOperacion, UpdateOperacionesCultivo.FechaOperacion, UpdateOperacionesCultivo.Descripcion, UpdateOperacionesCultivo.IdCultivo, UpdateOperacionesCultivo.IdAgricultor);
            return Ok(updateOperacionesCultivo);
        }

        [HttpDelete("{IdOperacion}")]
        public async Task<ActionResult<OperacionesCultivo>> DeleteOperacionesCultivo(int IdOperacion)
        {
            if(IdOperacion <= 0)
            {
                return BadRequest("Id invalido para eliminar");
            }
            var DeletedOperacionesCultivo = await _operacionesCultivoService.DeleteOperacionesCultivo(IdOperacion);
            return Ok(DeletedOperacionesCultivo);
        }
    }
}
