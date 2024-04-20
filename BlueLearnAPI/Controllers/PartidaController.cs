using Microsoft.AspNetCore.Mvc;
using BlueLearnAPI.Model;
using BlueLearnAPI.Services;
using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BlueLearnAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PartidaController : ControllerBase
    {
        private readonly IPartidaService _partidaService;

        public PartidaController(IPartidaService partidaService)
        {
            _partidaService = partidaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Partida>>> GetAll()
        {
            return Ok(await _partidaService.GetAll());
        }

        [HttpGet("{IdPartida}")]
        public async Task<ActionResult<Partida>> GetPartida(int IdPartida)
        {
            var Partida = await _partidaService.GetPartida(IdPartida);
            if(Partida == null)
            {
                return BadRequest("User not found");
            }
            return Ok(Partida);
        }

        [HttpPost]
        public async Task<ActionResult<Partida>> CreatePartida([FromBody] Partida partida)
        {
            if(partida == null)
            {
                return BadRequest("El objeto es nulo");
            }
            var newPartida = await _partidaService.CreatePartida(partida.NombrePartida, partida.IdJugador, partida.IdLogro, partida.PuntajePartida);
            return Ok(newPartida);
        }

        [HttpPut("{IdPartida}")]
        public async Task<ActionResult<Partida>> UpdatePartida (int IdPartida, [FromBody] Partida UpdatePartida)
        {
            if(UpdatePartida == null || IdPartida <= 0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar");
            }
            var updatePartida = await _partidaService.UpdatePartida(IdPartida, UpdatePartida.NombrePartida, UpdatePartida.IdJugador, UpdatePartida.IdLogro, UpdatePartida.PuntajePartida);
            return Ok(updatePartida);
        }

        [HttpDelete("{IdPartida}")]
        public async Task<ActionResult<Partida>> DeletePartida(int IdPartida)
        {
            if(IdPartida <= 0)
            {
                return BadRequest("Id invalido para eliminar");
            }
            var DeletedPartida = await _partidaService.DeletePartida(IdPartida);
            return Ok(DeletedPartida);
        }


    }
}
