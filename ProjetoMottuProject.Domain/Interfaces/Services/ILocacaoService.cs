using MotoManagementSystemProject.Domain.DTOs;
using MotoManagementSystemProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MotoManagementSystemProject.Domain.Responses.CustomResponses;

namespace MotoManagementSystemProject.Domain.Interfaces.Services
{
    public interface ILocacaoService
    {
        Task<Locacao> CreateLocacaoAsync(Locacao locacao);
        Task<Locacao> GetLocacaoByIdAsync(string id);
        Task<IEnumerable<Locacao>> GetLocacoesByMotoIdAsync(string motoId);
        Task<UpdateLocacaoResponse> UpdateDataDevolucaoAsync(string id, DateTime data_Devolucao);
    }
}
