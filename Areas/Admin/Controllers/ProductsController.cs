﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothesShopDotnetCore.Services;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace ClothesShopDotnetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index(int? page)
        {
            var products = _repository.GetProducts();
            var pageNumber = page ?? 1;
            var onePageOfProducts = products.ToPagedList(pageNumber, 10);
            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View();
        }
    }
}