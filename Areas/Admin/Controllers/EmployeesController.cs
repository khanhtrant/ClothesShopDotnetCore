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
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _repository;

        public EmployeesController(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index(int? page)
        {
            var employees = _repository.GetEmployees();
            var pageNumber = page ?? 1;
            var onePageOfEmployees = employees.ToPagedList(pageNumber, 10);
            ViewBag.OnePageOfEmployees = onePageOfEmployees;
            return View();
        }
    }
}