using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApplicationDataPortal.Dtos;
using ApplicationDataPortal.Models;
using ApplicationDataPortal.Persistence;
using ApplicationDataPortal.Repositories;
using AutoMapper;

namespace ApplicationDataPortal.Controllers.API
{
    public class DisplayTypesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public DisplayTypesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Get /api/DisplayTypes
        public IHttpActionResult GetDisplayTypes()
        {
            var display = UnitOfWork.DisplayTypes.GetDisplayTypes()
                .Select(Mapper.Map<DisplayTypes, DisplayTypeDto>);

            return Ok(display);
        }

        
        //Get /api/DisplayTypes/1
        public IHttpActionResult GetDisplayType(int Id)
        {
            return Ok(UnitOfWork.DisplayTypes.GetDisplayType(Id));
        }
        
        //Post /api/DisplayTypes/
        [HttpPost]
        public void CreateDisplayType(DisplayTypeDto displayTypeDto)
        {
            UnitOfWork.DisplayTypes.CreateDisplayType(displayTypeDto);
            _unitOfWork.Complete();
        }


        //Put /api/displaytypes/1 
        [HttpPut]
        public IHttpActionResult UpdateDisplayType(int Id, DisplayTypeDto displayTypeDto)
        {
            var displayTypeInDB = UnitOfWork.DisplayTypes.GetDisplayType(Id);

            if (displayTypeInDB == null)
            {
                return BadRequest("That Display Type doesn't exist");
            }

            UnitOfWork.DisplayTypes.UpdateDisplayType(displayTypeDto,displayTypeInDB);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteDisplayType(int Id)
        {
            var displayTypeInDb = UnitOfWork.DisplayTypes.GetDisplayType(Id);

            if (displayTypeInDb == null)
            {
                return BadRequest("Display Type not found");
            }
            UnitOfWork.DisplayTypes.DeleteDisplayType(Id);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
