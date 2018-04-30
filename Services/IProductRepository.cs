using System.Collections.Generic;
using ClothesShopDotnetCore.Entities;

namespace ClothesShopDotnetCore.Services
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetProducts();
        Products GetProduct(int productId);
    }
}