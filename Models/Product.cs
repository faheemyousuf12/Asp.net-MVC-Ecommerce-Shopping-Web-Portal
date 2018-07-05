using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int Price { get; set; }

        public int Qty { get; set; }

        public string Description { get; set; }

        public UOM Uom { get; set; }

        public int UomId { get; set; }

        public Size Size { get; set; }

        public int SizeId { get; set; }

        public Brand brand { get; set; }

        public int BrandId { get; set; }

        public ChildCategory ChildCategory { get; set; }

        public int ChildCategoryId { get; set; }    
   


        public string Reveiws { get; set; }

        public string Image { get; set; }
        //public int Ratings { get; set; }


    }
}