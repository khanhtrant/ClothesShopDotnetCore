using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothesShopDotnetCore.Entities;
using ClothesShopDotnetCore.Services;
using Microsoft.EntityFrameworkCore;

namespace ClothesShopDotnetCore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly NorthwindContext _context;

        public OrderRepository(NorthwindContext context)
        {
            _context = context;
        }
        public IEnumerable<Orders> GetOrders()
        {
            return _context.Orders
                .Include(o => o.Customer)
                .OrderBy(o => o.OrderId)
                .ToList();
        }

        public Orders GetOrder(int orderId)
        {
            return _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.ShipViaNavigation)
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.OrderId == orderId);
        }
    }
}
