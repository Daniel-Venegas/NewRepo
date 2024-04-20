using Microsoft.AspNetCore.Mvc;
using BlueLearnAPI.Model;
using BlueLearnAPI.Services;
using Azure.Core;

namespace BlueLearnAPI.Controllers
{

    [ApiController]

    [Route("api/[controller]")]
    public class CosechasController : ControllerBase
    {

        private readonly ICosechasService _cosechasService;

        public CosechasController(ICosechasService cosechasService)
        {
            _cosechasService = cosechasService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Cosechas>>> GetAll()
        {
            return Ok(await _cosechasService.GetAll());
        }

        [HttpGet("{IdCosecha}")]
        public async Task<ActionResult<Cosechas>> GetCosechas(int IdCosecha)
        {
            var Cosechas = await _cosechasService.GetCosechas(IdCosecha);
            if(Cosechas == null)
            {
                return BadRequest("User not found");

            }
            return Ok(Cosechas);    
        }

        [HttpPost]
        public async Task<ActionResult<Cosechas>> CreateCosechas([FromBody] Cosechas cosechas)
        {
            if(cosechas == null)
            {
                return BadRequest("El objeto cosechas es nulo");
            }
            var newCosechas = await _cosechasService.CreateCosechas(cosechas.FechaCosecha, cosechas.CantidadRecogida, cosechas.IdCultivo, cosechas.IdTemporada);
            return Ok(newCosechas);
        }

        [HttpPut("{IdCosecha}")]
        public async Task<ActionResult<Cosechas>> UpdateCosechas(int IdCosechas, [FromBody] Cosechas UpdateCosechas)
        {
            if(UpdateCosechas == null || IdCosechas <= 0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar");
            }
            var updateCosechas = await _cosechasService.UpdateCosechas(IdCosechas, UpdateCosechas.FechaCosecha, UpdateCosechas.CantidadRecogida, UpdateCosechas.IdCultivo, UpdateCosechas.IdTemporada);
            return Ok(updateCosechas);
        }

        [HttpDelete("{IdCosechas}")]
        public async Task<ActionResult<Cosechas>> DeleteCosechas(int IdCosechas)
        {
            if(IdCosechas <= 0)
            {
                return BadRequest("Id invalido para eliminar");

            }
            var DeletedCosechas = await _cosechasService.DeleteCosechas(IdCosechas);
            return Ok(DeletedCosechas);
        }

    }
}
