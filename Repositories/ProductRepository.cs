using System.Collections.Generic;
using System.Linq;
using ClothesShopDotnetCore.Entities;
using ClothesShopDotnetCore.Services;

namespace ClothesShopDotnetCore.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly NorthwindContext _context;

        public ProductRepository(NorthwindContext context)
        {
            _context = context;
        }
        public IEnumerable<Products> GetProducts()
        {
            return _context.Products
                .OrderBy(p => p.ProductName)
                .ToList();
        }

        public Products GetProduct(int productId)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}