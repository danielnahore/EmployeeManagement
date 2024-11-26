using EmployeeManagement;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Web.Services;

namespace Web.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();

        protected string Coordinates { get; set; }
        protected string ButtonText { get; set; } = "Hide Footer";
        protected string CssClass { get; set; } = null;
 
        [Inject]
        public IEmloyeeService EmployeeService { get; set; }
        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
        }

        protected void  Button_Click()
        {
            if (ButtonText == "Hide Footer")
            {
                ButtonText = "Show Footer";
                CssClass = "HideFooter";
            }
            else
            {
                CssClass = null;
                ButtonText = "Hide Footer";
            }
        }

        //protected void Mouse_Move(MouseEventArgs e)
        //{
        //    Coordinates = $"X = {e.ClientX} Y = {e.ClientY}";
        //}
    }
}
