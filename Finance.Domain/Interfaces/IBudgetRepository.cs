using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Domain.Interfaces
{
    public interface IBudgetRepository
    {
        Task<Budget?> GetBudgetById(int id);
        Task<IEnumerable<Budget>> GetBudgetsByUserId(int userId);
        Task CreateBudget(Budget Budget);
        Task UpdateBudget(Budget Budget);
        Task DeleteBudget(int id);
        Task SaveChangesAsync();
    }
}
