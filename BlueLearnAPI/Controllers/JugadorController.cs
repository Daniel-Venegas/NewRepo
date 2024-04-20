using Microsoft.AspNetCore.Mvc;
using BlueLearnAPI.Model;
using BlueLearnAPI.Services;
using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Runtime.CompilerServices;

namespace BlueLearnAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class JugadorController : ControllerBase
    {
        private readonly IJugadorService _jugadorService;

        public JugadorController(IJugadorService jugadorService)
        {
            _jugadorService = jugadorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Jugador>>> GetAll()
        {
            return Ok(await _jugadorService.GetAll());
        }

        [HttpGet("{IdJugador}")]
        public async Task<ActionResult<Jugador>> GetJugador(int IdJugador)
        {
            var Jugador = await _jugadorService.GetJugador(IdJugador);
            if(Jugador == null)
            {
                return BadRequest("User not found");
            }
            return Ok(Jugador);
        }

        [HttpPost]
        public async Task<ActionResult<Jugador>> CreateJugador([FromBody] Jugador jugador)
        {
            if(jugador == null)
            {
                return BadRequest("El objeto es normal");
            }
            var newJugador = await _jugadorService.CreateJugador(jugador.Puntaje, jugador.Nivel);
            return Ok(newJugador);
        }

        [HttpPut("{IdJugador}")]
        public async Task<ActionResult<Jugador>> UpdateJugador(int IdJugador, [FromBody] Jugador UpdateJugador)
        {
            if(UpdateJugador == null || IdJugador <= 0)
            {
                return BadRequest("Datos de entrada invalidos");
            }
            var updateJugador = await _jugadorService.UpdateJugador(IdJugador, UpdateJugador.Puntaje, UpdateJugador.Nivel);
            return Ok(updateJugador);
        }

        [HttpDelete("{IdJugador}")]
        public async Task<ActionResult<Jugador>> DeleteJugador(int IdJugador)
        {
            if(IdJugador <= 0)
            {
                return BadRequest("Id invalido para eliminar");
            }
            var DeletedJugador = await _jugadorService.DeleteJugador(IdJugador);
            return Ok(DeletedJugador);
        }
    }

    
}
