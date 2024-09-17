using MotoManagementSystemProject.Domain.DTOs;
using MotoManagementSystemProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoManagementSystemProject.Domain.Responses
{
    public class CustomResponses
    {
        public record UpdateResponse(bool Flag = false, string Message = null!);
        public record UpdateLocacaoResponse(bool Flag = false, string Message = null!, Locacao ConsultaLocacaoDTO = null!);
    }
}
