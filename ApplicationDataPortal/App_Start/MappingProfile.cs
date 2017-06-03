using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApplicationDataPortal.Core;
using ApplicationDataPortal.Core.Models;
using AutoMapper;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<DisplayTypes, DisplayTypeDto>();
            Mapper.CreateMap<DisplayTypeDto, DisplayTypes>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<Customer, CustomersDto>();

        }
    }
}