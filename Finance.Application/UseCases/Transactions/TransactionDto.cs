using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Transactions
{
    public class TransactionDto
    {
        public int TransactionId { get; init; }
        public int AccountId { get; init; }
        public string AccountName { get; init; } = string.Empty;
        public int CategoryId { get; init; }
        public string CategoryName { get; init; } = string.Empty;
        public string CategoryType { get; init; } = string.Empty;
        public decimal Amount { get; init; }
        public DateOnly Date { get; init; }
        public string? Note { get; init; }
    }
}
