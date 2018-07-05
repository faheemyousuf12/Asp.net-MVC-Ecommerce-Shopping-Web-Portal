using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerce.ViewModel;
using System.Web.Mvc;
using System.Data.Entity;

namespace ECommerce.Controllers
{
    [Authorize(Roles = RoleNames.Admin)]
    public class CategoryController : Controller
    {
       private ApplicationDbContext _context;

        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddCategory()
        {
            var parentCategory = _context.ParentCategorys.ToList();

            var viewModel = new CategoryViewModel()
            {
                ParentCategory = parentCategory,

            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult SaveCategory(ChildCategory childCategory)
        {
            if (childCategory.Id == 0)
            {
                _context.ChildCategorys.Add(childCategory);
            }
           
            else
            {
                var categoryInDb = _context.ChildCategorys.Single(c => c.Id == childCategory.Id);
                categoryInDb.Name = childCategory.Name;
                categoryInDb.ParentCategoryId = childCategory.ParentCategoryId;

            }
            _context.SaveChanges();
            return RedirectToAction("CategoryDetails", "Category");
        }
        public ActionResult EditCategory(int id)
        {
            var childCategory = _context.ChildCategorys.SingleOrDefault(c => c.Id == id);
            if (childCategory == null)
                return HttpNotFound();
            var viewModel = new CategoryViewModel
            {
                ChildCategory=childCategory,
               ParentCategory=_context.ParentCategorys.ToList()
            };
            return View("AddCategory", viewModel);
        }
        public ActionResult DeleteCategory(int id)
        {
            var childCategory = _context.ChildCategorys.Single(c => c.Id == id);
            if (childCategory == null)
                return HttpNotFound();
            _context.ChildCategorys.Remove(childCategory);
            _context.SaveChanges();
            return RedirectToAction("CategoryDetails");

        }
        public ActionResult CategoryDetails()
        {
            var category = _context.ChildCategorys.Include(c => c.ParentCategory).ToList();
            return View(category);
        }
       
	}
}