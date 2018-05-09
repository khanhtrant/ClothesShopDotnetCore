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
        public IActionResult Index(int? page,string searchTerm,string sortOrder)
        {
            var products = _repository.GetProducts();

            if (!String.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(p =>
                    p.ProductName.Contains(searchTerm) || p.Category.CategoryName.Contains(searchTerm) ||
                    p.Supplier.CompanyName.Contains(searchTerm));
            }

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
            else
            {
                var productInDb = _repository.GetProduct(product.ProductId);
                productInDb.ProductName = product.ProductName;
                productInDb.CategoryId = product.CategoryId;
                productInDb.QuantityPerUnit = product.QuantityPerUnit;
                productInDb.UnitPrice = product.UnitPrice;
                productInDb.SupplierId = product.SupplierId;
            }

            if (!_repository.Save())
            {
                return View("Error");
            }
            return RedirectToAction("Index", "Products");
        }

        public IActionResult Edit(int id)
        {
            var product = _repository.GetProduct(id);
            var viewModel = new ProductFormViewModel(product)
            {
                Categories = _categoryRepository.GetCategories(),
                Suppliers = _supplierRepository.GetSuppliers()
            };

            return View("ProductForm", viewModel);
        }
    }
}