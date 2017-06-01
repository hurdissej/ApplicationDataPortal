using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApplicationDataPortal.Dtos;
using ApplicationDataPortal.Models;
using ApplicationDataPortal.Repositories;
using AutoMapper;

namespace ApplicationDataPortal.Controllers.API
{
    public class DisplayTypesController : ApiController
    {
        private ApplicationDbContext _context;
        private readonly DisplayTypesRepositories _displayTypesRepositories;

        public DisplayTypesController()
        {
            _context = new ApplicationDbContext();
            _displayTypesRepositories = new DisplayTypesRepositories(_context);
            
        }
        
        //Get /api/DisplayTypes
        public IHttpActionResult GetDisplayTypes()
        {
            var display = _displayTypesRepositories.GetDisplayTypes()
                .Select(Mapper.Map<DisplayTypes, DisplayTypeDto>);

            return Ok(display);
        }

        
        //Get /api/DisplayTypes/1
        public IHttpActionResult GetDisplayType(int Id)
        {
            return Ok(_displayTypesRepositories.GetDisplayType(Id));
        }
        
        //Post /api/DisplayTypes/
        [HttpPost]
        public void CreateDisplayType(DisplayTypeDto displayTypeDto)
        {
            _displayTypesRepositories.CreateDisplayType(displayTypeDto);
        }


        //Put /api/displaytypes/1 
        [HttpPut]
        public IHttpActionResult UpdateDisplayType(int Id, DisplayTypeDto displayTypeDto)
        {
            var displayTypeInDB = _displayTypesRepositories.GetDisplayType(Id);

            if (displayTypeInDB == null)
            {
                return BadRequest("That Display Type doesn't exist");
            }

            _displayTypesRepositories.UpdateDisplayType(displayTypeDto,displayTypeInDB);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteDisplayType(int Id)
        {
            var displayTypeInDb = _displayTypesRepositories.GetDisplayType(Id);

            if (displayTypeInDb == null)
            {
                return BadRequest("Display Type not found");
            }
            _displayTypesRepositories.DeleteDisplayType(Id);

            return Ok();
        }
    }
}
