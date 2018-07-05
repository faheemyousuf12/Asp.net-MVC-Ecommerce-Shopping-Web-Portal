using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerce.Models;

namespace ECommerce.ViewModel
{
    public class ProductBasketViewModel
    {
        public IEnumerable<Product> Product { get; set; }

        public IEnumerable<UserBasket> UserBasket { get; set; }

        public Customer Customer { get; set; }

        public IEnumerable<Size> Size { get; set; }

        public int TotAmount { get; set; }

        public int TotQty { get; set; }

        public int CustomerId { get; set; }
    }
}