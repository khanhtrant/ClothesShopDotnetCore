using System.Collections.Generic;
using System.Linq;
using ClothesShopDotnetCore.Entities;
using ClothesShopDotnetCore.Services;

namespace ClothesShopDotnetCore.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly NorthwindContext _context;

        public CategoryRepository(NorthwindContext context)
        {
            _context = context;
        }
        public IEnumerable<Categories> GetCategories()
        {
            return _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();
        }

        public Categories GetCategory(int categoryId)
        {
            return _context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }
    }
}