using System;

namespace PersonalExpenseTracking.Models
{
    public class Debt
    {
        public int Id { get; set; } 

        public string Source { get; set; } // The source of the debt (e.g., loan, credit card, etc.)

        public string Status = "pending";
        public decimal Amount { get; set; } // Total debt amount

        public DateOnly DueDate { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddDays(20)); // The due date for repayment

        public  DateOnly? ClearedDate { get; set; } // Indicates if the debt has been cleared

        public string Title { get; set; }

    }
}