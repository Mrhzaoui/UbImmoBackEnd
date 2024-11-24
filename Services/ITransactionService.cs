using UBEE.Models;

namespace UBEE.Services
{
    public interface ITransactionService
    {
        Task<Transaction> GetTransactionById(int id);
        Task<IEnumerable<Transaction>> GetAllTransactions();
        Task<(bool Succeeded, int TransactionId, string[] Errors)> CreateTransaction(TransactionCreateDto model);
        Task<(bool Succeeded, string[] Errors)> UpdateTransaction(int id, TransactionUpdateDto model);
        Task<(bool Succeeded, string[] Errors)> DeleteTransaction(int id);
    }
}

