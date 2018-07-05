using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerce.Models;

namespace ECommerce.ViewModel
{
    public class AddToCartViewModel
    {
        public IEnumerable<Cart> Cart { get; set; }

        public CartLineItem CartLineItem { get; set; }

        public IEnumerable<Customer> Customer { get; set; }


    }
}