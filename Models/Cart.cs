using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Cart
    {
        public int Id { get; set; }


        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public int TotalQty { get; set; }

        public double TotalAmount { get; set; }

        public DateTime DateTime { get; set; }


    }
}