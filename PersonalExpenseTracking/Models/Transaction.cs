namespace PersonalExpenseTracking.Models
{
    public class Transaction
    {
        public string Title { get; set; }     
        public decimal Amount { get; set; }       // The amount of the transaction
        public string Type { get; set; } // Type of transaction (Credit, Debit, Debt)
        public DateTime Date { get; set; }        // Date of the transaction
        public string Notes { get; set; } = string.Empty; // Optional notes for the transaction, default to empty string
        public string Tags { get; set; } = string.Empty;  // E.g. "Rent", "Salary", etc.
    }
}