using AutoMapper;
using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ShiftDTO, Shift>();
            CreateMap<Shift, Shift>();
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<User, UserForRegistrationDto>();
        }
       
    }
}
