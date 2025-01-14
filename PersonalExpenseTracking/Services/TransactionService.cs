using System.Text.Json;
using PersonalExpenseTracking.Abstraction;
using PersonalExpenseTracking.Models;
using PersonalExpenseTracking.Services.Interface;

namespace PersonalExpenseTracking.Services;

public class TransactionService : BaseService<Transaction>, ITransactionService
{
    private static readonly string AppTransactionFilePath = Const.Const.TransactionsFilePath();
    private List<Transaction> _transactions;

    public TransactionService()
    {
        // Initialize transactions list
        _transactions = LoadTransactionsFromFile(AppTransactionFilePath);
    }

    // Async method to get all transactions
    public async Task<List<Transaction>> GetTransactions()
    {
        // Return the transaction list asynchronously
        return await Task.FromResult(_transactions);
    }

    // Private method to load transactions from a file or data source
    private List<Transaction> LoadTransactionsFromFile(string filePath)
    {
        try
        {
            // Ensure file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Transaction file not found: {filePath}");
                return new List<Transaction>();
            }

            // Read and deserialize JSON data
            var json = File.ReadAllText(filePath);
            var transactions = JsonSerializer.Deserialize<List<Transaction>>(json);

            if (transactions == null)
            {
                Console.WriteLine("No transactions found in the file.");
                return new List<Transaction>();
            }

            return transactions;
        }
        catch (JsonException jsonEx)
        {
            // Handle JSON deserialization issues
            Console.WriteLine($"JSON error: {jsonEx.Message}");
        }
        catch (Exception ex)
        {
            // Handle other potential errors
            Console.WriteLine($"Error loading transactions: {ex.Message}");
        }

        return new List<Transaction>(); // Return empty list on error
    }

    public Task<List<Transaction>> GetAllTransactions()
    {
        throw new NotImplementedException();
    }

    public Task AddTransaction(Transaction transaction)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTransaction(Transaction transaction)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTransaction(Guid transactionId)
    {
        throw new NotImplementedException();
    }

    public Task<Transaction> GetTransactionById(Guid transactionId)
    {
        throw new NotImplementedException();
    }
}
