using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerce.Models;

namespace ECommerce.ViewModel
{
    public class OrderViewModel
    {
        public IEnumerable<Brand> Brand { get; set; }

        public IEnumerable<ChildCategory> ChildCategory { get; set; }

        public IEnumerable<Product> Product { get; set; }

        public Order Order { get; set; }

    }
}