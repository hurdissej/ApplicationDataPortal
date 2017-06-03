using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ApplicationDataPortal.Core.Models.AccountModels;

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
            var displayTypes = _context.DisplayTypes
                .Include(c => c.Customer)
                .ToList();
            

            return View(displayTypes);
        }

        public ActionResult New()
        {
            return View();
        }
    }
}