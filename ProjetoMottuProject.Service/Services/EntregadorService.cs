using MotoManagementSystemProject.Domain.Entities;
using MotoManagementSystemProject.Domain.Interfaces.Repository;
using MotoManagementSystemProject.Domain.Interfaces.Services;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MotoManagementSystemProject.Domain.Responses.CustomResponses;

namespace MotoManagementSystemProject.Service.Services
{
    public class EntregadorService(IEntregadorRepository entregadorRepository, IImageUploadService imageUploadService) : IEntregadorService
    {
        public async Task<Entregador> CreateEntregadorAsync(Entregador entregador)
        {
            entregador.ImagemCNH =  await imageUploadService.UploadImageAsync(entregador.ImagemCNH);
            await entregadorRepository.AddAsync(entregador);
            
            await entregadorRepository.SaveAsync();
            return await Task.FromResult(entregador);
        }

        public async Task<Entregador> GetEntregadorByIdAsync(string id)
        {
            var entregador = await entregadorRepository.GetByIdAsync(id);
            return await Task.FromResult(entregador);
        }

        public async Task UpdateFotoEntregadorAsync(string id, string foto)
        {
            var updatedEntregador = await entregadorRepository.GetByIdAsync(id);
            if (updatedEntregador != null)
            {
                var uploadFoto = await imageUploadService.UploadImageAsync(foto);
                if (uploadFoto != null)
                {
                    updatedEntregador.ImagemCNH = uploadFoto;

                    await entregadorRepository.UpdateAsync(updatedEntregador);
                    await entregadorRepository.SaveAsync();
                }
            }
        }

        public async Task<bool> EntityExistsAsync(string? cnh, string? cnpj)
        {
            if (!String.IsNullOrEmpty(cnh) || !String.IsNullOrEmpty(cnpj))
            {
                var itens = await entregadorRepository.FindAsync(x => x.Cnpj.Equals(cnpj) || x.NumeroCNH.Equals(cnh));
                if (itens.Count() == 0)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
