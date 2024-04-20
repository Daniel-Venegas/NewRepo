using Microsoft.AspNetCore.Mvc;
using BlueLearnAPI.Model;
using BlueLearnAPI.Services;
using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;


namespace BlueLearnAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DescripcionMonitoreoController : ControllerBase
    {
        private readonly IDescripcionMonitoreoService _descripcionMonitoreoService;

        public DescripcionMonitoreoController(IDescripcionMonitoreoService descripcionMonitoreoService)
        {
            _descripcionMonitoreoService = descripcionMonitoreoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DescripcionMonitoreo>>> GetAll()
        {
            return Ok(await _descripcionMonitoreoService.GetAll());
        }

        [HttpGet("{IdDescripcionMonitoreo}")]
        public async Task<ActionResult<DescripcionMonitoreo>> GetDescripcionMonitoreo(int IdDescripcionMonitoreo)
        {
            var DescripcionMonitoreo = await _descripcionMonitoreoService.GetDMonitoreo(IdDescripcionMonitoreo);
            if(DescripcionMonitoreo == null)
            {
                return BadRequest("User not found");
            }
            return Ok(DescripcionMonitoreo);
        }

        [HttpPost]
        public async Task<ActionResult<DescripcionMonitoreo>> CreateDescripcionMonitoreo([FromBody] DescripcionMonitoreo descripcionMonitoreo)
        {
            if(descripcionMonitoreo == null)
            {
                return BadRequest("El objeto es nulo");
            }
            var newDescripcionMonitoreo = await _descripcionMonitoreoService.CreateDMonitoreo(descripcionMonitoreo.Variable, descripcionMonitoreo.UnidadMedida);
            return Ok(newDescripcionMonitoreo);
        }

        [HttpPut("{IdDescripcionMonitoreo}")]
        public async Task<ActionResult<DescripcionMonitoreo>> UpdateDescripcionMonitoreo(int IdDescripcionMonitoreo, [FromBody] DescripcionMonitoreo UpdateDescripcionMonitoreo)
        {
            if(UpdateDescripcionMonitoreo == null || IdDescripcionMonitoreo <= 0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar");
            }
            var updateDescripcionMonitoreo = await _descripcionMonitoreoService.UpdateDMonitoreo(IdDescripcionMonitoreo, UpdateDescripcionMonitoreo.Variable, UpdateDescripcionMonitoreo.UnidadMedida);
            return Ok(updateDescripcionMonitoreo);
        }

        [HttpDelete("{IdDescripcionMonitoreo}")]
        public async Task<ActionResult<DescripcionMonitoreo>> DeleteDescripcionMonitoreo(int IdDescripcionMonitoreo)
        {
            if(IdDescripcionMonitoreo <= 0)
            {
                return BadRequest("Id invalido para eliminar");
            }
            var DeletedDescripcionMonitoreo = await _descripcionMonitoreoService.DeleteDMonitoreo(IdDescripcionMonitoreo);
            return Ok(DeletedDescripcionMonitoreo);
        }
    }


}
