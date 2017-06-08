using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApplicationDataPortal.Core;
using ApplicationDataPortal.Core.Models.AccountModels;
using ApplicationDataPortal.Core.Repositories;
using ApplicationDataPortal.Repositories;

namespace ApplicationDataPortal.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext Context { get; set; }

        public IDisplayTypesRepositories DisplayTypes { get; private set; }
        public ICustomersRepository Customers { get; private set; }
        public IPromotionsRepository Promotions { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            Context = context;
            DisplayTypes = new DisplayTypesRepositories(context);
            Customers = new CustomersRepository(context);
            Promotions = new PromotionsRepository(context);

        }

        public void Complete()
        {
            Context.SaveChanges();
        }

    }
}