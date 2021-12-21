using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailsDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join p2 in context.Categories
                             on p.CategoryID equals p2.CategoryId
                             select new ProductDetailsDto { ProductID = p.ProductID, ProductName = p.ProductName, 
                                 CategoryName = p2.CategoryName, UnitsInStock = p.UnitsInStock };
                return result.ToList();
            }
        }
    } 
}
