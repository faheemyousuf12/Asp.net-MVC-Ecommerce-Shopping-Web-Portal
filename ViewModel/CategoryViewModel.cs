using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerce.Models;

namespace ECommerce.ViewModel
{
    public class CategoryViewModel
    {
        public IEnumerable<ParentCategory> ParentCategory { get; set; }

        public ChildCategory ChildCategory { get; set; }

    }
}