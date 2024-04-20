using Microsoft.AspNetCore.Mvc;
using BlueLearnAPI.Model;
using BlueLearnAPI.Services;
using Azure.Core;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace BlueLearnAPI.Controllers
{


    [ApiController]

    [Route("api/[controller]")]
    public class CamposController : ControllerBase
    {

        private readonly ICampoService _campoService;

        public CamposController(ICampoService campoService)
        {
            _campoService = campoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Campos>>> GetAll()
        {
            return Ok(await _campoService.GetAll());
        }

        [HttpGet("{IdCampos}")]
        public async Task<ActionResult<Campos>> GetCampos(int IdAgricultor)
        {
            var Campos = await _campoService.GetCampos(IdAgricultor);
            if (Campos == null)
            {
                return BadRequest("user not found");
            }
            return Ok(Campos);
        }

        [HttpPost]
        public async Task<ActionResult<Campos>> CreateCampos([FromBody] Campos campos)
        {
            if (campos == null)
            {
                return BadRequest("El objeto agricultores es nulo");
            }
            var newCampos = await _campoService.CreateCampos(campos.NombreCampo,campos.Ubicacion, campos.Tamano);
            return Ok(newCampos);


        }
        [HttpPut("{IdCampos}")]
        public async Task<ActionResult<Campos>> UpdateCampos(int IdCampo, [FromBody] Campos UpdateCampos)
        {
            if(UpdateCampos == null || IdCampo <= 0)
            {
                return BadRequest("Datos invalidos");
            }
            var updateCampos = await _campoService.UpdateCampos(IdCampo, UpdateCampos.NombreCampo, UpdateCampos.Ubicacion, UpdateCampos.Tamano);
            return Ok(updateCampos);
        }



        [HttpDelete("{IdCampos}")]
        public async Task<ActionResult<Campos>> DeleteCampos(int IdCampo)
        {
            if (IdCampo <= 0)
            {
                return BadRequest("Id invalido para eliminar");
            }
            var DeletedCampos = await _campoService.DeleteCampos(IdCampo);
            return Ok(DeletedCampos);
        }
    }
}
