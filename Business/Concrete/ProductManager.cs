using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constants;
using FluentValidation;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal iProductDal)
        {
            _productDal = iProductDal;
        }
        // if kodları yazılır
        public IResult Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(),product);

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult <List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==1 )
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductID == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailsDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailsDto>> (_productDal.GetProductDetails());
        }

        public IDataResult<List<Product>> GettAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryID == id));
        }
    }

}

