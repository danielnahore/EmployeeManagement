using Api.Models;
using EmployeeManagement;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmloyees()
        {
            try
            {
                return Ok(await employeeRepository.GetEmployees());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{Search}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string name, Gender? gender)
        {
            try
            {
                var result = await employeeRepository.Search(name, gender);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var result = await employeeRepository.GetEmployee(id);
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

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }

                var emp = await employeeRepository.GetEmployeeByEmail(employee.Email);
                if (emp != null)
                {
                    ModelState.AddModelError("email", "Employee email already in use.");
                    return BadRequest();
                }

                var createdEmployee = await employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee)
        {
           try
           {
                var employeeToUpdate = await employeeRepository.GetEmployee(employee.Id);

                if (employeeToUpdate == null)
                {
                    return NotFound($"Employee with ID={employee.Id} not found.");
                }
                
                return await employeeRepository.UpdateEmployee(employee);
           }
           catch (Exception ex)
           {
                return StatusCode(500, ex.Message);
           } 
        }

        [HttpDelete]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
           try
           {
                var employeeToDelete = await employeeRepository.GetEmployee(id);
                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with ID={id} not found.");
                }
                return await employeeRepository.DeleteEmployee(id);
           }
           catch (Exception)
           {
                return StatusCode(500, "Error deleting data.");
           } 

        }
    }
}
