using ApplicationDataPortal.Core.Models.AccountModels;
using ApplicationDataPortal.Core.Repositories;

namespace ApplicationDataPortal.Core
{
    public interface IUnitOfWork
    {
        IDisplayTypesRepositories DisplayTypes { get; }
        ICustomersRepository Customers { get; }
        void Complete();
    }
}