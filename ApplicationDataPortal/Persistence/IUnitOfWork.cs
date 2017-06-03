using ApplicationDataPortal.Models;

namespace ApplicationDataPortal.Persistence
{
    public interface IUnitOfWork
    {
        ApplicationDbContext Context { get; set; }
        void Complete();
    }
}