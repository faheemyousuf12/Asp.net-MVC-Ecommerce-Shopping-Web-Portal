using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ECommerce.Controllers.Api
{
    public class CategoriesController : ApiController
    {
        private ApplicationDbContext _context;

        public CategoriesController()
        {
            _context = new ApplicationDbContext();

        }
        [HttpGet]
        public IEnumerable<ChildCategory> GetCategories()
        {
            return _context.ChildCategorys.ToList();
        }
        [HttpGet]
        public ChildCategory GetCategories(int id)
        {
            var category = _context.ChildCategorys.SingleOrDefault(m => m.Id == id);
            if (category == null)

                throw new HttpResponseException(HttpStatusCode.NotFound);
            return category;
        }
        [HttpPost]
        public ChildCategory CreateCategory(ChildCategory category)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.ChildCategorys.Add(category);
            _context.SaveChanges();
            return category;
        }
        [HttpPut]
        public void UpdateCategory(int id, ChildCategory category)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var categoryInDb = _context.ChildCategorys.SingleOrDefault(m => m.Id == id);
            if (categoryInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            categoryInDb.Name = category.Name;
            categoryInDb.ParentCategoryId = category.ParentCategoryId;
         

            _context.SaveChanges();

        }
        [HttpDelete]
        public void DeleteCategory(int id)
        {
            var categoryInDb = _context.ChildCategorys.SingleOrDefault(m => m.Id == id);
            if (categoryInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.ChildCategorys.Remove(categoryInDb);
            _context.SaveChanges();
        }
    }
}
