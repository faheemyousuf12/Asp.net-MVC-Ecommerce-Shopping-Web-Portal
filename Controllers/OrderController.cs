using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.ViewModel;
using ECommerce.Models;
using System.Data.Entity;

namespace ECommerce.Controllers
{
    [Authorize(Roles = RoleNames.Admin)]
    public class OrderController : Controller
    {
      private ApplicationDbContext _context;

        public OrderController()
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
        public ActionResult OrderDetails()
        {
            var order = _context.Orders.Include(o => o.Cart).Include(o => o.Product).Include(o => o.Customer).ToList();
            return View(order);
        }
        public ActionResult AddOrder()
        {
            return View();
        }
        public ActionResult SaveOrder()
        {
            return View();
        }
        public ActionResult EditOrder()
        {
            return View();
        }
        public ActionResult DeleteOrder()
        {
            return View();
        }
	}
}