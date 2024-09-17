using MotoManagementSystemProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoManagementSystemProject.Domain.Interfaces.Services
{
    public interface IEntregadorService
    {
        Task<Entregador> CreateEntregadorAsync(Entregador entregador);
        Task<Entregador> GetEntregadorByIdAsync(string id);
        Task UpdateFotoEntregadorAsync(string id, string imageUrl);
        Task<bool> EntityExistsAsync(string? cnh, string? cnpj);
    }
}
