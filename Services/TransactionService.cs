using Microsoft.EntityFrameworkCore;
using UBEE.Data;
using UBEE.Models;

namespace UBEE.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ApplicationDbContext _context;

        public TransactionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> GetTransactionById(int id)
        {
            return await _context.Transactions.FindAsync(id);
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<(bool Succeeded, int TransactionId, string[] Errors)> CreateTransaction(TransactionCreateDto model)
        {
            var transaction = new Transaction
            {
                PropertyId = model.PropertyId,
                BuyerId = model.BuyerId,
                SellerId = model.SellerId,
                Amount = model.Amount,
                Date = DateTime.UtcNow,
                Status = model.Status
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return (true, transaction.Id, Array.Empty<string>());
        }

        public async Task<(bool Succeeded, string[] Errors)> UpdateTransaction(int id, TransactionUpdateDto model)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return (false, new[] { "Transaction not found." });
            }

            transaction.Amount = model.Amount;
            transaction.Status = model.Status;

            await _context.SaveChangesAsync();

            return (true, Array.Empty<string>());
        }

        public async Task<(bool Succeeded, string[] Errors)> DeleteTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return (false, new[] { "Transaction not found." });
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return (true, Array.Empty<string>());
        }
    }
}

