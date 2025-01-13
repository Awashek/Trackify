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
        _transactions = GetAll(AppTransactionFilePath);
        
    }
    
    public async Task<List<Transaction>> GetAll(string accountId)

    
}