using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerce.Models;
using ECommerce.ViewModel;

namespace ECommerce.ViewModel
{
    public class CartLineItemViewModel
    {
        public IEnumerable<CartLineItem> CartLineItem { get; set; }

        public IEnumerable<Product> Product { get; set; }

        public Cart cart { get; set; }
    }
}