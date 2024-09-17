using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoManagementSystemProject.Domain.Attributes
{
    public class ValidTipoCnhAttribute : ValidationAttribute
    {
        private readonly string[] _validStatuses = { "A", "B", "A+B" };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !_validStatuses.Contains(value.ToString()))
            {
                return new ValidationResult($"O tipo da CNH deve ser um dos seguintes: {string.Join(", ", _validStatuses)}");
            }

            return ValidationResult.Success;
        }
    }
}
