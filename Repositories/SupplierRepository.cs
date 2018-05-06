using System.Collections.Generic;
using System.Linq;
using ClothesShopDotnetCore.Entities;
using ClothesShopDotnetCore.Services;

namespace ClothesShopDotnetCore.Repositories
{
    public class SupplierRepository:ISupplierRepository
    {
        private readonly NorthwindContext _context;

        public SupplierRepository(NorthwindContext context)
        {
            _context = context;
        }
        public IEnumerable<Suppliers> GetSuppliers()
        {
            return _context.Suppliers.ToList();
        }
    }
}