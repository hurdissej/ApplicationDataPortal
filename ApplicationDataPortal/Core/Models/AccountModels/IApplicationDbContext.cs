using System.Data.Entity;

namespace ApplicationDataPortal.Core.Models.AccountModels
{
    public interface IApplicationDbContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Promotions> Promotions { get; set; }
        DbSet<DisplayTypes> DisplayTypes { get; set; }
    }
}