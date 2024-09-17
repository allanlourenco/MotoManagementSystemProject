using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MotoManagementSystemProject.Domain.DTOs;
using MotoManagementSystemProject.Domain.Entities;
using MotoManagementSystemProject.Domain.Interfaces.Services;
using MotoManagementSystemProject.Service.Services;

namespace MotoManagementSystemProject.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocacaoController(IMapper mapper, ILocacaoService locacaoService, IEntregadorService entregadorService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateLocacaoAsync(LocacaoDTO locacaoDTO)
        {
            try
            {
                var locacao = mapper.Map<Locacao>(locacaoDTO);
                var createdLocacao = await locacaoService.CreateLocacaoAsync(locacao);
                return Created();
            }
            catch (Exception)
            {
                return BadRequest("Dados inválidos");
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultaLocacaoDTO>> GetLocacaoByIdAsync(string id)
        {
            var locacao = await locacaoService.GetLocacaoByIdAsync(id);
            if (locacao == null)
            {
                return NotFound("Dados não encontrados");
            }
            var locacaoDto = mapper.Map<ConsultaLocacaoDTO>(locacao);
            return Ok(locacaoDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDataDevolucaoAsync(string id, [FromBody] LocacaoDataDevolucaoDTO dto)
        {
            

            var response = await locacaoService.UpdateDataDevolucaoAsync(id, dto.Data_Devolucao);

            if (response.Flag)
                return Ok(new { response.Message, response.ConsultaLocacaoDTO });
            else return BadRequest(response.Message);
        }
    }
}
