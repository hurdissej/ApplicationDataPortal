using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApplicationDataPortal.Core;
using ApplicationDataPortal.Core.Models.AccountModels;
using ApplicationDataPortal.Persistence;
using ApplicationDataPortal.Repositories;
using AutoMapper;

namespace ApplicationDataPortal.Controllers.API
{
    public class CustomersController : ApiController
    {

        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Get api/customers

        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _unitOfWork.Customers.GetCustomers(query);

            return Ok(customersQuery);
        }


        public IHttpActionResult GetCustomer(int Id)
        {
            var result = _unitOfWork.Customers.GetCustomer(Id);

            if (result == null)
            {
                return BadRequest("Customer does not exist");
            }

            return Ok(result);
        }
    }
}
