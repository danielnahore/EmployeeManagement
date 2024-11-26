using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebComponents
{
    public class ConfirmBase : ComponentBase
    {
        protected bool Visible { get; set; }

        [Parameter]
        public string Title { get; set; } = "Delete Confirmation";

        [Parameter]
        public string Message { get; set; } = "Are you sure you want to delete?";

        public void Show()
        {
            Visible = true;
            StateHasChanged();
        }

        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }

        protected async Task OnConfirmationChange(bool value)
        {
            Visible = false;
            await ConfirmationChanged.InvokeAsync(value);
        }

    }
}
