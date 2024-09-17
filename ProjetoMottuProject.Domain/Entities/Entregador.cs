using MotoManagementSystemProject.Domain.Attributes;
using MotoManagementSystemProject.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoManagementSystemProject.Domain.Entities
{
    public class Entregador : BaseEntityWithKey
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NumeroCNH { get; set; }
        
        public string TipoCNH { get; set; }
        public string ImagemCNH { get; set; }
    }
}
