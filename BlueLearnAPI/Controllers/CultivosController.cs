using Microsoft.AspNetCore.Mvc;
using BlueLearnAPI.Model;
using BlueLearnAPI.Services;
using Azure.Core;


namespace BlueLearnAPI.Controllers
{

    [ApiController]

    [Route("api/[controller]")]
    public class CultivosController : ControllerBase
    {
        private readonly ICultivosService _cultivosService;

        public CultivosController(ICultivosService cultivosService)
        {
            _cultivosService = cultivosService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Cultivos>>> GetAll()
        {
            return Ok(await _cultivosService.GetAll());
        }

        

        [HttpGet("{IdCultivo}")]
        public async Task<ActionResult<Cultivos>> GetCultivos(int IdCultivo)
        {
            var Cultivos = await _cultivosService.GetCultivos(IdCultivo);
            if(Cultivos == null)
            {
                return BadRequest("User not found");
            }
            return Ok(Cultivos);
        }


        [HttpPost]
        public async Task<ActionResult<Cultivos>> CreateCultivos([FromBody] Cultivos cultivos)
        {
            if(cultivos == null)
            {
                return BadRequest("El objeto cultivo es nulo.");
            }
            var newCultivos = await _cultivosService.CreateCultivos(cultivos.FechaPlantacion, cultivos.IdEstadoCultivo, cultivos.IdCampo);
            return Ok(newCultivos);
        }

        [HttpPut("{IdCultivo}")]
        public async Task<ActionResult<Cultivos>> UpdateCultivos(int IdCultivo, [FromBody] Cultivos UpdateCultivos)
        {
            if(UpdateCultivos == null || IdCultivo <= 0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar");
            }
            var updateCultivos = await _cultivosService.UpdateCultivos(IdCultivo, UpdateCultivos.FechaPlantacion, UpdateCultivos.IdEstadoCultivo, UpdateCultivos.IdCampo);
            return Ok(updateCultivos);
        }

        [HttpDelete("{IdCultivo}")]
        public async Task<ActionResult<Cultivos>> DeleteCultivos(int IdCultivo)
        {
            if(IdCultivo <= 0)
            {
                return BadRequest("Id invalido para eliminar");
            }
            var DeletedCultivos = await _cultivosService.DeleteCultivos(IdCultivo);
            return Ok(DeletedCultivos);
        }
        
        
    }
}
