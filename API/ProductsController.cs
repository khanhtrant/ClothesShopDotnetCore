using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothesShopDotnetCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShopDotnetCore.API
{
    [Produces("application/json")]
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            var productInDb = _productRepository.GetProduct(productId);
            _productRepository.RemoveProduct(productInDb);
            if (!_productRepository.Save())
            {
                return StatusCode(500, "Error from server");
            }

            return Ok();
        }
    }
}