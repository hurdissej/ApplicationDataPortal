using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApplicationDataPortal.Models;
using ApplicationDataPortal.Repositories;

namespace ApplicationDataPortal.Persistence
{
    public class UnitOfWork
    {
        public ApplicationDbContext Context { get; set; }

        public static DisplayTypesRepositories DisplayTypes { get; private set; }

        public static CustomersRepository Customers { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            Context = context;
            DisplayTypes = new DisplayTypesRepositories(context);
            Customers = new CustomersRepository(context);

        }

        public void Complete()
        {
            Context.SaveChanges();
        }

    }
}