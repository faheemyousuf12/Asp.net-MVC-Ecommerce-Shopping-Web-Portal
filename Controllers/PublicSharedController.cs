using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.Models;
using ECommerce.ViewModel;
using System.Data.Entity;

namespace ECommerce.Controllers
{
    public class PublicSharedController : Controller
    {
        private ApplicationDbContext _context;

        public PublicSharedController()
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
        public ActionResult PublicNavbar()
        {
            var category = _context.ChildCategorys.Include(c => c.ParentCategory).ToList();
            return View(category);
        }
	}
}