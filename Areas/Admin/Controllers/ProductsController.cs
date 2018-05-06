using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothesShopDotnetCore.Areas.Admin.Models;
using ClothesShopDotnetCore.Entities;
using ClothesShopDotnetCore.Services;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace ClothesShopDotnetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductsController(IProductRepository repository,
            ISupplierRepository supplierRepository,
            ICategoryRepository categoryRepository
            )
        {
            _repository = repository;
            _supplierRepository = supplierRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index(int? page)
        {
            var products = _repository.GetProducts();
            var pageNumber = page ?? 1;
            var onePageOfProducts = products.ToPagedList(pageNumber, 10);
            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View();
        }

        public IActionResult Create()
        {
            var viewModel = new ProductFormViewModel
            {
                Suppliers = _supplierRepository.GetSuppliers(),
                Categories = _categoryRepository.GetCategories()
            };
            return View("ProductForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Products product)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProductFormViewModel
                {
                    Suppliers = _supplierRepository.GetSuppliers(),
                    Categories = _categoryRepository.GetCategories()
                };
                return View("ProductForm", viewModel);
            }
            
            if (product.ProductId==0)
            {
                _repository.AddProduct(product);
            }

            if (!_repository.Save())
            {
                return View("Error");
            }
            return RedirectToAction("Index", "Products");
        }
    }
}