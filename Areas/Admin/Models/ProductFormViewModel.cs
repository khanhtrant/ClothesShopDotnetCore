using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ClothesShopDotnetCore.Entities;

namespace ClothesShopDotnetCore.Areas.Admin.Models
{
    public class ProductFormViewModel
    {
        public int ProductId { get; set; }
        
        [Required]
        [StringLength(40)]
        [Display(Name= "Product Name")]
        public string ProductName { get; set; }
        
        [Display(Name = "Supplier")]
        public int? SupplierId { get; set; }
        
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        
        [StringLength(20)]
        public string QuantityPerUnit { get; set; }
        
        [Display(Name = "Unit Price")]
        public decimal? UnitPrice { get; set; }
        
        public short? UnitsInStock { get; set; }
        
        public short? UnitsOnOrder { get; set; }
        
        public short? ReorderLevel { get; set; }
        
        [Required]
        public bool Discontinued { get; set; }

        public IEnumerable<Categories> Categories { get; set; }
        public IEnumerable<Suppliers> Suppliers { get; set; }

        public ProductFormViewModel()
        {
            ProductId = 0;
        }

        public ProductFormViewModel(Products product)
        {
            ProductId = product.ProductId;
            ProductName = product.ProductName;
            SupplierId = product.SupplierId;
            CategoryId = product.CategoryId;
            UnitPrice = product.UnitPrice;
        }
    }
}