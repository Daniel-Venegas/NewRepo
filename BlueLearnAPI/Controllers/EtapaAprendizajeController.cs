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
    public class EtapaAprendizajeController : ControllerBase
    {

        private readonly IEtapaAprendizajeService _etapaAprendizajeService;

        public EtapaAprendizajeController(IEtapaAprendizajeService etapaAprendizajeService)
        {
            _etapaAprendizajeService = etapaAprendizajeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EtapaAprendizaje>>> GetAll()
        {
            return Ok(await _etapaAprendizajeService.GetAll());
        }

        [HttpGet("{IdEstado}")]
        public async Task<ActionResult<EtapaAprendizaje>> GetEtapaAprendizaje(int IdEstado)
        {
            var EtapaAprendizaje = await _etapaAprendizajeService.GetEtapaAprendizaje(IdEstado);
            if(EtapaAprendizaje == null)
            {
                return BadRequest("user not found");
            }
            return Ok(EtapaAprendizaje);
        }

        [HttpPost]
        public async Task<ActionResult<EtapaAprendizaje>> CreateEtapaAprendizaje([FromBody] EtapaAprendizaje etapaAprendizaje)
        {
            if(etapaAprendizaje == null)
            {
                return BadRequest("El objeto es nulo");
            }
            var newEtapaAprendizaje = await _etapaAprendizajeService.CreateEtapaAprendizaje(etapaAprendizaje.IdAgricultor, etapaAprendizaje.IdEtapa, etapaAprendizaje.FechaInit, etapaAprendizaje.FechaFin);
            return Ok(newEtapaAprendizaje);
        }

        [HttpPut("{IdEstado}")]
        public async Task<ActionResult<EtapaAprendizaje>> UpdateEtapaAprendizaje(int IdEstado, [FromBody] EtapaAprendizaje UpdateEtapaAprendizaje)
        {
            if(UpdateEtapaAprendizaje == null || IdEstado <= 0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar");
            }
            var updateEtapaAprendizaje = await _etapaAprendizajeService.UpdateEtapaAprendizaje(IdEstado, UpdateEtapaAprendizaje.IdAgricultor, UpdateEtapaAprendizaje.IdEtapa, UpdateEtapaAprendizaje.FechaInit, UpdateEtapaAprendizaje.FechaFin);
            return Ok(updateEtapaAprendizaje);
        }

        [HttpDelete("{IdEstado}")]
        public async Task<ActionResult<EtapaAprendizaje>> DeleteEtapaAprendizaje(int IdEstado)
        {
            if(IdEstado <= 0)
            {
                return BadRequest("Id invalido para eliminar");
            }
            var DeletedEtapaAprendizaje = await _etapaAprendizajeService.DeleteEtapaAprendizaje(IdEstado);
            return Ok(DeletedEtapaAprendizaje);
        }


    }


}
