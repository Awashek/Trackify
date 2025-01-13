using Microsoft.AspNetCore.Components;

namespace PersonalExpenseTracking.Components.Pages;

public partial class Transaction : ComponentBase
{
    public object Amount { get; set; }
    public object Category { get; set; }
}