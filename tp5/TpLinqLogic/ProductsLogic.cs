using System;
using System.Collections.Generic;
using System.Linq;
using Tp5.Data;
using Tp5.Entities;

namespace TpLinqLogic
{
    public class ProductsLogic
    {
        private readonly NorthwindContext _context;
        public ProductsLogic()
        {
            _context = new NorthwindContext();
        }

        public List<Product> GetProductsWithNoStock()
        {
            return _context.Products.Where(x => x.UnitsInStock == 0).ToList();
        }

        public List<Product> GetExpensiveProductsInStock()
        {
            var products = from product in _context.Products
                           where product.UnitsInStock > 0 && product.UnitPrice > 3
                           select product;

            return products.ToList();
        }

        public Product GetProduct789()
        {
            return _context.Products.FirstOrDefault(x => x.ProductID == 789);
        }

        public List<Product> GetProductsOrderedByName()
        {
            var products = from product in _context.Products
                           orderby product.ProductName
                           select product;

            return products.ToList();
        }

        public List<Product> GetProductsOrderedByStock()
        {
            return _context.Products.OrderByDescending(x => x.UnitsInStock).ToList();
        }

        public List<Category> GetProductsCategories()
        {
            return _context
                .Products
                .Select(x => x.Category)
                .ToList();
        }

        public Product GetFirstProduct()
        {
            return _context.Products.FirstOrDefault();
        }
    }
}
