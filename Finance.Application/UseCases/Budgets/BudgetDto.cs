using Finance.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases.Budgets
{
    public class BudgetDto
    {
        public int BudgetId { get; init; }
        public string Name { get; init; } = null!;

        public decimal LimitAmount { get; init; }

        public DateOnly Date { get; init; }

        public ICollection<Category> Categories { get; init; } = new List<Category>();
    }
}
