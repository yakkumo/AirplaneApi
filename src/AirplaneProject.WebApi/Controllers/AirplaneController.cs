using AirplaneProject.Application.Dtos;
using AirplaneProject.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AirplaneProject.WebApi.Controllers
{
    public class AirplaneController : ControllerBase
    {
        private readonly IAirplaneAppService _AirplaneAppService;

        public AirplaneController(
            IAirplaneAppService AirplaneAppService)
        {
            _AirplaneAppService = AirplaneAppService;
        }

        [HttpGet]
        [Route("Airplane")]
        public async Task<IActionResult> Get()
        {
            var result = await _AirplaneAppService.Listar();
            return Ok(result.Data);
        }

        [HttpGet]
        [Route("Airplane/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _AirplaneAppService.Obter(id);

            return Ok(result);
        }

        [Route("Airplane")]
        [HttpPost]
        public async Task<IActionResult> Incluir([FromBody]AirplaneIncluirDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(dto);
            }

            var result = await _AirplaneAppService.Incluir(dto);

            return Ok(result);

        }
        
        [HttpPut]
        //[Authorize(Policy = "CanWriteAirplaneData")]
        [Route("Airplane")]
        public async Task<IActionResult> Put([FromBody]AirplaneEditarDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(dto);
            }

            var result = await _AirplaneAppService.Editar(dto);

            return Ok(result);
        }

        [HttpDelete]
        //[Authorize(Policy = "CanRemoveAirplaneData")]
        [Route("Airplane/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _AirplaneAppService.Excluir(id);

            return Ok(result);
        }
    }
}