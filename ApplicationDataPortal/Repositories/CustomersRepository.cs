using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApplicationDataPortal.Models;

namespace ApplicationDataPortal.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        public ApplicationDbContext Context { get; private set; }

        public CustomersRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public IEnumerable<Customer> GetCustomers(string query)
        {
            IEnumerable<Customer> customersQuery = Context.Customers;

            if (!String.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(m => m.Name.Contains(query));
            }
            return customersQuery;
        }

        public Customer GetCustomer(int id)
        {
            return Context.Customers.SingleOrDefault(c => c.Id == id);
        }
    }
}