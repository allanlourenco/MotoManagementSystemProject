using MotoManagementSystemProject.Domain.Entities;
using MotoManagementSystemProject.Domain.Interfaces.Repository;
using MotoManagementSystemProject.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MotoManagementSystemProject.Domain.Responses.CustomResponses;

namespace MotoManagementSystemProject.Service.Services
{
    public class MotoService(IMotoRepository motoRepository) : IMotoService
    {
        public async Task<Moto> CreateMotoAsync(Moto moto)
        {
            await motoRepository.AddAsync(moto);
            await motoRepository.SaveAsync();
            return await Task.FromResult(moto);
        }
        public async Task<Moto> GetMotoByIdAsync(string motoId)
        {
            var moto = await motoRepository.GetByIdAsync(motoId);
            return await Task.FromResult(moto);
        }

        public async Task<IEnumerable<Moto>> GetAllMotosAsync()
        {
            return await motoRepository.GetAllAsync();
        }

        public async Task<UpdateResponse> UpdatePlacaMotoAsync(string id, string placa)
        {
            var updatedMoto = await motoRepository.GetByIdAsync(id);
            if (updatedMoto != null)
            {
                updatedMoto.Placa = placa;

                await motoRepository.UpdateAsync(updatedMoto);
                await motoRepository.SaveAsync();
                return new UpdateResponse(true, "Placa modificada com sucesso");
            }
            return new UpdateResponse(false, "Dados inválidos");        
        }

        public async Task<bool> DeleteMotoAsync(string id)
        {
            var moto = await motoRepository.GetByIdAsync(id);
            if (moto != null)
            {
                await motoRepository.DeleteAsync(moto);
                await motoRepository.SaveAsync();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> EntityExistsAsync(string placa)
        {
            var itens = await motoRepository.FindAsync(x => x.Placa.Equals(placa));
            if(itens.Count() == 0)
            {
                return false;
            }
            return true;
        }
    }
}
