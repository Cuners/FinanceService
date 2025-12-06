using Finance.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Infrastructure.Persistence.Configurations
{
    public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
    {
        public void Configure(EntityTypeBuilder<Budget> builder)
        {
            builder.ToTable("Budgets");
            builder.HasKey(e => e.BudgetId).HasName("PK__Budgets__E38E7924E17D09DE");

            builder.Property(e => e.LimitAmount).HasColumnType("decimal(14, 2)");
            builder.Property(e => e.Name).HasMaxLength(100);

            builder.HasMany(d => d.Categories).WithMany(p => p.Budgets)
                .UsingEntity<Dictionary<string, object>>(
                    "BudgetCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_BudgetCategories_Categories"),
                    l => l.HasOne<Budget>().WithMany()
                        .HasForeignKey("BudgetId")
                        .HasConstraintName("FK_BudgetCategories_Budgets"),
                    j =>
                    {
                        j.HasKey("BudgetId", "CategoryId");
                        j.ToTable("BudgetCategories");
                    });
        }
    }
}
