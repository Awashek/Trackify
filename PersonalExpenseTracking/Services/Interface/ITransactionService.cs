using PersonalExpenseTracking.Models;

namespace PersonalExpenseTracking.Services.Interface;

public interface ITransactionService
{
    // Fetches all transactions from the data source.
    Task<List<Transaction>> GetAllTransactions();

    // Adds a new transaction to the data source.
    Task AddTransaction(Transaction transaction);

    // Updates an existing transaction in the data source.
    Task UpdateTransaction(Transaction transaction);

    // Deletes a transaction from the data source using its ID.
    Task DeleteTransaction(Guid transactionId);

    // Retrieves a specific transaction by its ID.
    Task<Transaction> GetTransactionById(Guid transactionId);
}