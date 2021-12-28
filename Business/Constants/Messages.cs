using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "ürün eklendi";
        public static string ProductNameInvalid = "ürün ismi geçersiz";
        public static string MaintenanceTime="sistem bakımda";
        public static string ProductListed="listelendi";
        public static string ProductCountOfCategoryError = "Category dizim hatası";
        public static string ProductNameAlreadyExists = "bu isimde zatebn başka ürün var";
        public static string CategoryLimitExced="limit aşıldığı için yeni ürün eklenemedi";
    }
}
