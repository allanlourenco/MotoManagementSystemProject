using MotoManagementSystemProject.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoManagementSystemProject.Domain.Entities
{
    public class Locacao : BaseEntityWithKey
    {
        public TipoPlano TipoPlano { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now.AddDays(1);
        public DateTime DataTermino { get;set; }
        public DateTime DataPrevisaoTermino { get; set; }
        public DateTime DataDevolucao { get; set; }
        public double ValorDiaria { get; set; }
        public string MotoId { get; set; }
        public Moto Moto { get; set; }
        public string EntregadorId { get; set; }
        public Entregador Entregador { get; set; }
        public double ValorTotal {  get; set; }
    }
}
