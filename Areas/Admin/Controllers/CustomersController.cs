using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothesShopDotnetCore.Areas.Admin.Models;
using ClothesShopDotnetCore.Services;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace ClothesShopDotnetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _repository;

        public CustomersController(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index(int? page)
        {
            var customers = _repository.Customerses();
            var pageNumber = page ?? 1;
            var onePageOfCustomers = customers.ToPagedList(pageNumber, 10);
            ViewBag.OnePageOfCustomers = onePageOfCustomers;
            return View();
        }
    }
}