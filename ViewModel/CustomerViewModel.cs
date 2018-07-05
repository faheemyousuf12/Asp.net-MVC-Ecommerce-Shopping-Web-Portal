using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerce.Models;

namespace ECommerce.ViewModel
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }

        public IEnumerable<MembershipType> MembershipType { get; set; }
    }
}