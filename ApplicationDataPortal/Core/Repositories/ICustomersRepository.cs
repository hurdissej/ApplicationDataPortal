using System.Collections.Generic;
using ApplicationDataPortal.Core.Models;
using ApplicationDataPortal.Core.Models.AccountModels;

namespace ApplicationDataPortal.Core.Repositories
{
    public interface ICustomersRepository
    {
        ApplicationDbContext Context { get; }
        IEnumerable<Customer> GetCustomers(string query);
        Customer GetCustomer(int id);
    }
}