using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothesShopDotnetCore.Entities;

namespace ClothesShopDotnetCore.Services
{
    public interface IOrderRepository
    {
        IEnumerable<Orders> GetOrders();
        Orders GetOrder(int orderId);
    }
}
