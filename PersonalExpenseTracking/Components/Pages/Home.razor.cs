using PersonalExpenseTracking.Models;
using Microsoft.AspNetCore.Components;

namespace PersonalExpenseTracking.Components.Pages
{
    public partial class Home : ComponentBase
    {
        private List<User> users = new List<User>();

        private string Message = string.Empty;

        private bool IslogOut { get; set; } = false;
        protected override void OnInitialized()
        {
            GetAllUsers();
        }
        private void Logout()
        {
            Nav.NavigateTo("/login");
        }

        private async Task<List<User>> GetAllUsers()
        {
            try
            {
                users = UserService.GetAllUsers();

                return users;

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        private async Task DeleteUser(string username)
        {
            bool result = UserService.DeleteUser(username);

            Message = result ? "Successfully Deleted" : "Error Deleting User";
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