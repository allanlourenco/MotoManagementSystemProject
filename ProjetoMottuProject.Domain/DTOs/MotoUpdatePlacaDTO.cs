using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoManagementSystemProject.Domain.DTOs
{
    public class MotoUpdatePlacaDTO
    {
        [Required]
        public string Placa {  get; set; }
    }
}
