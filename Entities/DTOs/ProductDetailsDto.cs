using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ProductDetailsDto : IDto
    {
        public int ProductID { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
    }
}
