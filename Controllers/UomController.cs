using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    [Authorize(Roles = RoleNames.Admin)]
    public class UomController : Controller
    {
       private ApplicationDbContext _context;

        public UomController()
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
        public ActionResult AddUom()
        {
            return View();
        }
        public ActionResult SaveUom()
        {
            return View();
        }

        public ActionResult UomDetails()
        {
            var uom = _context.UOMs.ToList();
            return View(uom);
        }


	}
}