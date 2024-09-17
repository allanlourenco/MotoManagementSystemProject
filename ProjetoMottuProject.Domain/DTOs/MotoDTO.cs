using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoManagementSystemProject.Domain.DTOs
{
    public class MotoDTO
    {
        [Required]
        public string Identificador { get; set; }
        [Required]
        public int Ano { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Placa { get; set; }
    }
}
