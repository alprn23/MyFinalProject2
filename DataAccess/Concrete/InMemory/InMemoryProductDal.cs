using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{CategoryID=1,ProductID=1, ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{CategoryID=1,ProductID=2, ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{CategoryID=2,ProductID=3, ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{CategoryID=2,ProductID=4, ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{CategoryID=2,ProductID=5, ProductName="Fare",UnitPrice=85,UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int CategoryID)
        {
            return _products.Where(p => p.CategoryID == CategoryID).ToList();
        }

        public List<ProductDetailsDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.CategoryID = product.CategoryID;

        }
    }
}
