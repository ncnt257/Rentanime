using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Rentanime.Dtos;
using Rentanime.Models;

namespace Rentanime.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<AnimeDto, Anime>()
                .ForMember(a => a.Id, opt => opt.Ignore());
            Mapper.CreateMap<Anime, AnimeDto>();

        }
    }
}