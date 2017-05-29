using System;
using System.Collections.Generic;
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

        public IHttpActionResult GetDisplayTypes()
        {
            var displayDtos = _context.DisplayTypes
                .Select(Mapper.Map<DisplayTypes, DisplayTypeDto>)
                .ToList();

            return Ok(displayDtos);


        }
    }
}
