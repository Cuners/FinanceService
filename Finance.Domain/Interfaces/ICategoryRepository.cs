using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category?> GetCategoryByCategoryId(int id);
        Task<IEnumerable<Category>> GetAllCategories();
        Task CreateCategory(Category Category);
        Task UpdateCategory(Category Category);
        Task DeleteCategory(int id);
        Task SaveChangesAsync();
    }
}
