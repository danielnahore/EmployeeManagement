using Api.Models;
using EmployeeManagement;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
            private readonly IDepartmentRepository departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            try
            {
                return Ok(await departmentRepository.GetDepartments());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            try
            {
                var result = await departmentRepository.GetDepartment(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
