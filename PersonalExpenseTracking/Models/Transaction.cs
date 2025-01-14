using PersonalExpenseTracking.Models.Enum;

namespace PersonalExpenseTracking.Models
{
    public class Transaction
    {
        public string Title { get; set; } = String.Empty;
        public decimal Amount { get; set; }       // The amount of the transaction
        public  TransactionType Type { get; set; } // Type of transaction (Credit, Debit, Debt)
        public DateTime Date { get; set; }        // Date of the transaction
        public string? Notes { get; set; }  // Optional notes for the transaction, default to empty string
        public string Tags { get; set; } = String.Empty;  // E.g. "Rent", "Salary", etc.
        public bool IsCleared { get; set; }
        public string Category { get; set; } 

    }
}