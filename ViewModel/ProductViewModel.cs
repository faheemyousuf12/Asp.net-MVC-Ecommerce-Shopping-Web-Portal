using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerce.Models;

namespace ECommerce.ViewModel
{
    public class ProductViewModel
    {
        public IEnumerable<UOM> UOM { get; set; }

        public IEnumerable<Brand> Brand { get; set; }

        public IEnumerable<Size> Size { get; set; }

        public IEnumerable<ChildCategory> ChildCategory { get; set; }

        public Product Product { get; set; }
    }
}