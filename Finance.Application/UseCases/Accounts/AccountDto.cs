using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Accounts
{
    public class AccountDto
    {
        public int AccountId { get; set; }
        public string Name { get; set; } = "";
        public decimal Balance { get; set; }
    }
}
