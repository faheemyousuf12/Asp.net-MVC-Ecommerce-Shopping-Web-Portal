using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ECommerce.Dtos;
using ECommerce.Models;

namespace ECommerce.App_Start
{
	public class MappingProfile : Profile
	{
		public MappingProfile ()
		{
			Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<ProductDto, Product>();
			Mapper.CreateMap<UOM, UomDto>();
			Mapper.CreateMap<Brand, BrandDto>();
            Mapper.CreateMap<BrandDto, Brand>();
			Mapper.CreateMap<UomDto, UOM>();
			
		}
		
	}
}