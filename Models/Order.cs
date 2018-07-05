using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace ECommerce.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public Cart Cart { get; set; }

        public int CartId { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }

        public string Status { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public CartLineItem CartLineItem { get; set; }

        public int CartLineItemId { get; set; }

        



    }
}