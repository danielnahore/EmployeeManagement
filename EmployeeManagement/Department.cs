using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
