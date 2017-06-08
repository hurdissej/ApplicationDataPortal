using ApplicationDataPortal.Core.Models.AccountModels;
using ApplicationDataPortal.Core.Repositories;
using ApplicationDataPortal.Repositories;

namespace ApplicationDataPortal.Core
{
    public interface IUnitOfWork
    {
        IDisplayTypesRepositories DisplayTypes { get; }
        ICustomersRepository Customers { get; }
        IPromotionsRepository Promotions { get; }
        void Complete();
    }
}