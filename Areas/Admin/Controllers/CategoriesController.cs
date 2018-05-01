using ClothesShopDotnetCore.Services;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace ClothesShopDotnetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoriesController(ICategoryRepository repository)
        {
            _repository = repository;
        }
        // GET
        public IActionResult Index(int? page)
        {
            var customers = _repository.GetCategories();
            var pageNumber = page ?? 1;
            var onePageOfCategories = customers.ToPagedList(pageNumber, 10);
            ViewBag.OnePageOfCategories = onePageOfCategories;
            return View();
        }
    }
}