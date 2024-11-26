using EmployeeManagement;

namespace Web.Services
{
    public class EmployeeSevice : IEmloyeeService
    {
        private readonly HttpClient httpClient;
        public EmployeeSevice(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetFromJsonAsync<Employee>($"api/Employee/{id}");
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("api/Employee");
        }

        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            var response = await httpClient.PutAsJsonAsync<Employee>("api/Employee", updatedEmployee);
            return await response.Content.ReadFromJsonAsync<Employee>();
        }
        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            var response = await httpClient.PostAsJsonAsync<Employee>("api/Employee", newEmployee);
            return await response.Content.ReadFromJsonAsync<Employee>();
        }

        public async Task DeleteEmployee(int id)
        {
            await httpClient.DeleteAsync($"api/Employee/{id}");
        }
    }
}
