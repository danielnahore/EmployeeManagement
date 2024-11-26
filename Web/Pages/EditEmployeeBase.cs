using AutoMapper;
using EmployeeManagement;
using Microsoft.AspNetCore.Components;
using Web.Models;
using Web.Services;

namespace Web.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmloyeeService EmployeeService { get; set; }

        private Employee Employee { get; set; } = new Employee();

        public string PageHeaderText { get; set; }

        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();
        
        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        public List<Department> Departments { get; set; } = new List<Department>();

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            int.TryParse(Id, out int employeeId);

            if (employeeId != 0)
            {
                PageHeaderText = "Edit Employee";
                Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            }
            else
            {
                PageHeaderText = "Create Employee";
                Employee = new Employee
                {
                    Id = 20,
                    DepartmentId = 1,
                    DateOfBirth = DateTime.Now,
                    PhotoPath = "images/nophoto.png",
                    Department = new Department()
                    //Id = 20,
                    //FirstName = "Mr",
                    //LastName = "Nobody",
                    //Email = "nobody@gmail.com",
                    //DepartmentId = 1,
                    //Gender = 0,
                    //DateOfBirth = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    //PhotoPath = "images/nophoto.jpg"
                };

            }

            Departments = (await DepartmentService.GetDepartments()).ToList();

            Mapper.Map(Employee, EditEmployeeModel);
        }

        protected async Task HandleValidSubmit()
        {
            Mapper.Map(EditEmployeeModel, Employee);
            Employee result = null;

            if (Employee.Id != 0)
            {
                result = await EmployeeService.UpdateEmployee(Employee);
            }
            else
            {
                result = await EmployeeService.CreateEmployee(Employee);
            }

            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }

        protected async Task Delete_Click()
        {
            await EmployeeService.DeleteEmployee(Employee.Id);
        }
    }
}
