using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicationDataPortal.Models;

namespace ApplicationDataPortal.Controllers
{
    public class DisplayTypesController : Controller
    {

        private ApplicationDbContext _context;

        public DisplayTypesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();
            

            return View();
        }
    }
}