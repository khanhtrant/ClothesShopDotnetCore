using System.Collections;
using System.Collections.Generic;
using ClothesShopDotnetCore.Entities;

namespace ClothesShopDotnetCore.Services
{
    public interface ISupplierRepository
    {
        IEnumerable<Suppliers> GetSuppliers();
    }
}