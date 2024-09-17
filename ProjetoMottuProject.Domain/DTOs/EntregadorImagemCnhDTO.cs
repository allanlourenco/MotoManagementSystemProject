using MotoManagementSystemProject.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoManagementSystemProject.Domain.DTOs
{
    public class EntregadorImagemCnhDTO
    {
        [Required]
        [AllowedFileTypesBase64]
        public string Imagem_CNH { get; set; }
    }
}
