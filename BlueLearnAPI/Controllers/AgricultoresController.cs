using Microsoft.AspNetCore.Mvc;
using BlueLearnAPI.Model;
using BlueLearnAPI.Services;
using Azure.Core;

namespace BlueLearnAPI.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
   
    public class AgricultoresController : ControllerBase
    {

        private readonly IAgricultoresService _agricultoresService;

        public AgricultoresController (IAgricultoresService agricultoresService)
        {
            _agricultoresService = agricultoresService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Agricultores>>> GetAll()
        {
            return Ok(await _agricultoresService.GetAll());
        }

        [HttpGet("{IdAgricultor}")]
        public async Task<ActionResult<Agricultores>> GetAgricultores(int IdAgricultor)
        {
            var Agricultores = await _agricultoresService.GetAgricultor(IdAgricultor);
            if(Agricultores == null)
            {
                return BadRequest("user not found");
            }
            return Ok(Agricultores);
        }

        [HttpPost]
        public async Task<ActionResult<Agricultores>> CreateAgricultores([FromBody] Agricultores agricultores)
        {
            if(agricultores == null)
            {
                return BadRequest("El objeto agricultores es nulo");
            }
            var newAgricultores = await _agricultoresService.CreateAgricultor(agricultores.IdJugador, agricultores.Nombres, agricultores.Apellidos, agricultores.Direccion, agricultores.Contacto, agricultores.Jugador);
            return Ok(newAgricultores);


        }
        [HttpPut("{IdAgricultor}")]
        public async Task<ActionResult<Agricultores>> UpdateAgricultores(int IdAgricultor, [FromBody] Agricultores UpdateAgricultores)
        {
            if(UpdateAgricultores == null || IdAgricultor <= 0)
            {
                return BadRequest("Datos de entrada inválidos para actualizar");
            }
            var updateAgricultores = await _agricultoresService.UpdateAgricultor(IdAgricultor, UpdateAgricultores.IdJugador, UpdateAgricultores.Nombres, UpdateAgricultores.Apellidos, UpdateAgricultores.Direccion, UpdateAgricultores.Contacto);
            return Ok(updateAgricultores);
        }



        [HttpDelete("{IdAgricultor}")]
        public async Task<ActionResult<Agricultores>> DeleteAgricultores(int IdAgricultor)
        {
           if(IdAgricultor <= 0)
            {
                return BadRequest("Id invalaido para eliminar");
            }
            var DeletedAgricultores = await _agricultoresService.DeleteAgricultor(IdAgricultor);
            return Ok(DeletedAgricultores);
        }
    }
}
