using EmployeeManagement;
using Microsoft.AspNetCore.Components;
using Web.Services;


namespace Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmloyeeService EmployeeService { get; set; }
        public IEnumerable<Employee>? Employees { get; set; }

        public bool ShowFooter { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
        }

        protected async Task EmployeeDeleted()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
        }

        protected int SelectedEmployeesCount { get; set; } = 0;

        protected void EmployeeSelectionChanged(bool isSelected)
        {
            if (isSelected)
            {
                SelectedEmployeesCount++;
            }
            else
            {
                SelectedEmployeesCount--;
            }
        }
    }
}
