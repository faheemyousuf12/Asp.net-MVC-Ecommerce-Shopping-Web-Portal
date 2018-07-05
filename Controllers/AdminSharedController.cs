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
    public class AdminSharedController : Controller
    {
       private ApplicationDbContext _context;

        public AdminSharedController()
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
        public ActionResult Navbar()
        {
            var category = _context.ChildCategorys.Include(c => c.ParentCategory).ToList();
            return View(category);
        }
        public ActionResult Sidebar()
        {
            return View();
        }
	}
}