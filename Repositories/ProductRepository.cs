using System.Collections.Generic;
using System.Linq;
using ClothesShopDotnetCore.Entities;
using ClothesShopDotnetCore.Services;
using Microsoft.EntityFrameworkCore;

namespace ClothesShopDotnetCore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly NorthwindContext _context;

        public ProductRepository(NorthwindContext context)
        {
            _context = context;
        }
        public IEnumerable<Products> GetProducts()
        {
            return _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .OrderBy(p => p.ProductName)
                .ToList();
        }

        public Products GetProduct(int productId)
        {
            return _context.Products
                .Include(p=>p.Category)
                .Include(p=>p.Supplier)
                .FirstOrDefault(p => p.ProductId == productId);
        }

        public void AddProduct(Products product)
        {
            _context.Add(product);
        }

        public bool Save()
        {
            return (_context.SaveChanges()>=0);
        }

        public void RemoveProduct(Products product)
        {
            _context.Products.Remove(product);
        }
    }
}