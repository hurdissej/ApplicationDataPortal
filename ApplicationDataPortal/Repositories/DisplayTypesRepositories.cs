using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using ApplicationDataPortal.Core;
using ApplicationDataPortal.Core.Dtos;
using ApplicationDataPortal.Core.Models;
using ApplicationDataPortal.Core.Models.AccountModels;
using ApplicationDataPortal.Core.Repositories;

namespace ApplicationDataPortal.Repositories
{

    public class DisplayTypesRepositories : IDisplayTypesRepositories
    {
        private readonly IApplicationDbContext _context;

        public DisplayTypesRepositories(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DisplayTypes> GetDisplayTypes()
        {
            return _context.DisplayTypes
                .Include(c => c.Customer)
                .ToList();
        }

        public DisplayTypes GetDisplayType(int Id)
        {
            return _context.DisplayTypes
                .Include(c => c.Customer)
                .SingleOrDefault(c => c.Id == Id);
        }

        public void UpdateDisplayType(DisplayTypeDto displayTypeDto, DisplayTypes displayTypeInDb)
        {
            displayTypeInDb.Description = displayTypeDto.Description;
            displayTypeInDb.CustomerId = displayTypeDto.CustomerId;
        }

        public void DeleteDisplayType(int Id)
        {

            _context.DisplayTypes.Remove(GetDisplayType(Id));
        }


        public void CreateDisplayType(DisplayTypeDto displayTypeDto)
        {
            var displaytype = new DisplayTypes
            {
                Description = displayTypeDto.Description,
                CustomerId = displayTypeDto.CustomerId,
                DateAdded = DateTime.Now
            };

            _context.DisplayTypes.Add(displaytype);
        }
    }
}