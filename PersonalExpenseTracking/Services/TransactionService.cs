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
        // Initialize the transactions list by loading data from the file
        _transactions = LoadTransactionsFromFile(AppTransactionFilePath);
    }

    public async Task<List<Transaction>> GetAllTransactions()
    {
        // Return all transactions asynchronously
        return await Task.FromResult(_transactions);
    }

    public async Task<Transaction> GetTransactionById(int transactionId)
    {
        // Find and return the transaction by ID
        var transaction = _transactions.FirstOrDefault(t => t.Id == transactionId);
        return await Task.FromResult(transaction);
    }

    
    public async Task AddTransaction(Transaction transaction)
    {
        // Assign a unique ID to the new transaction and add it to the list
        transaction.Id = _transactions.Count > 0 ? _transactions.Max(t => t.Id) + 1 : 1;
        _transactions.Add(transaction);
        await SaveTransactionsToFile(AppTransactionFilePath);
    }

    public async Task UpdateTransaction(Transaction transaction)
    {
        // Find the transaction to update
        var existingTransaction = _transactions.FirstOrDefault(t => t.Id == transaction.Id);
        if (existingTransaction != null)
        {
            existingTransaction.Title = transaction.Title;
            existingTransaction.Amount = transaction.Amount;
            existingTransaction.Type = transaction.Type;
            existingTransaction.Date = transaction.Date;
            existingTransaction.Description = transaction.Description;
            existingTransaction.Tags = transaction.Tags;

            await SaveTransactionsToFile(AppTransactionFilePath);
        }
        else
        {
            throw new KeyNotFoundException("Transaction not found");
        }
    }

    public async Task DeleteTransaction(int transactionId)
    {
        var transaction = _transactions.FirstOrDefault(t => t.Id == transactionId);
        if (transaction != null)
        {
            // Remove the transaction from the list
            _transactions.Remove(transaction);

            // Ensure the file is saved with the updated list of transactions
            var filePath = Const.Const.TransactionsFilePath();  // Use the correct file path
            await SaveTransactionsToFile(filePath);
        }
        else
        {
            throw new KeyNotFoundException("Transaction not found");
        }
    }


    private List<Transaction> LoadTransactionsFromFile(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Transaction file not found: {filePath}");
                return new List<Transaction>();
            }

            var json = File.ReadAllText(filePath);
            var transactions = JsonSerializer.Deserialize<List<Transaction>>(json);

            return transactions ?? new List<Transaction>();  // Ensure we return an empty list if deserialization fails
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading transactions: {ex.Message}");
            return new List<Transaction>();  // Return an empty list on error
        }
    }


    private async Task SaveTransactionsToFile(string filePath)
    {
        try
        {
            // Ensure _transactions is not null
            if (_transactions == null)
            {
                Console.WriteLine("Transactions list is null.");
                return;
            }

            var json = JsonSerializer.Serialize(_transactions);
            await File.WriteAllTextAsync(filePath, json);
            Console.WriteLine("Transactions saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving transactions: {ex.Message}");
        }
    }

}
