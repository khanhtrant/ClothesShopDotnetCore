using System.Collections.Generic;
using ClothesShopDotnetCore.Entities;

namespace ClothesShopDotnetCore.Services
{
    public interface ICategoryRepository
    {
        IEnumerable<Categories> GetCategories();
        Categories GetCategory(int categoryId);
    }
}