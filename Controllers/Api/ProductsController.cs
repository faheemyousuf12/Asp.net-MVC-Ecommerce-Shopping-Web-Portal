using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ECommerce.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();

        }
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
        [HttpGet]
        public Product GetProducts(int id)
        {
            var product = _context.Products.SingleOrDefault(m => m.Id == id);
            if (product == null)

                throw new HttpResponseException(HttpStatusCode.NotFound);
            return product;
        }
        [HttpPost]
        public Product CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }
        [HttpPut]
        public void UpdateProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var productInDb = _context.Products.SingleOrDefault(m => m.Id == id);
            if (productInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            productInDb.Name = product.Name;
            productInDb.Price = product.Price;
            productInDb.Qty = product.Qty;
            productInDb.Description = product.Description;
            productInDb.Reveiws = product.Reveiws;
            productInDb.UomId = product.UomId;
            productInDb.BrandId = product.BrandId;
            productInDb.Image = product.Image;
            productInDb.ChildCategoryId = product.ChildCategoryId;
            productInDb.SizeId= product.SizeId;

            _context.SaveChanges();

        }
        [HttpDelete]
        public void DeleteProduct(int id)
        {
            var productInDb = _context.Products.SingleOrDefault(m => m.Id == id);
            if (productInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Products.Remove(productInDb);
            _context.SaveChanges();
        }
    }
}
