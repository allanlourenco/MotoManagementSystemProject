using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoManagementSystemProject.Domain.DTOs
{
    public class ConsultaLocacaoDTO : LocacaoDTO
    {
        public DateTime Data_Devolucao { get; set; }
    }
}
