using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        [Key]
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
