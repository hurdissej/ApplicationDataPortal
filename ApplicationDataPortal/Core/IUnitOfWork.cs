using ApplicationDataPortal.Core.Models.AccountModels;

namespace ApplicationDataPortal.Core
{
    public interface IUnitOfWork
    {
        ApplicationDbContext Context { get; set; }
        void Complete();
    }
}