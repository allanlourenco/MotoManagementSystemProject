using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MotoManagementSystemProject.Domain.DTOs;
using MotoManagementSystemProject.Domain.Entities;
using MotoManagementSystemProject.Domain.Interfaces.Services;
using MotoManagementSystemProject.Service.Services;
using System.Threading.Tasks;

namespace MotoManagementSystemProject.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotosController(IMotoService motoService, IMapper mapper, ILocacaoService locacaoService, IQueueService queueService ) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateMotoAsync(MotoDTO motoDTO)
        {
            try
            {
                if (await motoService.EntityExistsAsync(motoDTO.Placa))
                {
                    return BadRequest("Dados inválidos");
                }

                var moto = mapper.Map<Moto>(motoDTO);
                var createdMoto = await motoService.CreateMotoAsync(moto);
                queueService.SendMessage($"Moto Cadastrada: {createdMoto.Id}");
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest("Dados inválidos");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MotoDTO>> GetMotoByIdAsync(string id)
        {
            try
            {
                var moto = await motoService.GetMotoByIdAsync(id);
                if (moto == null)
                {
                    return NotFound("Moto não encontrada");
                }
                var motoDto = mapper.Map<MotoDTO>(moto);
                return Ok(motoDto);
            }
            catch (Exception)
            {
                return BadRequest("Request mal formada");
            }
            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotoDTO>>> GetAllMotosAsync([FromQuery] string? placa)
        {
            var motos = await motoService.GetAllMotosAsync();
            if (placa != null)
                motos = motos.Where(x => x.Placa.Equals(placa));
            var motosDTO = mapper.Map<List<MotoDTO>>(motos);
            return Ok(motos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlacaMotoAsync(string id, [FromBody]MotoUpdatePlacaDTO dto)
        {
            if (await motoService.EntityExistsAsync(dto.Placa))
            {
                return BadRequest("Dados inválidos");
            }

            var response = await motoService.UpdatePlacaMotoAsync(id, dto.Placa);

            if(response.Flag)
                return Ok(response.Message);
            else return BadRequest(response.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotoAsync(string id)
        {
            var locacoes = await locacaoService.GetLocacoesByMotoIdAsync(id);
            if (locacoes.Count() > 0)
                return BadRequest("Existem locações para esta moto cadastrada");

            var deleted = await motoService.DeleteMotoAsync(id);
            if (!deleted)
            {
                return BadRequest("Dados inválidos");
            }
            return Ok();
        }
    }
}
