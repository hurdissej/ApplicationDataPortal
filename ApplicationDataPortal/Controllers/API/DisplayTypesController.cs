using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApplicationDataPortal.Core;
using ApplicationDataPortal.Core.Models;
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
            var display = _unitOfWork.DisplayTypes.GetDisplayTypes()
                .Select(Mapper.Map<DisplayTypes, DisplayTypeDto>);

            return Ok(display);
        }

        
        //Get /api/DisplayTypes/1
        public IHttpActionResult GetDisplayType(int Id)
        {
            return Ok(_unitOfWork.DisplayTypes.GetDisplayType(Id));
        }
        
        //Post /api/DisplayTypes/
        [HttpPost]
        public void CreateDisplayType(DisplayTypeDto displayTypeDto)
        {
            _unitOfWork.DisplayTypes.CreateDisplayType(displayTypeDto);
            _unitOfWork.Complete();
        }


        //Put /api/displaytypes/1 
        [HttpPut]
        public IHttpActionResult UpdateDisplayType(int Id, DisplayTypeDto displayTypeDto)
        {
            var displayTypeInDB = _unitOfWork.DisplayTypes.GetDisplayType(Id);

            if (displayTypeInDB == null)
            {
                return BadRequest("That Display Type doesn't exist");
            }

            _unitOfWork.DisplayTypes.UpdateDisplayType(displayTypeDto,displayTypeInDB);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteDisplayType(int Id)
        {
            var displayTypeInDb = _unitOfWork.DisplayTypes.GetDisplayType(Id);

            if (displayTypeInDb == null)
            {
                return BadRequest("Display Type not found");
            }
            _unitOfWork.DisplayTypes.DeleteDisplayType(Id);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
