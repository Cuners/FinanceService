using Finance.Domain;
using Finance.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BudgetDbContext _context;
        public CategoryRepository(BudgetDbContext context)
        {
            _context = context;
        }
        public async Task<Category?> GetCategoryByCategoryId(int id)
        {
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CategoryId == id);
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task CreateCategory(Category Category)
        {
            await _context.Categories.AddAsync(Category);
        }

        public async Task UpdateCategory(Category Category)
        {
            _context.Categories.Update(Category);
        }

        public async Task DeleteCategory(int id)
        {
            var acc = await _context.Categories.FindAsync(id);
            if (acc != null)
                _context.Categories.Remove(acc);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
