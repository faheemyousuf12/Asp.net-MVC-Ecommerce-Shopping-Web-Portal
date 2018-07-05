using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class ChildCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ParentCategory ParentCategory { get; set; }

        public int ParentCategoryId { get; set; }
    }
}