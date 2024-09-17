using MotoManagementSystemProject.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoManagementSystemProject.Domain.DTOs
{
    public class LocacaoDTO
    {
        public string Identificador { get; set; }
        public string Entregador_Id { get; set; }
        public string Moto_Id { get; set; }
        [Required]
        public DateTime Data_Inicio { get; set; }
        [Required]
        public DateTime Data_Termino { get; set; }
        [Required]
        public DateTime Data_Previsao_Termino { get; set; }
        public TipoPlano Plano {  get; set; }
    }
}
