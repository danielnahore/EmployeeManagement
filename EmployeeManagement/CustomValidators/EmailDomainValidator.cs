using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CustomValidators
{
    public class EmailDomainValidator : ValidationAttribute
    {
        public string AllowedDomain { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string[] strings = value.ToString().Split('@');
                if (strings.Length == 2 && strings[1].ToLower() == AllowedDomain.ToLower())
                {
                    return null;
                }

                return new ValidationResult(ErrorMessage, new[] {validationContext.MemberName} );
            }
            return null;
        }
    }
}
