using System.Collections.Generic;
using ClothesShopDotnetCore.Entities;

namespace ClothesShopDotnetCore.Services
{
    public interface ICustomerRepository
    {
        IEnumerable<Customers> Customerses();
        Customers GetCustomer(string customerId);
    }
}