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
    public class EntregadoresController(IMapper mapper, IEntregadorService entregadorService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateEntregadorAsync(EntregadorDTO entregadorDTO)
        {
            try
            {
                if (await entregadorService.EntityExistsAsync(entregadorDTO.Numero_CNH, entregadorDTO.Cnpj))
                {
                    return BadRequest("Dados inválidos");
                }

                var entregador = mapper.Map<Entregador>(entregadorDTO);
                var createdEntregador = await entregadorService.CreateEntregadorAsync(entregador);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest("Dados inválidos");
            }
            
        }
        private async Task<EntregadorDTO> GetEntregadorByIdAsync(string id)
        {
            var entregador = await entregadorService.GetEntregadorByIdAsync(id);
           
            var entregadorDto = mapper.Map<EntregadorDTO>(entregador);
            return entregadorDto;
        }

        [HttpPost("{id}/cnh")]
        public async Task<IActionResult> UploadImageCnhAsync(string id, [FromBody] EntregadorImagemCnhDTO imageUploadDTO)
        {
            if (string.IsNullOrEmpty(imageUploadDTO.Imagem_CNH))
            {
                return BadRequest("Dados inválidos");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await entregadorService.UpdateFotoEntregadorAsync(id, imageUploadDTO.Imagem_CNH);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest("Dados inválidos");
            }
        }

    }
}
