using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerce.Models;

namespace ECommerce.ViewModel
{
    public class ProductCartViewModel
    {
        public Product Product { get; set; }

        public UserBasket UserBasket { get; set; }

        public Customer Customer { get; set; }

        public CartLineItem CartLineItem { get; set; }

        public IEnumerable<Size> Size { get; set; }

        public Cart Cart { get; set; }

        public int cartId { get; set; }

        public int productId { get; set; }

        public int customerId  { get; set; }
         
    }
}