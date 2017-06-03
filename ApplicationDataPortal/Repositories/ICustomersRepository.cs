using System.Collections.Generic;
using ApplicationDataPortal.Models;

namespace ApplicationDataPortal.Repositories
{
    public interface ICustomersRepository
    {
        ApplicationDbContext Context { get; }
        IEnumerable<Customer> GetCustomers(string query);
        Customer GetCustomer(int id);
    }
}