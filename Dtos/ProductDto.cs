using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Qty { get; set; }

        public string Description { get; set; }

        //public UomDto Uom { get; set; }

        public byte UomId { get; set; }

       // public BrandDto brand { get; set; }

        public byte BrandId { get; set; }


        // public SizeDto Size { get; set; }

        public byte SizeId { get; set; }

        //public GrandCategoryDto GrandCategory { get; set; }

        public byte GrandCategoryId { get; set; }
        
        public string Reveiws { get; set; }

        public string Image { get; set; }
    }
}