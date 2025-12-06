using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account?> GetAccountByAccountId(int id);
        Task<IEnumerable<Account>> GetAllAccounts();
        Task CreateAccount(Account account);
        Task UpdateAccount(Account account);
        Task DeleteAccount(int id);
        Task SaveChangesAsync();
    }
}
