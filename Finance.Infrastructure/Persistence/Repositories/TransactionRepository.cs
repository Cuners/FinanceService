using Finance.Domain;
using Finance.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Infrastructure.Persistence.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BudgetDbContext _context;
        public TransactionRepository(BudgetDbContext context)
        {
            _context = context;
        }
        public async Task<Transaction?> GetTransactionByTransactionId(int id)
        {
            return await _context.Transactions
                .AsNoTracking()
                .Include(x => x.Account)
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.TransactionId == id);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByAccountId(int id)
        {
            return await _context.Transactions
                .AsNoTracking()
                .Include(x => x.Account)
                .Include(x => x.Category)
                .Where(x=>x.AccountId == id)
                .ToListAsync();
        }

        public async Task CreateTransaction(Transaction Transaction)
        {
            await _context.Transactions.AddAsync(Transaction);
        }

        public async Task UpdateTransaction(Transaction Transaction)
        {
            _context.Transactions.Update(Transaction);
        }

        public async Task DeleteTransaction(int id)
        {
            var acc = await _context.Transactions.FindAsync(id);
            if (acc != null)
                _context.Transactions.Remove(acc);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
