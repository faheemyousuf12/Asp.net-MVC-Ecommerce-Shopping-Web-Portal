using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ECommerce.Models;
using ECommerce.ViewModel;

namespace ECommerce.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext _context;

        public CartController()
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
        public ActionResult Cart()
        {
            var cart = _context.CartLineItems.Include(m => m.product).Include(m => m.Size).ToList();
            if (cart == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CartLineItemViewModel
            {
                CartLineItem = _context.CartLineItems.Include(m => m.product).Include(m => m.Size).ToList(),
                Product=_context.Products.ToList(),
                cart=_context.Carts.SingleOrDefault(c=>c.Id==1)
            };            
            return View(viewModel);
        }
        public ActionResult AddToCart()
        {
            var cart = _context.Carts.ToList();
            var customer = _context.Customers.ToList();
            var viewModel = new AddToCartViewModel
            {
               Cart=cart,
               Customer=customer
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult SaveToCart(Cart cart)
        {
            if (cart.Id == 0)
                _context.Carts.Add(cart);
            return View();
        }
	}
}