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
        public async Task<Category?> GetCategoryById(int id)
        {
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CategoryId == id);
        }
        public async Task<IEnumerable<Category>> GetCategoriesById(List<int> ids)
        {
            return await _context.Categories
                .AsNoTracking()
                .Where(x => ids.Contains(x.CategoryId))
                .ToListAsync();
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
