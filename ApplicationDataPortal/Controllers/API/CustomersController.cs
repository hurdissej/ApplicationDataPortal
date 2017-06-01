using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApplicationDataPortal.Dtos;
using ApplicationDataPortal.Models;
using ApplicationDataPortal.Repositories;
using AutoMapper;

namespace ApplicationDataPortal.Controllers.API
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _context;
        private readonly CustomersRepository _customersRepository;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
            _customersRepository = new CustomersRepository(_context);
        }

        //Get api/customers

        public IHttpActionResult getCustomers(string query = null)
        {
            var customersQuery = _customersRepository.GetCustomers(query);

            return Ok(customersQuery);
        }


        public IHttpActionResult getCustomer(int Id)
        {
            return Ok(_customersRepository.GetCustomer(Id));
        }
    }
}
