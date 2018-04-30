using System.Collections.Generic;
using System.Linq;
using ClothesShopDotnetCore.Entities;
using ClothesShopDotnetCore.Services;

namespace ClothesShopDotnetCore.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly NorthwindContext _context;

        public CustomerRepository(NorthwindContext context)
        {
            this._context = context;
        }
        public IEnumerable<Customers> Customerses()
        {
            return _context.Customers
                .OrderBy(c => c.ContactName)
                .ToList();
        }

        public Customers GetCustomer(string customerId)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId.Equals(customerId));
        }
    }
}