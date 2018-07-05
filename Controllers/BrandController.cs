using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    [Authorize(Roles = RoleNames.Admin)]
    public class BrandController : Controller
    {

         private ApplicationDbContext _context;

        public BrandController()
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
        public ActionResult AddBrand()
        {
            var brand = _context.Brands.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CreateBrand(Brand brand)
        {
            if (brand.Id == 0)
            {
                _context.Brands.Add(brand);
            }
            else
            {
                var brandInDb = _context.Brands.Single(b => b.Id == brand.Id);
                brandInDb.Name = brand.Name;
            }
            _context.SaveChanges();
            return RedirectToAction("BrandDetails");
        }
        public ActionResult EditBrand(int id)
        {
            var brand = _context.Brands.SingleOrDefault(b => b.Id == id);
            if (brand == null)
                return HttpNotFound();
            
            return View("AddBrand");
        }
        
        public ActionResult BrandDetails()
        {
            var brand = _context.Brands.ToList();
            return View(brand);
        }

        public ActionResult DeleteBrand(int id)
        {
            var brands = _context.Brands.SingleOrDefault(b => b.Id == id);
            if (brands == null)
            {
                return HttpNotFound();
            }
            _context.Brands.Remove(brands);
            _context.SaveChanges();
            return RedirectToAction("BrandDetails");
        }
	}
}