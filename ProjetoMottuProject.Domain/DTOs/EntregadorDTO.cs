using MotoManagementSystemProject.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoManagementSystemProject.Domain.DTOs
{
    public class EntregadorDTO : EntregadorImagemCnhDTO
    {
        [Required]
        public string Identificador {  get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cnpj { get; set; }
        [Required]
        public DateTime Data_Nascimento { get; set; }
        [Required]
        public string Numero_CNH { get; set; }
        [Required]
        [ValidTipoCnh]
        public string Tipo_CNH { get; set; }
    }
}
