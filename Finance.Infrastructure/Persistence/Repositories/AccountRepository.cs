using Finance.Domain;
using Finance.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace Finance.Infrastructure.Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BudgetDbContext _context;
        public AccountRepository(BudgetDbContext context)
        {
            _context = context;
        }
        public async Task<Account?> GetAccountByAccountId(int id)
        {
            return await _context.Accounts
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.AccountId == id);
        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await _context.Accounts
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<IEnumerable<Account>> GetAccountsByUserId(int userId)
        {
            return await _context.Accounts
                .AsNoTracking()
                .Where(a => a.UserId == userId)
                .ToListAsync();
        }
        public async Task CreateAccount(Account account)
        {
            await _context.Accounts.AddAsync(account);
        }

        public async Task UpdateAccount(Account account)
        {
            _context.Accounts.Update(account);
        }

        public async Task DeleteAccount(int id)
        {
            var acc = await _context.Accounts.FindAsync(id);
            if (acc != null)
                _context.Accounts.Remove(acc);
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                var ax= ex.Message;
            }
        }
    }
}
