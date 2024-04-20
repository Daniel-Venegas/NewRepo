using Microsoft.AspNetCore.Mvc;
using BlueLearnAPI.Model;
using BlueLearnAPI.Services;
using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BlueLearnAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TemporadaController : ControllerBase
    {
        private readonly TemporadaService _temporadaService;

        public TemporadaController(TemporadaService temporadaService)
        {
            _temporadaService = temporadaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Temporadas>>> GetAll()
        {
            return Ok(await _temporadaService.GetAll());

        }

        [HttpGet("{IdTemporada}")]
        public async Task<ActionResult<Temporadas>> GetTemporadas(int IdTemporada)
        {
            var Temporadas = await _temporadaService.GetTemporadas(IdTemporada);
            if(Temporadas == null)
            {
                return BadRequest("User not found");

            }
            return Ok(Temporadas);
        }

        [HttpPost]
        public async Task<ActionResult<Temporadas>> CreateTemporadas([FromBody] Temporadas temporadas)
        {
            if(temporadas == null)
            {
                return BadRequest("El objeto es nulo");
            }
            var newTemporadas = await _temporadaService.CreateTemporadas(temporadas.Temporada);
            return Ok(newTemporadas);
        }

        [HttpPut("{IdTemporada}")]
        public async Task<ActionResult<Temporadas>> UpdateTemporadas(int IdTemporada, [FromBody] Temporadas UpdateTemporadas)
        {
            if(UpdateTemporadas == null || IdTemporada <= 0)
            {
                return BadRequest("Datos de entrada no validos para actualizar");
            }
            var updateTemporadas = await _temporadaService.UpdateTemporadas(IdTemporada, UpdateTemporadas.Temporada);
            return Ok(updateTemporadas);
        }

        [HttpDelete("{IdTemporada}")]
        public async Task<ActionResult<Temporadas>> DeleteTemporadas(int IdTemporada)
        {
            if(IdTemporada <= 0)
            {
                return BadRequest("Id invalido para eliminar");
            }
            var DeletedTemporadas = await _temporadaService.DeleteTemporadas(IdTemporada);
            return Ok(DeletedTemporadas);
        }
    }
}
