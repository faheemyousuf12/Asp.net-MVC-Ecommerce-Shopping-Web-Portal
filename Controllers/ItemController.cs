using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using ECommerce.ViewModel;

namespace ECommerce.Controllers
{
    public class ItemController : Controller
    {
       
        private ApplicationDbContext _context;

        public ItemController()
        {
            _context = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Items(string category)
        {  
           
            //.Where(p=>category== null || p.ChildCategory==category)
                var item = _context.Products.OrderBy(p=>p.Id).Include(p => p.brand).Include(p => p.ChildCategory).Include(p => p.Uom).Include(p => p.Size).ToList();
                string id = (string)Session["Id"];
                if (id != "")
                {
                    return View(item);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                   
                }
            
         
         }
        public ActionResult Details(int id)
        {
            if (id ==null)
            {
                throw new Exception("not found");
            }
            else
            {
                var viewModel = new ProductCartViewModel
                {
                    Product = _context.Products.Include(m => m.brand).Include(m => m.Size).SingleOrDefault(m => m.Id == id),
                    cartId = Convert.ToInt32(_context.Carts.Max(m => m.Id)),
                    productId = id,
                    Size = _context.Sizes.ToList()
                };
                return View(viewModel);
            }
        }
       
      
        public ActionResult Cart(int id)
        {
            var customer = _context.Customers.SingleOrDefault(m => m.Id == id);
            var userbasket = _context.UserBaskets.Where(m => m.CustomerId == id);
            var size = _context.Sizes.ToList();
            var product = _context.Products.ToList();
            var viewModel = new ProductBasketViewModel
            {
                Customer = customer,
                Size = size,
                UserBasket = userbasket,
                Product = product
            };
            return View(viewModel);
           
        }
        public ActionResult AddToCart(ProductBasketViewModel pbvw)
        {
            Cart cart = new Cart();          
            cart.DateTime = DateTime.Now;
            cart.CustomerId = pbvw.CustomerId;
            cart.TotalAmount = pbvw.TotAmount;
            cart.TotalQty = pbvw.TotQty;
            _context.Carts.Add(cart);
            _context.SaveChanges();
           
            return RedirectToAction("Items");
        }

        [HttpPost]
        public ActionResult SaveToBasket(ProductCartViewModel productCartViewModel)
        {
            if (productCartViewModel.UserBasket.Id == 0)
            {
                //var userId = TempData["Id"];
                Cart cart = (Cart)Session["Cart"];
               string currentUser = User.Identity.GetUserId();
                string custId = Session["Id"].ToString();
                productCartViewModel.UserBasket.CustomerId  =Convert.ToInt32(custId);
                productCartViewModel.UserBasket.ProductId = productCartViewModel.productId;
                int price = _context.Products.Single(m => m.Id == productCartViewModel.productId).Price;
                int amoount = productCartViewModel.UserBasket.Qty * price;
                productCartViewModel.UserBasket.Amount = amoount;
                _context.UserBaskets.Add(productCartViewModel.UserBasket);
            }
            _context.SaveChanges();
            return RedirectToAction("Items", "Item");
        }
       
        [HttpPost]
        public ActionResult SaveToCart(ProductCartViewModel productCartViewModel)
        {
            if (productCartViewModel.CartLineItem.Id == 0)
            {
                productCartViewModel.CartLineItem.CartId = productCartViewModel.cartId;
                productCartViewModel.CartLineItem.ProductId = productCartViewModel.productId;
                _context.CartLineItems.Add(productCartViewModel.CartLineItem);
            }
            _context.SaveChanges();
            return RedirectToAction("cart", "Item");
        }
        
        public ActionResult BrandsSidebar()
        {
            return PartialView("BrandsSidebar");
        }
        public ActionResult CategorySidebar()
        {
            return PartialView("CategorySidebar");
        }
        public ActionResult CategoriesSidebar()
        {
            return PartialView("CategoriesSidebar");
        }
        public ActionResult Admin_Navbar()
        {
            ViewBag.menu = _context.UserBaskets.ToList().Count(m => m.CustomerId == '1');
            return PartialView("Admin_Navbar", ViewBag.menu);
        }
    
    }
}