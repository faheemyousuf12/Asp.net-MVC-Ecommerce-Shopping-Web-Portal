using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerce.Models;
using ECommerce.ViewModel;



namespace ECommerce.Controllers
{
    [Authorize(Roles = RoleNames.Admin)]
    public class ProductController : Controller
    {
        private ApplicationDbContext _context;

        public ProductController()
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
       
        public ActionResult CreateProduct()
        {
            var brand = _context.Brands.ToList();
            var childCategory = _context.ChildCategorys.ToList();
            var uom = _context.UOMs.ToList();
            var size = _context.Sizes.ToList();
            var viewModel = new ProductViewModel
            {
                Brand = brand,
                ChildCategory = childCategory,
                UOM = uom,
                Size=size

            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveProduct(Product product, HttpPostedFileBase image)
        {
            string loc = Server.MapPath("~/Images/");
            image.SaveAs(loc + image.FileName);
            product.Image = "~/Images/" + image.FileName;
           
            if (product.Id == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                var productInDb = _context.Products.Single(p => p.Id ==product.Id);
                productInDb.Name = product.Name;
                productInDb.BrandId = product.BrandId;
                productInDb.ChildCategoryId = product.ChildCategoryId;
                productInDb.UomId = product.UomId;
                productInDb.Price = product.Price;
                productInDb.Qty = product.Qty;
                productInDb.Reveiws = product.Reveiws;
                productInDb.Description = product.Description;
                productInDb.Image = loc+image.FileName;
                productInDb.SizeId = product.SizeId;
               
            }
            _context.SaveChanges();
            return RedirectToAction("ProductDetails","Product");
        }
        public ActionResult EditProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if(product==null)
                return HttpNotFound();
            var viewModel = new ProductViewModel
            {
                Product = product,
                Size=_context.Sizes.ToList(),
                Brand = _context.Brands.ToList(),
                ChildCategory = _context.ChildCategorys.ToList(),
                UOM = _context.UOMs.ToList()
            };
            return View("CreateProduct", viewModel);
        }
        public ActionResult DeleteProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
                return HttpNotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("ProductDetails");
        }
        
        public ActionResult ProductDetails()
        {
            //if (!User.IsInRole(RoleNames.Admin))
            //{

            //   return RedirectToAction("Login", "Account");
            //}
            //else
            //{
                var product = _context.Products.Include(p => p.brand).Include(p => p.ChildCategory).Include(p => p.Uom).Include(p => p.Size).ToList();
                return View(product);
            //}
        }
        public ActionResult Products()
        {
            var product = _context.Products.Include(p => p.brand).Include(p => p.ChildCategory).Include(p => p.Uom).ToList();
            return View(product);
        }
       
	}
}