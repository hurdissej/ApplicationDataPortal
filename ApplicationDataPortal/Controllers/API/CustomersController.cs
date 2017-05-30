using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApplicationDataPortal.Dtos;
using ApplicationDataPortal.Models;
using AutoMapper;

namespace ApplicationDataPortal.Controllers.API
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //Get api/customers

        public IHttpActionResult getCustomers(string query = null)
        {
            IQueryable<Customer> customersQuery = _context.Customers;
                
            if (!String.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(m => m.Name.Contains(query));
            }
            
            return Ok(customersQuery);
        }

        public IHttpActionResult getCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            return Ok(customer);
        }

        
    }
}
