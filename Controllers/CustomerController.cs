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
    [Authorize(Roles = RoleNames.Admin)]
    public class CustomerController : Controller
    {
         private ApplicationDbContext _context;

        public CustomerController()
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
        public ActionResult AddCustomer()
        {
            var membershipType = _context.MembershipTypes.ToList();
            var viewModel = new CustomerViewModel
            {
                MembershipType=membershipType
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult SaveCustomer(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Password = customer.Password;
                customerInDb.ConfirmPassword = customer.ConfirmPassword;
                customerInDb.Email = customer.Email;
              

            }
            _context.SaveChanges();
            return RedirectToAction("CustomerDetails", "Customer");
        }
        public ActionResult login()
        {
            return View();
        }
        public ActionResult logedIn(Customer user)  
         {
          if (user.Email != null && user.Password != null)
          {
              var usr = _context.Customers.Single(u => u.Email == user.Email && u.Password == user.Password);
              if (usr != null)
              {
                  var id=usr.Id.ToString();
                  Session["Id"] = id;
                  
                  return RedirectToAction("Items","Item");
              }
              else
              {
                  Console.WriteLine("Username or Password is Incorrect");                 
              }
          }
          else
          {
              Console.WriteLine("Username or Password is Incorrect");
          }
          return RedirectToAction("Items","Item");

         }
        public ActionResult CustomerDetails()
        {
            var customer = _context.Customers.ToList();
            return View(customer);
        }
        public ActionResult EditCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer.Id ==0)
                return HttpNotFound();
            var viewModel=new CustomerViewModel
            {
                Customer=customer
            };
            return View("AddCustomer",viewModel);
        }
        public ActionResult DeleteCustomer(int id)
        {
            var customers = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customers == null)
                return HttpNotFound();
            _context.Customers.Remove(customers);
            _context.SaveChanges();
            return RedirectToAction("CustomerDetails");
        }
	}
}