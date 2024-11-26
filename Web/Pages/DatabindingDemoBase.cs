using Microsoft.AspNetCore.Components;

namespace Web.Pages
{
    public class DatabindingDemoBase : ComponentBase
    {
        protected string Name { get; set; } = "Daniel";
        protected string Gender { get; set; } = "Male";
        protected string Colour { get; set; } = "background-color:white";
    }
}
