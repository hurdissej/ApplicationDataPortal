using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApplicationDataPortal.Dtos;
using ApplicationDataPortal.Models;
using AutoMapper;

namespace ApplicationDataPortal.Controllers.API
{
    public class DisplayTypesController : ApiController
    {
        private ApplicationDbContext _context;

        public DisplayTypesController()
        {
            _context = new ApplicationDbContext();
        }

        
        //Get /api/DisplayTypes
        public IHttpActionResult GetDisplayTypes(string query = null)
        {
            var displayTypes = _context.DisplayTypes
                .Include(c => c.Customer)
                .ToList();
            

            var display = displayTypes
                .Select(Mapper.Map<DisplayTypes, DisplayTypeDto>);

            return Ok(display);
        }


        //Get /api/DisplayTypes/1
        public IHttpActionResult GetDisplayType(int Id)
        {
            var displayType = _context.DisplayTypes
                .Include(c => c.Customer)
                .SingleOrDefault(c => c.Id == Id);

            return Ok(displayType);
        }

        //Post /api/DisplayTypes/
        [HttpPost]
        public void CreateDisplayType(DisplayTypeDto displayTypeDto)
        {
            
            var displaytype = new DisplayTypes
            {
                Description = displayTypeDto.Description,
                CustomerId = displayTypeDto.CustomerId,
                DateAdded = DateTime.Now
            };

            _context.DisplayTypes.Add(displaytype);
            _context.SaveChanges();
        }


    }
}
