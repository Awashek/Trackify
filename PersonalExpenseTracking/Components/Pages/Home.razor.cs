using PersonalExpenseTracking.Models;
using Microsoft.AspNetCore.Components;
using PersonalExpenseTracking.Services;
using System.Linq;
using System;
using System.Collections.Generic;

namespace PersonalExpenseTracking.Components.Pages
{
    public partial class Home : ComponentBase
    {
        // Variables for logout modal
        private bool IslogOut { get; set; } = false;

        private void Logout()
        {
            Nav.NavigateTo("/login");
        }

        private void ShowLogoutConfirmation()
        {
            IslogOut = true;
        }

        private void HideLogoutConfirmation()
        {
            IslogOut = false;
        }


    }
}
