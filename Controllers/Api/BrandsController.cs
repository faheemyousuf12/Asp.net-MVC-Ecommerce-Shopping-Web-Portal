using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ECommerce.Controllers.Api
{
    public class BrandsController : ApiController
    {
        private ApplicationDbContext _context;

        public BrandsController()
        {
            _context = new ApplicationDbContext();

        }
        [HttpGet]
        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands.ToList();
        }
        [HttpGet]
        public Brand GetBrands(int id)
        {
            var brand = _context.Brands.SingleOrDefault(m => m.Id == id);
            if (brand == null)

                throw new HttpResponseException(HttpStatusCode.NotFound);
            return brand;
        }
        [HttpPost]
        public Brand CreateBrand(Brand brand)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Brands.Add(brand);
            _context.SaveChanges();
            return brand;
        }
        [HttpPut]
        public void UpdateBrand(int id, Brand brand)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var brandInDb = _context.Brands.SingleOrDefault(m => m.Id == id);
            if (brandInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            brandInDb.Name = brand.Name;

            _context.SaveChanges();

        }
        [HttpDelete]
        public void DeleteBrand(int id)
        {
            var brand = _context.Brands.SingleOrDefault(m=>m.Id==id);
            if (brand == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Brands.Remove(brand);
            _context.SaveChanges();
        }
    }
}
