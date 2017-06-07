using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApplicationDataPortal.Core.Models.AccountModels;
using ApplicationDataPortal.Persistence;
using ApplicationDataPortal.Repositories;
using AutoMapper;

namespace ApplicationDataPortal.Controllers.API
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _context;
        private readonly UnitOfWork _unitOfWork;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
            _unitOfWork = new UnitOfWork(_context);
        }

        //Get api/customers

        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _unitOfWork.Customers.GetCustomers(query);

            return Ok(customersQuery);
        }


        public IHttpActionResult GetCustomer(int Id)
        {
            return Ok(_unitOfWork.Customers.GetCustomer(Id));
        }
    }
}
