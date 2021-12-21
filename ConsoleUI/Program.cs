using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            ProductManager productManager = new ProductManager(new EfProductDal());
            
            foreach (var category in productManager.GetProductDetails().Data)
            {
                Console.WriteLine(category.ProductName+"/"+category.CategoryName);
            }

        }
    }
}