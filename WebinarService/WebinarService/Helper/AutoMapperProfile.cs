using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebinarService.Entities;
using static WebinarService.Model.UMModel;

namespace WebinarService.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDetailsDTO, TblUserDetails>().ReverseMap();
            //CreateMap<TblUserDetails, UserDetailsDTO>();
        }
    }
}
