using EmployeeManagement;
using System.Threading.Tasks;


namespace Api.Models
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> Search(string name, Gender? gender);
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee?> GetEmployee(int id);
        Task<Employee?> GetEmployeeByEmail(string? email);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee?> UpdateEmployee(Employee? employee);
        Task<Employee?> DeleteEmployee(int id);
    }
}
