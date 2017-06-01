using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using ApplicationDataPortal.Dtos;
using ApplicationDataPortal.Models;

namespace ApplicationDataPortal.Repositories
{

    public class DisplayTypesRepositories
    {
        private readonly ApplicationDbContext _context;

        public DisplayTypesRepositories(ApplicationDbContext context)
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