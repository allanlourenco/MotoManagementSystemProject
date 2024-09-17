using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoManagementSystemProject.Domain.Attributes
{
    public class AllowedFileTypesBase64Attribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string base64File)
            {
                byte[] fileBytes;
                try
                {
                    fileBytes = Convert.FromBase64String(base64File);
                }
                catch (FormatException)
                {
                    return new ValidationResult("O arquivo não está em um formato Base64 válido.");
                }

                if (IsPng(fileBytes) || IsBmp(fileBytes))
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult("Apenas arquivos do tipo BMP ou PNG são permitidos.");
            }

            return new ValidationResult("Arquivo inválido.");
        }

        private bool IsPng(byte[] fileBytes)
        {
            byte[] pngSignature = new byte[] { 0x89, 0x50, 0x4E, 0x47 };
            return fileBytes.Take(4).SequenceEqual(pngSignature);
        }

        private bool IsBmp(byte[] fileBytes)
        {
            byte[] bmpSignature = new byte[] { 0x42, 0x4D };
            return fileBytes.Take(2).SequenceEqual(bmpSignature);
        }
    }
}
