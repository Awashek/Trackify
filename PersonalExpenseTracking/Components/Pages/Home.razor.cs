using PersonalExpenseTracking.Models;
using Microsoft.AspNetCore.Components;
using PersonalExpenseTracking.Models.Enum;
using PersonalExpenseTracking.Services;

namespace PersonalExpenseTracking.Components.Pages
{
    public partial class Home : ComponentBase
    {
        private List<User> users = new();
        private string Message = string.Empty;
        private bool IslogOut { get; set; } = false;

        private decimal TotalIncome { get; set; }
        private decimal TotalExpense { get; set; }
        private decimal TotalDebts { get; set; }
        private decimal RemainingDebts { get; set; }
        private decimal ClearedDebts { get; set; }
        private List<Transaction> RevenueData { get; set; } = new();
        private List<Transaction> ExpenseCategoryData { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                // Fetch transactions
                var transactions = await TransactionService.GetTransactionsAsync();

                // Calculate metrics
                TotalIncome = transactions.Where(t => t.Type == TransactionType.Credit).Sum(t => t.Amount);
                TotalExpense = transactions.Where(t => t.Type == TransactionType.Debit).Sum(t => t.Amount);
                TotalDebts = transactions.Where(t => t.Type == TransactionType.Debt).Sum(t => t.Amount);
                ClearedDebts = transactions.Where(t => t.Type == TransactionType.Debt && t.IsCleared).Sum(t => t.Amount);
                RemainingDebts = TotalDebts - ClearedDebts;

                // Populate chart data
                RevenueData = transactions.Where(t => t.Type == TransactionType.Credit).ToList();
                ExpenseCategoryData = transactions
                    .Where(t => t.Type == TransactionType.Debit)
                    .GroupBy(t => t.Category)
                    .Select(g => new Transaction { Category = g.Key, Amount = g.Sum(t => t.Amount) })
                    .ToList();

                // Fetch users
                GetAllUsers();
            }
            catch (Exception ex)
            {
                Message = "Error loading data.";
            }
        }

        private void Logout()
        {
            Nav.NavigateTo("/login");
        }

        private void GetAllUsers()
        {
            try
            {
                users = UserService.GetAll();
            }
            catch (Exception)
            {
                Message = "Failed to fetch users.";
            }
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
