using EmployeeManagement;

namespace Api.Models
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department?> GetDepartment(int id);
    }
}
