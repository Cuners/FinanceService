using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Domain.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction?> GetTransactionByTransactionId(int id);
        Task<IEnumerable<Transaction>> GetTransactionsByAccountId(int id);
        Task CreateTransaction(Transaction Transaction);
        Task UpdateTransaction(Transaction Transaction);
        Task DeleteTransaction(int id);
    }
}
