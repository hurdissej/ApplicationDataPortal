using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApplicationDataPortal.Models;
using ApplicationDataPortal.Dtos;
using AutoMapper;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<DisplayTypes, DisplayTypeDto>();
            Mapper.CreateMap<DisplayTypeDto, DisplayTypes>();
            Mapper.CreateMap<Customer, CustomersDto>();

        }
    }
}