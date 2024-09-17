using MotoManagementSystemProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MotoManagementSystemProject.Domain.Responses.CustomResponses;

namespace MotoManagementSystemProject.Domain.Interfaces.Services
{
    public interface IMotoService
    {
        Task<Moto> CreateMotoAsync(Moto moto);
        Task<bool> DeleteMotoAsync(string id);
        Task<IEnumerable<Moto>> GetAllMotosAsync();
        Task<Moto> GetMotoByIdAsync(string motoId);
        Task<UpdateResponse> UpdatePlacaMotoAsync(string id, string placa);
        Task<bool> EntityExistsAsync(string placa);
    }
}
