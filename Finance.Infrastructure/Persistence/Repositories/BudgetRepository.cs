using Finance.Domain;
using Finance.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Infrastructure.Persistence.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly BudgetDbContext _context;
        public BudgetRepository(BudgetDbContext context)
        {
            _context = context;
        }
        public async Task<Budget?> GetBudgetById(int id)
        {
            return await _context.Budgets
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.BudgetId == id);
        }

        public async Task<IEnumerable<Budget>> GetAllBudgets()
        {
            return await _context.Budgets
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task CreateBudget(Budget Budget)
        {
            await _context.Budgets.AddAsync(Budget);
        }

        public async Task UpdateBudget(Budget Budget)
        {
            _context.Budgets.Update(Budget);
        }

        public async Task DeleteBudget(int id)
        {
            var acc = await _context.Budgets.FindAsync(id);
            if (acc != null)
                _context.Budgets.Remove(acc);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
