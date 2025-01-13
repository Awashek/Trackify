using PersonalExpenseTracking.Models;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PersonalExpenseTracking.Services;

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
    
                var users = UserService.GetAllUsers(); // Call the non-async method
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
        

        private decimal TotalIncome { get; set; }
        private decimal TotalExpense { get; set; }
        private decimal TotalDebts { get; set; }
        private decimal RemainingDebts { get; set; }
        private decimal ClearedDebts { get; set; }
        private List<Transaction> RevenueData { get; set; }
        private List<Transaction> ExpenseCategoryData { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var transactions = await DataService.GetTransactionsAsync();

            // Calculate the total metrics
            TotalIncome = transactions.Where(t => t.Type == TransactionType.Credit).Sum(t => t.Amount);
            TotalExpense = transactions.Where(t => t.Type == TransactionType.Debit).Sum(t => t.Amount);
            TotalDebts = transactions.Where(t => t.Type == TransactionType.Debt).Sum(t => t.Amount);
            ClearedDebts = transactions.Where(t => t.Type == TransactionType.Debt && t.IsCleared).Sum(t => t.Amount);
            RemainingDebts = TotalDebts - ClearedDebts;

            // Populate data for the charts (grouped by categories for expenses)
            RevenueData = transactions.Where(t => t.Type == TransactionType.Credit).ToList();
            ExpenseCategoryData = transactions.Where(t => t.Type == TransactionType.Debit).GroupBy(t => t.Category).Select(g => new Transaction
            {
                Category = g.Key,
                Amount = g.Sum(t => t.Amount)
            }).ToList();
        }
    }
    
    
}