using Models.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "First name must be provided.")]
        [MinLength(2)]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name must be provided.")]
        public string? LastName { get; set; }
        [Required]
        [EmailAddress]
        [EmailDomainValidator(AllowedDomain = "gmail.com", ErrorMessage = "Only gmail.com is allowed.")]
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public Gender? Gender { get; set; }
        public int DepartmentId { get; set; }
        public string? PhotoPath { get; set; }
        public Department? Department { get; set; }
    }
}
