using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Domain
{
    public partial class Budget
    {
        public int BudgetId { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; } = null!;

        public decimal LimitAmount { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
