using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class UserBasket
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public Product product { get; set; }

        public int ProductId { get; set; }

        public int Qty { get; set; }

        public Size Size { get; set; }

        public int SizeId { get; set; }

        public double Amount { get; set; }
    }
}