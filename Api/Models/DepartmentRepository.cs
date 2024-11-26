using EmployeeManagement;
using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext appDbContext;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Department?> GetDepartment(int id)
        {
            return await appDbContext.Departments.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await appDbContext.Departments.ToListAsync(); 
        }
    }
}
