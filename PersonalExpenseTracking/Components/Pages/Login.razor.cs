using PersonalExpenseTracking.Models;

namespace PersonalExpenseTracking.Components.Pages
{
    public partial class Login
    {
        private string? ErrorMessage;
        private string SelectedCurrency { get; set; } = string.Empty;

        public User Users { get; set; } = new();

        private async void HandleLogin()
        {
            if (string.IsNullOrEmpty(SelectedCurrency))
            {
                ErrorMessage = "Please select a preferred currency.";
                return;
            }
            if (string.IsNullOrEmpty(Users.Username)|| string.IsNullOrEmpty(Users.Password))
            {
                ErrorMessage = "Please select a preferred currency.";
                return;
            }
            var CurrentUser = await UserService.Login(Users);

            if (CurrentUser != null)
            {
                globalstate.CurrentUser = CurrentUser;
                globalstate.CurrentUser.Preferred_Currency = SelectedCurrency;
                // Navigate to home on successful login
                Nav.NavigateTo("/home");
                
            }
            else
            {
                // Display error message on invalid credentials
                ErrorMessage = "Invalid username or password.";
            }
        }
        
    }
}