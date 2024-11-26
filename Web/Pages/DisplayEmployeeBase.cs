using EmployeeManagement;
using Microsoft.AspNetCore.Components;
using Web.Services;
using WebComponents;

namespace Web.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }

        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }

        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }

        [Inject]
        public IEmloyeeService EmloyeeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
        }

        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
            await OnEmployeeSelection.InvokeAsync((bool)e.Value);
        }

        protected ConfirmBase DeleteConfirmation { get; set; }
        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await EmloyeeService.DeleteEmployee(Employee.Id);
                await OnEmployeeDeleted.InvokeAsync(Employee.Id);
            }
        }
    }
}
