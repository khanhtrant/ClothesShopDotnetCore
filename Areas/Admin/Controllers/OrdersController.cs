using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothesShopDotnetCore.Services;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace ClothesShopDotnetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _repository;

        public OrdersController(IOrderRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index(int? page)
        {
            var orders = _repository.GetOrders();
            var pageNumber = page ?? 1;
            var onePageOfOrders = orders.ToPagedList(pageNumber, 10);
            ViewBag.OnePageOfOrders = onePageOfOrders;
            return View();
        }
    }
}